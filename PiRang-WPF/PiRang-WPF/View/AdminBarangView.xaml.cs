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
    /// Interaction logic for AdminBarangView.xaml
    /// </summary>
    public partial class AdminBarangView : UserControl
    {
        public AdminBarangView()
        {
            InitializeComponent();
            NpgsqlWrapper wrapper = new NpgsqlWrapper();
            wrapper.load();
            wrapper.connect();

            DataTable dt = wrapper.GetAllBarang();
            if (dt.Rows.Count > 0)
            {
                List<Barang> barangs = BarangMethod.ConvertDataTableToList(dt);
                dgBarang.ItemsSource = barangs;
            }
            wrapper.disconnect();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            NpgsqlWrapper wrapper = new NpgsqlWrapper();
            wrapper.load();
            wrapper.connect();

            bool added = wrapper.AddBarang(Convert.ToInt32(txtId.Text), txtNamaBarang.Text, Convert.ToInt32(txtJumlah.Text));
            if (!added)
            {
                MessageBox.Show("Gagal Menambah barang, pastikan Id berbeda dengan barang lain", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            MessageBox.Show("Data berhasil ditambah", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            DataTable dt = wrapper.GetAllBarang();
            if (dt.Rows.Count > 0)
            {
                List<Barang> barangs = BarangMethod.ConvertDataTableToList(dt);
                dgBarang.ItemsSource = barangs;
            }

            wrapper.disconnect();
        }

        private void btnEditClick(object sender, RoutedEventArgs e)
        {
            NpgsqlWrapper wrapper = new NpgsqlWrapper();
            wrapper.load();
            wrapper.connect();

            bool edited = wrapper.EditBarang(Convert.ToInt32(txtId.Text), txtNamaBarang.Text, Convert.ToInt32(txtJumlah.Text));
            if (!edited)
            {
                MessageBox.Show("Gagal edit barang", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            MessageBox.Show("Data berhasil diedit", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            DataTable dt = wrapper.GetAllBarang();
            if (dt.Rows.Count > 0)
            {
                List<Barang> barangs = BarangMethod.ConvertDataTableToList(dt);
                dgBarang.ItemsSource = barangs;
            }

            wrapper.disconnect();
        }
    }
}
