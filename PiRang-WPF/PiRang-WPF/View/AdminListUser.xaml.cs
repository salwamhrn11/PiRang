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

namespace PiRang_WPF.View;

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
        NpgsqlWrapper npgsqlWrapper = new NpgsqlWrapper();
        npgsqlWrapper.load();
        npgsqlWrapper.connect();

        if (!npgsqlWrapper.AddWarga(txtEmail.Text, txtNoHp.Text, txtPassword.Text))
        {
            MessageBox.Show("Gagal menambah warga", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Berhasil menambah warga", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dgUsers.ItemsSource = npgsqlWrapper.GetAllWarga();
        }

        npgsqlWrapper.disconnect();
    }

    private void btnEditClick(object sender, RoutedEventArgs e)
    {
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        wrapper.connect();

        if (!wrapper.EditWarga(txtEmail.Text, txtNoHp.Text, txtPassword.Text))
        {
            MessageBox.Show("Gagal edit warga", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Berhasil edit warga", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        dgUsers.ItemsSource = wrapper.GetAllWarga();

        wrapper.disconnect();
    }
    private void TextBox_NumberOnly(object sender, TextCompositionEventArgs e)
    {
        if (!IsNumber(e.Text))
        {
            e.Handled = true;
        }
    }

    private bool IsNumber(string text)
    {
        // Use regular expression to check if the text is a valid integer.
        return System.Text.RegularExpressions.Regex.IsMatch(text, "^[0-9]*$");
    }

    private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MessageBox.Show("Selected Item: " + dgUsers.SelectedItem.ToString());
    }
}
