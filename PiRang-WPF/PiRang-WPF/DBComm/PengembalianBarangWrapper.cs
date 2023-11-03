using Npgsql;
using PiRang_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PiRang_WPF.DBComm;

public partial class NpgsqlWrapper
{
    public List<PengembalianBarang> GetAllPengembalianBarang()
    {
        List<PengembalianBarang> pengembalianBarangs = new List<PengembalianBarang>();
        try
        {
            DataTable dataTable = new DataTable();
            string sql = @"select * from pengembalian_barang";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);

            pengembalianBarangs = PengembalianBarangMethod.ConvertDataTableToList(dataTable);
            return pengembalianBarangs;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return pengembalianBarangs;
        }
    }
}