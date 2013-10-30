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
            dsDeThi = new ObservableCollection<DeThi>(dtBll.LayTatCa());
            dsChuDe = new ObservableCollection<ChuDe>(cdBll.LayChuDe());
            dataGridChuDe.ItemsSource = dsChuDe;
            lstBoxDeThi.ItemsSource = dsDeThi;
            chude_view = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGridChuDe.ItemsSource);
        }

        private void lstBoxDeThi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deThiHienTai = (DeThi)lstBoxDeThi.SelectedItem;
            danhSachPhanThi = ptBll.LayPhanThi(deThiHienTai.MaDe);
            chude_view.Filter = new Predicate<object>(FilterChuDe);
        }
        private bool FilterChuDe(object obj) {
            ChuDe cd = (ChuDe)obj;
            PhanThi pt = ptBll.LayPhanThiTheoMa(cd.MaPT);
            return danhSachPhanThi.IndexOf(pt) != -1;
        }
    }
}
