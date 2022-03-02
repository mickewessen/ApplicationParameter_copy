using ApplicationParameterTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationParameterTest.Forms
{
    public partial class ButtonFormOn : Form
    {

        public MessagesModel messages = new();
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ApplicationParam; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private SqlCommand cmd;


        public ButtonFormOn()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Update Prodex_ApplicationParameterData SET stringValue= 'true', numValue= '1', updated= '" + DateTime.Now + "' where objectId='" + txtboxParameter.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageParameterUpdatedToDb);
            ActiveForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}
