using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DailyNotes.Converter
{
	public class StreamToByteConverter
	{
		/// <summary>
		/// ストリームをバイトに変換する
		/// </summary>
		/// <param name="stream">ストリーム</param>
		/// <returns>バイト配列</returns>
		public static byte[] StreamToByte(Stream stream)
		{
			byte[] byteArray = null;

			stream.Position = 0;

			using (MemoryStream ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				byteArray = ms.ToArray();
			}
			return byteArray;
		}
	}
}
