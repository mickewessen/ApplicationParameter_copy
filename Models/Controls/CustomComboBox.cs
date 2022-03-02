using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ApplicationParameterTest.Models
{
    public class CustomComboBox
    {
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ApplicationParam; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Dictionary<string, string> dict2 = new Dictionary<string, string>();
        public Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            {"Visa/Dölj kontroller","Visa/Dölj kontroller" },
            {"Maskininställningar","Maskininställningar" },
            {"Email","Email" },
            {"Movex","Movex" },
            {"Utskrift","Utskrift" },
            {"Tidsintervall","Tidsintervall" },
            {"Tabellinställningar","Tabellinställningar" },
            {"Intag","Intag" },
            {"Maskinrecept","Maskinrecept" },
            {"Planeringsgrupper","Planeringsgrupper" },
            {"Färdigställning","Färdigställning" },
            {"ITAG","ITAG" },
            {"Skift","Skift" },
            {"Övrigt","Övrigt" },
            {"Watchdog","Watchdog" },
            {"Okategoriserade", "Okategoriserade"}
        };

        public void LoadCombo()
        {
            string sqlQuery = "Select Distinct [objectCategory] As objectCategory FROM Prodex_ApplicationParameterData";
            con.Open();
            SqlCommand cmd = new(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dict2.Add(dr.GetString(0), dr.GetString(0));
            }
        }
    }
}