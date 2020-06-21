using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TasksAppXamarin.Droid
{
    [Activity(Label = "TasksAppXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledException;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void AndroidEnvironmentOnUnhandledException(object sender, RaiseThrowableEventArgs e)
        {
            e.Handled = true;
            ShowAlert("AndroidUnhandledException", e.Exception);
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            ShowAlert("UnobservedTaskException", e.Exception);
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowAlert("UnhandledException", e.ExceptionObject as Exception);
        }

        private void ShowAlert(string title, Exception ex)
        {
            RunOnUiThread(() =>
            {
                new AlertDialog.Builder(this)
                    .SetPositiveButton("Ok", (sender, args) =>
                    {
                    })
                    .SetMessage(ex?.Message)
                    .SetTitle(title)
                    .Show();
            });
        }
    }
}