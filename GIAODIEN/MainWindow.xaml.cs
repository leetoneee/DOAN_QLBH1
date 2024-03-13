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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dssp = LT_BANG.Doc("Select * from SanPham, LoaiSanPham, KhuVuc where MaLoaiSanPham = LoaiSanPham.Ma and MaKhuVuc = KhuVuc.Ma");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DisplayKhuVuc(string title, UserControl content)
        {
            foreach (TabItem tabItemExist in mdiContainer.Items)
            {
                if (tabItemExist.Header.ToString() == title)
                {
                    // Nếu tồn tại, chọn TabItem đó và thoát phương thức
                    mdiContainer.SelectedItem = tabItemExist;
                    return;
                }
            }

            var child = new frmKhuVuc { Title = title };
            child.Content = content;

            //mdiContainer.Children.Add(child);
            var tabItem = new TabItem { Header = title };
            tabItem.Content = child;

            mdiContainer.Items.Add(tabItem);
            mdiContainer.SelectedItem = tabItem;
        }

        private void DisplaySanPham(string title, UserControl content)
        {
            foreach (TabItem tabItemExist in mdiContainer.Items)
            {
                if (tabItemExist.Header.ToString() == title)
                {
                    // Nếu tồn tại, chọn TabItem đó và thoát phương thức
                    mdiContainer.SelectedItem = tabItemExist;
                    return;
                }
            }

            var child = new frmSanPham(dssp) { Title = title };
            child.Content = content;

            //mdiContainer.Children.Add(child);
            var tabItem = new TabItem { Header = title };
            tabItem.Content = child;

            mdiContainer.Items.Add(tabItem);
            mdiContainer.SelectedItem = tabItem;
        }

        private void DisplayBanHang(string title, UserControl content)
        {
            foreach (TabItem tabItemExist in mdiContainer.Items)
            {
                if (tabItemExist.Header.ToString() == title)
                {
                    // Nếu tồn tại, chọn TabItem đó và thoát phương thức
                    mdiContainer.SelectedItem = tabItemExist;
                    return;
                }
            }

            var child = new frmBanHang(dssp) { Title = title };
            child.Content = content;

            //mdiContainer.Children.Add(child);
            var tabItem = new TabItem { Header = title };
            tabItem.Content = child;

            mdiContainer.Items.Add(tabItem);
            mdiContainer.SelectedItem = tabItem;
        }

        private void KhuVuc_Click(object sender, RoutedEventArgs e)
        {
            DisplayKhuVuc("KhuVuc", new frmKhuVuc { Title = "KhuVuc" });
        }

        private void SanPham_Click(object sender, RoutedEventArgs e)
        {
            DisplaySanPham("SanPham", new frmSanPham(dssp) { Title = "SanPham" });
        }

        private void BanHang_Click(object sender, RoutedEventArgs e)
        {
            DisplayBanHang("BanHang", new frmBanHang(dssp) { Title = "BanHang" });
        }
    }
}
