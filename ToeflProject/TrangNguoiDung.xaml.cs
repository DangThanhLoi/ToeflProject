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
using Microsoft.Win32;
using System.IO;
namespace ToeflProject
{
    /// <summary>
    /// Interaction logic for TrangNguoiDung.xaml
    /// </summary>
    public partial class TrangNguoiDung : Window
    {
        public static string MYDIRECTORY = Environment.CurrentDirectory;
        public static string IMAGE_NGUOIDUNG_DIRECTORY = MYDIRECTORY + "\\Images\\NguoiDung";
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
            dsNguoiDung.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsNguoiDung_CollectionChanged);
        }

        void dsNguoiDung_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (object item in e.NewItems)
                    {
                        ndBLL.Them(item as NguoiDung);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (object item in e.OldItems)
                    {
                        ndBLL.Xoa(item as NguoiDung);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PublicMethods.SaveChange();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Chọn Image cùng tên ,lúc copy vào thư mục Images\NguoiDung sẽ bị lỗi
            OpenFileDialog ofd = new OpenFileDialog { Multiselect = false, InitialDirectory = @"D:\Image\" };
            ofd.ShowDialog();
            NguoiDung nd = (NguoiDung)dataGridNguoiDung.CurrentItem;
            if (ofd.FileName != "")
            {
                string oldFileName = nd.HinhAnh;
                FileInfo fi = new FileInfo(ofd.FileName);
                File.Copy(fi.FullName, IMAGE_NGUOIDUNG_DIRECTORY + "\\" + fi.Name, true);
                nd.HinhAnh = fi.Name;
            }
        }

    }
}
