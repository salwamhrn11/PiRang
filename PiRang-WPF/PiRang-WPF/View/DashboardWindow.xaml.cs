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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private string _email;

        public DashboardWindow(string email)
        {
            InitializeComponent();
            _email = email;
            BerandaView berandaView = new BerandaView(_email);

            // Set BerandaView as the content of the ContentControl
            contentControl.Content = berandaView;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void berandaChecked(object sender, RoutedEventArgs e) 
        {
            BerandaView berandaView = new BerandaView(_email);

            // Set BerandaView as the content of the ContentControl
            contentControl.Content = berandaView;
        }

        private void listPeminjamanChecked(object sender, RoutedEventArgs e)
        {
            ListPeminjamanView listPeminjamanView = new ListPeminjamanView(_email);
            contentControl.Content = listPeminjamanView;
        }

        private void peminjamanChecked(object sender, RoutedEventArgs e)
        {
            PeminjamanView peminjamanView = new PeminjamanView(_email);
            contentControl.Content = peminjamanView;
        }
    }
}
