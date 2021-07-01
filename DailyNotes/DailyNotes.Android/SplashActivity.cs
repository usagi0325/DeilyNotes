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
        /// �A�j���[�V�����Z�b�g�A�b�v
        /// </summary>
        public void setup()
        {
            animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);
            // �A�j���[�V�����̌J��Ԃ��񐔁i1��Ȃ�0�j
            animationView.RepeatCount = 0;
            animationView.PlayAnimation();
        }


        public void OnAnimationCancel(Animator animation)
        {
        }
        /// <summary>
        /// �A�j���[�V�������I������烁�C���A�N�e�B�r�e�B���Ă�
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
