using PiRang_WPF.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PiRang_WPF.View
{
    /// <summary>
    /// Interaction logic for AdminDashboardWindow.xaml
    /// </summary>
    public partial class AdminDashboardWindow : Window
    {
        private string _email;

        public AdminDashboardWindow(string email)
        {
            InitializeComponent();
            _email = email;

            AdminBarangView adminBarangView = new AdminBarangView();
            ctnControl.Content = adminBarangView;
        }

        private void rbtnKelolaBarang_Checked(object sender, RoutedEventArgs e)
        {
            AdminBarangView adminBarangView = new AdminBarangView();

            ctnControl.Content = adminBarangView;
        }

        private void rbtnListPeminjaman_Checked(object sender, RoutedEventArgs e)
        {
            AdminPeminjamanBarangView adminPeminjamanBarang = new AdminPeminjamanBarangView();

            ctnControl.Content = adminPeminjamanBarang;
        }
        private void rbtnListWarga_Checked(object sender, RoutedEventArgs e)
        {
            AdminListUser adminListUser = new AdminListUser();
            ctnControl.Content = adminListUser;
        }
        
        private void rbtnPengembalian_Checked(object sender, RoutedEventArgs e)
        {
            AdminPengembalianBarang adminPengembalian = new AdminPengembalianBarang();
            ctnControl.Content = adminPengembalian;
        }
    }
}
