using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MethodBoundaryAspect.Fody.Attributes;
using Xamarin.Forms;

namespace TasksAppXamarin.Aop
{
    public class HandleExceptionAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs arg)
        {
            if (!(arg.ReturnValue is Task))
            {
                // Display Error asynchronously without blocking thread
                Device.BeginInvokeOnMainThread(() =>
                    ShowError(arg.Exception));
                arg.FlowBehavior = FlowBehavior.Return;
                arg.ReturnValue = GetDefault(arg.Method.DeclaringType);
            }
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            if (arg.ReturnValue is Task lt)
            {
                // Replace returned Task with Task with Exception handling
                var taskGenericArgument = typeof(object);
                var returnType = lt.GetType();
                if (returnType.IsGenericType)
                {
                    taskGenericArgument = returnType.GetGenericArguments().First();
                }

                var genericTaskMethod = GetType()
                    .GetMethod(nameof(HandleTask), BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.MakeGenericMethod(taskGenericArgument);

                arg.ReturnValue = genericTaskMethod?.Invoke(this, new object[] { lt }) ?? lt;
            }
        }

        private async Task<T> HandleTask<T>(Task baseTask)
        {
            try
            {
                await baseTask;
                if (baseTask is Task<T> baseGenericTask)
                    return baseGenericTask.Result;
            }
            catch (Exception e)
            {
                await ShowError(e);
            }

            return (T)GetDefault(typeof(T));
        }

        private async Task ShowError(Exception ex)
        {
            await UserDialogs.Instance.AlertAsync(ex.Message, "An error occured");
        }

        private object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}