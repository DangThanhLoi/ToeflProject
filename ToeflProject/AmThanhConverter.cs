using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;

namespace ToeflProject
{
    public class AmThanhConverter : IValueConverter
    {
        public static string AMTHANH_CHUDE_DIRECTORY = Environment.CurrentDirectory + "\\Audioes";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FileInfo fi;
            try
            {
                fi = new FileInfo(AMTHANH_CHUDE_DIRECTORY + "\\" + value.ToString());
                if (!fi.Exists) throw new FileNotFoundException();
            }
            catch
            {
                fi = new FileInfo(AMTHANH_CHUDE_DIRECTORY + "\\We Are Electric.mp3 ");
            }
            return fi.FullName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
