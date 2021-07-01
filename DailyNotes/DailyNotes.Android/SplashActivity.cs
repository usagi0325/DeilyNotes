using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using Com.Airbnb.Lottie;

namespace DailyNotes.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
              Label = "DailyNotes",
              NoHistory = true)]
    public class SplashActivity : AppCompatActivity, Animator.IAnimatorListener
    {
        LottieAnimationView animationView;
        //public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        //{
        //    base.OnCreate(savedInstanceState, persistentState);
        //    SetContentView(Resource.Layout.Activity_Splash);
        //    setup();
        //}

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            SetContentView(Resource.Layout.Activity_Splash);
            setup();
            //StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
        /// <summary>
        /// アニメーションセットアップ
        /// </summary>
        public void setup()
        {
            animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);
            // アニメーションの繰り返し回数（1回なら0）
            animationView.RepeatCount = 0;
            animationView.PlayAnimation();
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
