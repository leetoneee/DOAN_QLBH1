using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GIAODIEN
{
    /// <summary>
    /// Interaction logic for frmSanPham.xaml
    /// </summary>
    public partial class frmSanPham : UserControl
    {
        public string Title { get; set; }
        DataTable dssp;
        DataTable dskv;
        DataTable dslsp;

        public frmSanPham(DataTable dataTable)
        {
            this.dssp = dataTable;
            InitializeComponent();
        }

        private void frmSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            //dssp = LT_BANG.Doc("Select * from SanPham, LoaiSanPham, KhuVuc where MaLoaiSanPham = LoaiSanPham.Ma and MaKhuVuc = KhuVuc.Ma");

            // Gán DataTable làm ItemsSource cho DataGrid
            dgvDSSanPham.ItemsSource = dssp.DefaultView;

            // Ẩn các cột không cần thiết
            dgvDSSanPham.Columns[2].Visibility = Visibility.Collapsed;
            dgvDSSanPham.Columns[5].Visibility = Visibility.Collapsed;
            dgvDSSanPham.Columns[6].Visibility = Visibility.Collapsed;
            dgvDSSanPham.Columns[8].Visibility = Visibility.Collapsed;

            // Đặt tiêu đề cho các cột
            dgvDSSanPham.Columns[0].Header = "Mã";
            dgvDSSanPham.Columns[1].Header = "Tên";
            dgvDSSanPham.Columns[3].Header = "Số lượng";
            dgvDSSanPham.Columns[4].Header = "Đơn giá";
            dgvDSSanPham.Columns[7].Header = "Loại";
            dgvDSSanPham.Columns[9].Header = "Ghi chú";
            dgvDSSanPham.Columns[10].Header = "Mã Khu Vực";
            dgvDSSanPham.Columns[11].Header = "Tên Khu Vực";
            dgvDSSanPham.Columns[12].Header = "Ghi chú";

            dskv = LT_BANG.Doc("Select * from KhuVuc");
            cbKhuVuc.ItemsSource = dskv.DefaultView;
            cbKhuVuc.SelectedValuePath = "Ma";
            cbKhuVuc.DisplayMemberPath = "Ten";

            dslsp = LT_BANG.Doc("Select * from KhuVuc");
            cbLoai.ItemsSource = dslsp.DefaultView;
            cbLoai.SelectedValuePath = "Ma";
            cbLoai.DisplayMemberPath = "Ten";
        }
    }
}
