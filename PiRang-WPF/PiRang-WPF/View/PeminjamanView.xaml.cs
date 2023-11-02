using PiRang_WPF.DBComm;
using PiRang_WPF.Model;
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
/// Interaction logic for PeminjamanView.xaml
/// </summary>
public partial class PeminjamanView : UserControl
{
    private string _email;
    public PeminjamanView(string email)
    {
        InitializeComponent();
        _email = email;

        txtEmail.Text = email;
    }

    private void btnLogin_Click_1(object sender, RoutedEventArgs e)
    {
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        wrapper.connect();

        Barang barang = wrapper.GetBarangbyId(Convert.ToInt32(txtId.Text));
        if (barang.Id == 0)
        {
            MessageBox.Show("ID Barang tidak valid.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            if (wrapper.AddPeminjamanBarang(barang.Jumlah, Convert.ToInt32(txtJumlah.Text), Convert.ToInt32(txtId.Text), Convert.ToInt32(txtDurasi.Text), _email))
            {
                MessageBox.Show("Berhasil menambah barang", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
            else
            {
                MessageBox.Show("Gagal menambah barang", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


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

}
