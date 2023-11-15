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

    public bool AddPengembalianBarang(int barang_id, string email, int jumlah_kembali, string kondisi_barang, int jumlah_dipinjam)
    {
        try
        {
            string sql = @"select * from pengembalian_insert(:_barang_id,:_email,:_jumlah_kembali,:_kondisi_barang,:_jumlah_dipinjam)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_barang_id", barang_id);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_jumlah_kembali", jumlah_kembali);
            cmd.Parameters.AddWithValue("_kondisi_barang", kondisi_barang);
            cmd.Parameters.AddWithValue("_jumlah_dipinjam", jumlah_dipinjam);

            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("Terjadi error dalam add barang", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }
}