using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;

namespace ToeflProject
{
    public class NDImagePathConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            string image = value.ToString();
            return Path.Combine(Directory.GetCurrentDirectory(), @"Images\NguoiDung\") + image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string fullPath = value.ToString();
            FileInfo fi = new FileInfo(fullPath);
            return fi.Name;
        }
    }
}
