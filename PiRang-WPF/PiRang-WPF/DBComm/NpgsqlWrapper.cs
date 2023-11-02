using Npgsql;
using PiRang_WPF.View;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows;

namespace PiRang_WPF.DBComm;

public partial class NpgsqlWrapper
{
    public NpgsqlConnection connection;
    public string connString = "Host=tiny.db.elephantsql.com;Username=zyaidsdp;Password=yIDhjrN8B1jqQkE_SkNl-C3k4_Z1nn8c;Database=zyaidsdp";
    public DataTable dt;
   
    public void load()
    {
        connection = new NpgsqlConnection(connString);
    }
    public void connect()
    {
        connection.Open();
    }

    public void disconnect()
    {
        connection.Close();
    }

    public bool login(string email, string password)
    {
        load();
        try
        {
            connect();
            string sql = @"select * from get_password_by_email(:_email)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("_email", email);

            var output = cmd.ExecuteScalar();
            disconnect();
            if (Convert.IsDBNull(output))
            {
                return false;
            }
            else if ((string)output == password)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("error: " + ex.Message, "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return false;
    }
}
