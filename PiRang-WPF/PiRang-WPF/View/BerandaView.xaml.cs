using Npgsql;
using PiRang_WPF.DBComm;
using PiRang_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
/// Interaction logic for BerandaView.xaml
/// </summary>
public partial class BerandaView : UserControl
{
    private string _email;
    public BerandaView(string email)
    {
        InitializeComponent();

        _email = email;
        NpgsqlWrapper wrapper = new NpgsqlWrapper();
        wrapper.load();
        wrapper.connect();

        DataTable dt = wrapper.GetAllBarang();
        if (dt.Rows.Count > 0 )
        {
            List<Barang> barangs = BarangMethod.ConvertDataTableToList(dt);
            dgBarang.ItemsSource = barangs;
        }
        wrapper.disconnect();
    }
}