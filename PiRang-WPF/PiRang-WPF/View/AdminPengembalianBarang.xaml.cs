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
/// Interaction logic for AdminPengembalianBarang.xaml
/// </summary>
public partial class AdminPengembalianBarang : UserControl
{
    public AdminPengembalianBarang()
    {
        InitializeComponent();
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        wrapper.connect();
        dgPengembalianBarang.ItemsSource = wrapper.GetAllPengembalianBarang();
        wrapper.disconnect();
    }
    private void btnAddClick(object sender, RoutedEventArgs e)
    {
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        wrapper.connect();

        bool add_pengembalian = wrapper.AddPengembalianBarang(Convert.ToInt32(txtPeminjamanId.Text),  Convert.ToInt32(txtJumlahKembali.Text), txtKondisi.Text);
        if (add_pengembalian)
        {
            MessageBox.Show("Berhasil menambah pengembalian barang", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        } else
        {
            MessageBox.Show("Gagal menambah pengembalian barang", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        dgPengembalianBarang.ItemsSource = wrapper.GetAllPengembalianBarang();
        wrapper.disconnect();
    }

}
