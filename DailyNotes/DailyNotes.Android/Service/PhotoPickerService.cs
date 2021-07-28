using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DailyNotes.Interface;
using System.Threading.Tasks;
using System.IO;

namespace DailyNotes.Droid.Service
{
	public class PhotoPickerService : IPhotoPickerService
	{
		public Task<Stream> GetImageStreamAsync()
		{
            //画像を取得するためにインスタンスを取得する
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // ピクチャ ピッカーアクティビティを開始 (MainActivity.cs で再開)。
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // オブジェクトをメインアクティビティプロパティとして保存。
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // 戻るタスクオブジェクト
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
	}
}