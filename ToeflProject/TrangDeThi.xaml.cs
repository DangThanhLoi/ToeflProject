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
        DeThiBLL dtBll;
        PhanThiBLL ptBll;
        ChuDeBLL cdBll;
        LoaiBLL lBll;
        ListCollectionView chude_view;
        private ObservableCollection<DeThi> dsDeThi;
        private ObservableCollection<ChuDe> dsChuDe;
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
            dsDeThi = new ObservableCollection<DeThi>(dtBll.LayTatCa());
            dsChuDe = new ObservableCollection<ChuDe>(cdBll.LayChuDe());
            cboLoai.ItemsSource = lBll.LayTatCa();
            dsChuDe.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsChuDe_CollectionChanged);
            dsDeThi.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dsDeThi_CollectionChanged);
            dataGridChuDe.ItemsSource = dsChuDe;
            lstBoxDeThi.ItemsSource = dsDeThi;
            chude_view = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGridChuDe.ItemsSource);
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
            PublicMethods.SaveChange();
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

    }
}
