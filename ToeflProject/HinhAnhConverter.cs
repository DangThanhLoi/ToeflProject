using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace ToeflProject
{
    public class HinhAnhConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FileInfo fi;
            try
            {
                fi = new FileInfo(TrangNguoiDung.IMAGE_NGUOIDUNG_DIRECTORY + "\\" + value.ToString());
                if (!fi.Exists) throw new FileNotFoundException();
            }
            catch {
                fi = new FileInfo(TrangNguoiDung.IMAGE_NGUOIDUNG_DIRECTORY + "\\default-male.jpg");
            }
            return new BitmapImage(new Uri(fi.FullName));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
