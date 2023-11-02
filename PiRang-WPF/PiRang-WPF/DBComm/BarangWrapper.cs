using Npgsql;
using PiRang_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace PiRang_WPF.DBComm;

public partial class NpgsqlWrapper
{
    public DataTable GetAllBarang()
    {
        DataTable dataTable = new DataTable();
        try
        {
            

            string sql = @"select * from barang";
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

    public Barang GetBarangbyId(int id)
    {
        DataTable dataTable = new DataTable();
        Barang barang = new Barang
        {
            Id = 0,
            Jumlah = 0,
            NamaBarang = ""
        };
        try
        {
            string sql = @"select * from barang where id = :_id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_id", id);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            DataRow dataRow = dataTable.Rows[0];
            
            barang = new Barang
            {
                Id = Convert.ToInt32(dataRow["id"]),
                NamaBarang = dataRow["nama_barang"].ToString(),
                Jumlah = Convert.ToInt32(dataRow["jumlah"]),
            };

            return barang;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return barang;
        }
    }
}
