using Npgsql;
using PiRang_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace PiRang_WPF.DBComm;

public partial class NpgsqlWrapper
{
    public DataTable GetAllPeminjamanBarang()
    {
        DataTable dataTable = new DataTable();
        try
        {
            string sql = @"SELECT pb.id, pb.barang_id, b.nama_barang, pb.warga_email, pb.jumlah, pb.durasi_peminjaman FROM peminjaman_barang AS pb INNER JOIN barang AS b ON pb.barang_id = b.id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);

            return dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return dataTable;
        }
    }
    public DataTable GetPeminjamanBarangByEmail(string email)
    {
        DataTable dataTable = new DataTable();
        try
        {
            string sql = @"SELECT pb.id, pb.barang_id, b.nama_barang, pb.warga_email, pb.jumlah, pb.durasi_peminjaman FROM peminjaman_barang AS pb INNER JOIN barang AS b ON pb.barang_id = b.id where pb.warga_email = :_email";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_email", email);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);

            return dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return dataTable;
        }
    }

    public bool AddPeminjamanBarang(int jumlah_barang, int jumlah_pinjam, int id_barang, int durasi_peminjaman, string email)
    {
        if (jumlah_pinjam > jumlah_barang)
        {
            MessageBox.Show("Jumlah yang ingin anda pinjam melebihi jumlah barang yang tersedia.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
        try
        {
            string sql = @"select * from barang_update_jumlah(:_id,:_jumlah)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_id", id_barang);
            cmd.Parameters.AddWithValue("_jumlah", jumlah_barang - jumlah_pinjam);

            if ((int)cmd.ExecuteScalar() == 0) {
                MessageBox.Show("Terjadi error dalam update barang", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            sql = @"select * from pb_insert(:_barang_id,:_warga_email,:_durasi_peminjaman,:_jumlah)";
            cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_barang_id", id_barang);
            cmd.Parameters.AddWithValue("_warga_email", email);
            cmd.Parameters.AddWithValue("_durasi_peminjaman", durasi_peminjaman);
            cmd.Parameters.AddWithValue("_jumlah", jumlah_pinjam);

            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("Terjadi error dalam add peminjaman barang", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: ." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }

    public PeminjamanBarang GetPeminjamanBarangById(int id)
    {
        DataTable dataTable = new DataTable();
        try
        {
            string sql = @"SELECT pb.id, pb.barang_id, b.nama_barang, pb.warga_email, pb.jumlah, pb.durasi_peminjaman FROM peminjaman_barang AS pb INNER JOIN barang AS b ON pb.barang_id = b.id where pb.id = :_id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_id", id);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            foreach (DataRow row in dataTable.Rows)
            {
                PeminjamanBarang peminjamanBarang = new PeminjamanBarang
                {
                    Id = Convert.ToInt32(row["id"]),
                    BarangId = Convert.ToInt32(row["barang_id"]),
                    NamaBarang = row["nama_barang"].ToString(),
                    WargaEmail = row["warga_email"].ToString(),
                    DurasiPeminjaman = Convert.ToInt32(row["durasi_peminjaman"]),
                    Jumlah = Convert.ToInt32(row["jumlah"])
                };
                return peminjamanBarang;
            }
            return new PeminjamanBarang
            {
                Id = 0
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return new PeminjamanBarang();
        }
    }
}
