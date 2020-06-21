using Acr.UserDialogs;
using Android.Animation;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Airbnb.Lottie;
using Lottie.Forms.Droid;

namespace TasksAppXamarin.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : Activity, Animator.IAnimatorListener
    {
        LottieAnimationView _animationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);

            var animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);
        }

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(typeof(MainActivity));
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}