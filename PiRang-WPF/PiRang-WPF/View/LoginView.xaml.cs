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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiRang_WPF.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is StartWindow startWindow)
            {
                DashboardWindow dashboardWindow = new DashboardWindow();
                dashboardWindow.Show();

                /*startWindow.Hide();*/
                startWindow.Close();
            }

            // Open the DashboardWindow
            /*DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Closed += (sender, args) =>
            {
                // Show the StartWindow when the DashboardWindow is closed
                if (Application.Current.MainWindow is StartWindow start)
                {
                    start.Show();
                }
            };

            dashboardWindow.Show();*/
        }
    }
}
