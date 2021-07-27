using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using DailyNotes.Interface;
using DailyNotes.Droid;
using Xamarin.Essentials;

namespace DailyNotes.Droid
{
    [Activity(Theme = "@style/MainTheme",
              Label = "DailyNotes",
              ConfigurationChanges = ConfigChanges.ScreenSize | 
                                   　ConfigChanges.Orientation | 
                                   　ConfigChanges.UiMode | 
        　                           ConfigChanges.ScreenLayout | 
                                   　ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SetTheme(Resource.Style.MainTheme);

            // グローバル状態のすべての設定を定義
            base.OnCreate(savedInstanceState);

            // 初期化処理
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App(new AndroidInitializer()));
        }

        /// <summary>
        /// 権限の結果を返す
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            DependencyService.Register<IReadWritePermission, Permission.ReadWriteStoragePermission>();
            // Register any platform specific implementations
        }
    }
}

