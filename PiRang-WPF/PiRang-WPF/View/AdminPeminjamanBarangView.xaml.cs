﻿using PiRang_WPF.DBComm;
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
    /// Interaction logic for AdminPeminjamanBarangView.xaml
    /// </summary>
    public partial class AdminPeminjamanBarangView : UserControl
    {
        public AdminPeminjamanBarangView()
        {
            InitializeComponent();

            InitializeComponent();
            NpgsqlWrapper wrapper = new NpgsqlWrapper();
            wrapper.load();
            wrapper.connect();

            DataTable dt = wrapper.GetAllPeminjamanBarang();
            if (dt.Rows.Count > 0)
            {
                List<PeminjamanBarang> barangs = PeminjamanBarangMethod.ConvertDataTableToList(dt);
                dgPeminjamanBarang.ItemsSource = barangs;
            }
            wrapper.disconnect();
        }
    }
}
