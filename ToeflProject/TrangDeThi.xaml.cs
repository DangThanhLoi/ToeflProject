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
using System.Collections.ObjectModel;
using DAL;
using BLL;
namespace ToeflProject
{
    /// <summary>
    /// Interaction logic for TrangDeThi.xaml
    /// </summary>
    public partial class TrangDeThi : Window
    {
        CauHoiBLL chBll;
        DeThiBLL dtBll;
        PhanThiBLL ptBll;
        ChuDeBLL cdBll;
        LoaiBLL lBll;
        ListCollectionView chude_view, cauhoi_view;
        private ObservableCollection<DeThi> dsDeThi;
        private ObservableCollection<ChuDe> dsChuDe;
        private ObservableCollection<CauHoi> dsCauHoi;
        DeThi deThiHienTai;
        List<PhanThi> danhSachPhanThi;
        public TrangDeThi()
        {
            InitializeComponent();
            MyInitialization();
        }
        public void MyInitialization() {
            dtBll = new DeThiBLL();
            ptBll = new PhanThiBLL();
            cdBll = new ChuDeBLL();
            lBll = new LoaiBLL();
            chBll = new CauHoiBLL();
            dsDeThi = new ObservableCollection<DeThi>(dtBll.LayTatCa());
            dsChuDe = new ObservableCollection<ChuDe>(cdBll.LayChuDe());
            dsCauHoi = new ObservableCollection<CauHoi>(chBll.LayTatCa());
            cboLoai.ItemsSource = lBll.LayTatCa();
            lstCauHoi.ItemsSource = dsCauHoi;
            dsChuDe.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsChuDe_CollectionChanged);
            dsDeThi.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsDeThi_CollectionChanged);
            dsCauHoi.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsCauHoi_CollectionChanged);
            dataGridChuDe.ItemsSource = dsChuDe;
            lstBoxDeThi.ItemsSource = dsDeThi;
            chude_view = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGridChuDe.ItemsSource);
            cauhoi_view = (ListCollectionView)CollectionViewSource.GetDefaultView(lstCauHoi.ItemsSource);
        }

        void dsCauHoi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        chBll.ThemCauHoi(item as CauHoi);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        chBll.XoaCauHoi(item as CauHoi);
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

        void dsDeThi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        dtBll.ThemDeThi(item as DeThi);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        dtBll.XoaDeThi(item as DeThi);
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

        void dsChuDe_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        cdBll.ThemChuDe(item as ChuDe);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        cdBll.XoaChuDe(item as ChuDe);
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

        private void lstBoxDeThi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBoxDeThi.SelectedIndex != -1)
            {
                deThiHienTai = (DeThi)lstBoxDeThi.SelectedItem;
                danhSachPhanThi = ptBll.LayPhanThi(deThiHienTai.MaDe);
                chude_view.Filter = new Predicate<object>(FilterChuDe);
            }
        }
        private bool FilterChuDe(object obj) {
            ChuDe cd = (ChuDe)obj;
            PhanThi pt = ptBll.LayPhanThiTheoMa(cd.MaPT);
            return danhSachPhanThi.IndexOf(pt) != -1;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn lưu thay đổi?", "Lưu Thay đổi", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                PublicMethods.SaveChange();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnThemDeThi_Click(object sender, RoutedEventArgs e)
        {
            DeThi dt = new DeThi { NgayThi = DateTime.Now };
            dt.PhanThis = new System.Data.Linq.EntitySet<PhanThi>();
            dsDeThi.Add(dt);
            for (int i = 1; i < 5; i++) {
                PhanThi pt = new PhanThi { MaDe = dt.MaDe, MaLoai = i };
                dt.PhanThis.Add(pt);
            }
            PublicMethods.SaveChange();
        }

        private void btnXoaDeThi_Click(object sender, RoutedEventArgs e)
        {
            dsDeThi.Remove(lstBoxDeThi.SelectedItem as DeThi);
            
        }

        private void dataGridChuDe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DragDrop.DoDragDrop(dg, dg.SelectedItem as ChuDe, DragDropEffects.Copy);
        }

        private void btnThemCauHoi_Click(object sender, RoutedEventArgs e)
        {
            ChuDe cd = dataGridChuDe.SelectedItem as ChuDe;
            if (cd != null)
            {
                CauHoi ch = new CauHoi { NoiDung = @"Nội dung câu hỏi", MaCD = cd.MaCD };
                ch.DapAns = new System.Data.Linq.EntitySet<DapAn>();
                dsCauHoi.Add(ch);
            }
            else {
                MessageBox.Show("Chưa chọn chủ đề cho câu hỏi!", "Chưa chọn chủ đề", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnXoaCauHoi_Click(object sender, RoutedEventArgs e)
        {
            if (lstCauHoi.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn câu hỏi để xóa!", "Chưa chọn câu hỏi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else {
                dsCauHoi.Remove(lstCauHoi.SelectedItem as CauHoi);
            }
        }

        private void lstCauHoi_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
        }

        private void dataGridChuDe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridChuDe.SelectedIndex != -1) {
                cauhoi_view.Filter = new Predicate<object>(FilterCauHoi);
            }
        }
        public bool FilterCauHoi(Object obj) {
            ChuDe cd = dataGridChuDe.SelectedItem as ChuDe;
            CauHoi ch = obj as CauHoi;
            return cd.CauHois.IndexOf(ch) != -1;
        }

    }
}
