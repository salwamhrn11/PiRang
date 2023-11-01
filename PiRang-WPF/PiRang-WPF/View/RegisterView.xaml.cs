using Npgsql;
using PiRang_WPF.DBComm;
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
/// Interaction logic for RegisterView.xaml
/// </summary>
public partial class RegisterView : UserControl
{

    public RegisterView()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        try
        {
            wrapper.connect();
            string sql = @"select * from warga_register(:_email,:_no_hp,:_password)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, wrapper.connection);
            cmd.Parameters.AddWithValue("_email", txtEmail.Text);
            cmd.Parameters.AddWithValue("_no_hp", txtHP.Text);
            cmd.Parameters.AddWithValue("_password", txtPassword.Text);

            if ((int)cmd.ExecuteScalar() == 1)
            {
                MessageBox.Show("Register Berhasil", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                wrapper.disconnect();
            } else
            {
                wrapper.disconnect();
            }

        } 
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Register Fail", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
