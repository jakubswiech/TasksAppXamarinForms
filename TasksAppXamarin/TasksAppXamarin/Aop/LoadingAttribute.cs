using System.Threading.Tasks;
using Acr.UserDialogs;
using MethodBoundaryAspect.Fody.Attributes;
using Xamarin.Forms;

namespace TasksAppXamarin.Aop
{
    public class LoadingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Loading"));
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            if (arg.ReturnValue is Task lt)
                lt.ContinueWith(loadingTask => { HideLoading(); });
            else
                HideLoading();
        }

        private void HideLoading()
        {
            Device.BeginInvokeOnMainThread(() =>
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading()));
        }
    }
}
