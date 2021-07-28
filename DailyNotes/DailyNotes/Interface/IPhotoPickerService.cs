using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DailyNotes.Interface
{
	public interface IPhotoPickerService
	{
		Task<Stream> GetImageStreamAsync();
	}
}
