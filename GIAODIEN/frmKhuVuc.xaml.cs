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
    /// Interaction logic for frmKhuVuc.xaml
    /// </summary>
    public partial class frmKhuVuc : UserControl
    {
        public string Title { get; set; }
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        private void lvDSKhuVuc_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dskv = LT_BANG.Doc("Select * from KhuVuc");

            // Clear existing items
            lvDSKhuVuc.ItemsSource = dskv.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void lvDSKhuVuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDSKhuVuc.SelectedItems.Count > 0)
            {
                DataRowView selectedRow = (DataRowView)lvDSKhuVuc.SelectedItems[0];
                int makv = (int)selectedRow.Row.ItemArray[0];

                string query = string.Format("Select * from sanpham where MakhuVuc = {0}", makv);

                DataTable dssp = LT_BANG.Doc(query);

                lbDSSanPham.Items.Clear();
                foreach (DataRow sp in dssp.Rows)
                {
                    lbDSSanPham.Items.Add(sp["TenSP"]);
                }
            }
        }
    }
}
