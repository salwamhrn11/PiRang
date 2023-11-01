using Npgsql;
using PiRang_WPF.DBComm;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiRang_WPF.View;

/// <summary>
/// Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : UserControl
{
    private readonly INavigationService _navigationService; // Ensure you have access to the navigation service

    public LoginView(INavigationService navigationService)
    {
        InitializeComponent();
        _navigationService = navigationService; // Store the navigation service
    }
    public LoginView()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow is StartWindow startWindow)
        {
            if (txtEmail.Text == "admin@admin.com" && txtPassword.Text == "admin")
            {
                AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow(txtEmail.Text);
                adminDashboardWindow.Show();

                startWindow.Close();
            } else
            {
                NpgsqlWrapper wrapper = new NpgsqlWrapper();
                bool logon = wrapper.login(txtEmail.Text, txtPassword.Text);
                if (logon)
                {
                    MessageBox.Show("Login Berhasil", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    DashboardWindow dashboardWindow = new DashboardWindow();
                    dashboardWindow.Show();

                    startWindow.Close();
                } else
                {
                    MessageBox.Show("Pastikan Email dan Password Sudah Benar", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
