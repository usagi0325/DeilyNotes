using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Java.IO;

namespace DailyNotes.Service
{
	public class ImageSaveService
	{
		/// <summary>
		/// イメージファイルをJPEGで保存
		/// </summary>
		string imageName = "NotesAddImage" + DateTime.Now.ToString("G") + ".jpeg";

		string imageFilePath = "";

		Bitmap bitmap;

		[Obsolete]
		public string GetImagePass (){

			// とりあえずDowunloadフォルダへ
			File file = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
			//string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

			File myFile = new Java.IO.File(file , imageName);
			imageFilePath = myFile.AbsolutePath;

			using (var saveImageFilePath = new System.IO.FileStream(imageFilePath, System.IO.FileMode.Create))
			{
				bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, saveImageFilePath);
			};

			return imageFilePath;
		}

		public void DeleteImage(string imageFilePath)
		{
			File file = new File(imageFilePath);
			var result = file.Delete();
		}
	}
}
