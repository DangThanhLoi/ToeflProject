using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAL;
using BLL;
using System.Collections.ObjectModel;
namespace ToeflProject
{
    /// <summary>
    /// Interaction logic for TrangNguoiDung.xaml
    /// </summary>
    public partial class TrangNguoiDung : Window
    {
        private NguoiDungBLL ndBLL;
        private QuyenBLL qBLL;
        ObservableCollection<NguoiDung> dsNguoiDung;
        public TrangNguoiDung()
        {
            InitializeComponent();
            InitializeMyComponent();
        }

        private void InitializeMyComponent()
        {
            ndBLL = new NguoiDungBLL();
            qBLL = new QuyenBLL();
            dsNguoiDung = new ObservableCollection<NguoiDung>(ndBLL.LayTatCa());
            dataGridNguoiDung.ItemsSource = dsNguoiDung;
            cboQuyen.ItemsSource = qBLL.LayTatCa();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PublicMethods.SaveChange();
        }
    }
}
