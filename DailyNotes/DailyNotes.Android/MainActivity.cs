using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using DailyNotes.Interface;
using DailyNotes.Droid;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Android.Content;
using System.IO;

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
        internal static MainActivity Instance{ get; private set; }    

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SetTheme(Resource.Style.MainTheme);

            // グローバル状態のすべての設定を定義
            base.OnCreate(savedInstanceState);

            Instance = this;

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
        
        //↓画像選択に関する処理
        public static readonly int PickImageId = 1000;

        /// <summary>
        /// タスクの完了状態
        /// </summary>
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
		{
			base.OnActivityResult(requestCode, resultCode, intent);

            if(requestCode == PickImageId)
            {
                if((resultCode == Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;

                    Stream stream = ContentResolver.OpenInputStream(uri);

                    PickImageTaskCompletionSource.SetResult(stream);
				}
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);

				}

			}

		}
	}

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            DependencyService.Register<IReadWritePermission, Permission.ReadWriteStoragePermission>();
            DependencyService.Register<IPhotoPickerService, Service.PhotoPickerService>();
            // Register any platform specific implementations
        }
    }
}

