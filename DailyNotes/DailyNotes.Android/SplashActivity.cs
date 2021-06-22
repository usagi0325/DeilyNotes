using Android.Animation;
using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;
using Com.Airbnb.Lottie;

namespace DailyNotes.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    public class SplashActivity : Activity , Animator.IAnimatorListener
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //SetContentView(Resource.Layout.Activity_Splash);

            //var animationView = FindViewById(Resource.Id.animation_view);

        }

        public void OnAnimationCancel(Animator animation)
        {
        }
        /// <summary>
        /// アニメーションが終わったらメインアクティビティを呼ぶ
        /// </summary>
        /// <param name="animation"></param>
        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
