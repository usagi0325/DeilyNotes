using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace DailyNotes.Converter
{
    /// <summary>
    /// バイト単位のイメージをバインドするためのコンバーター
    /// <see cref="https://itblogdsi.blog.fc2.com/blog-entry-142.html"/>
    /// </summary>
    public class ImageSourceFromByteArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource imgSource = null;
            if (value != null)
            {
                byte[] byteArray = (byte[])value;
                imgSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
            }
            return imgSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
