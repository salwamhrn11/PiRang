using System.Collections.Generic;
using System.Data;

namespace PiRang_WPF.Model;

public class WargaMethod
{
    public static List<Warga> ConvertDataTableToList(DataTable dataTable)
    {
        List<Warga> wargaList = new List<Warga>();
        foreach (DataRow row in dataTable.Rows)
        {
            Warga warga = new Warga
            {
                Email = row["email"].ToString(),
                NomorHp = row["no_hp"].ToString(),
                Password = row["password"].ToString()
            };
            wargaList.Add(warga);
        }
        return wargaList;
    }
}
