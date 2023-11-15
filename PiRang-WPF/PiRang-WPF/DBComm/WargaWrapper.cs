using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;
using PiRang_WPF.Model;

namespace PiRang_WPF.DBComm;

public partial class NpgsqlWrapper
{
    public List<Warga> GetAllWarga()
    {
        List<Warga> wargaList = new List<Warga>();
        try
        {
            DataTable dataTable = new DataTable();
            string sql = @"select * from warga";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            
            wargaList = WargaMethod.ConvertDataTableToList(dataTable);
            return wargaList;
        } 
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            return wargaList;
        }
    }

    public bool AddWarga(string email, string no_hp, string password)
    {
        try
        {
            string sql = @"select * from warga_insert(:_email,:_no_hp,:_password)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_no_hp", no_hp);
            cmd.Parameters.AddWithValue("_password", password);

            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("Terjadi error dalam add warga", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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

    public bool EditWarga(string email, string no_hp, string password)
    {
        try
        {
            string sql = @"select * from warga_update(:_email,:_no_hp,:_password)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_no_hp", no_hp);
            cmd.Parameters.AddWithValue("_password", password);

            if ((int)cmd.ExecuteScalar() == 0)
            {
                MessageBox.Show("Terjadi error dalam edit warga", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
}
