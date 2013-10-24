using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace ToeflProject
{
    public class HinhAnhConverter :IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string image = value.ToString();
            return new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), @"Images\NguoiDung\") + image));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
