using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using BLL;
using DAL;
namespace ToeflProject
{
    class TenQuyenConverter : IValueConverter
    {
        QuyenBLL qBll = new QuyenBLL();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Quyen q = (Quyen)value;
            if (q == null) return "Not set";
            return q.TenQuyen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
