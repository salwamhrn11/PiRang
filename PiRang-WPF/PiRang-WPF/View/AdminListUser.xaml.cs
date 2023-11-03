using PiRang_WPF.DBComm;
using PiRang_WPF.Model;
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

namespace PiRang_WPF.View
{
    /// <summary>
    /// Interaction logic for AdminListUser.xaml
    /// </summary>
    public partial class AdminListUser : UserControl
    {
        public AdminListUser()
        {
            InitializeComponent();
            NpgsqlWrapper wrapper = new NpgsqlWrapper();
            wrapper.load();
            wrapper.connect();
            dgUsers.ItemsSource = wrapper.GetAllWarga();
            wrapper.disconnect();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
        }

        private void btnEditClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
