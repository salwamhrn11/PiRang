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
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();

            startWindow.Close();
        }
    }
}
