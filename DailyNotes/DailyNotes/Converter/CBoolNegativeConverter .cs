using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using System.Globalization;

namespace DailyNotes.Converter
{
    /// <summary>
    /// bool値反転コンバーター
    /// <see cref="https://nakasato-work.hatenablog.com/entry/2016/10/28/105609"/>
    /// </summary>
    public class CBoolNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }

    }
}
