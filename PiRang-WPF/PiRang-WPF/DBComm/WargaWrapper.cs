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
}
