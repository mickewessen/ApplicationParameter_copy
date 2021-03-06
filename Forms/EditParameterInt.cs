using ApplicationParameterTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ApplicationParameterTest
{
    public partial class EditParameterInt : Form
    {
        private MemoryStream ms = new();
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ApplicationParam; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private SqlCommand cmd;
        public MessagesModel messages = new();
        public CustomComboBox controls = new();
        public Dictionary<string, string> categoryList = new Dictionary<string, string>();


        public EditParameterInt()
        {
            InitializeComponent();
            ComboBoxInit();

        }
        private void IntPropertyForm_Load(object sender, EventArgs e)
        {
            
            ButtonIcon();
            ShowButtons();
            Text = txtParameterId.Text;
        }
        public void ComboBoxInit()
        {
            string sqlQuery = "Select Distinct [objectCategory] As objectCategory FROM Prodex_ApplicationParameterData";
            con.Open();
            SqlCommand cmd = new(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                categoryList.Add(dr.GetString(0), dr.GetString(0));
            }
            comboBoxCategory.DataSource = new BindingSource(categoryList, null);
            comboBoxCategory.DisplayMember = "Text";
            comboBoxCategory.ValueMember = "Value";
            con.Close();
        }
        public void ButtonIcon()
        {
            btnInfo.Image = new Bitmap(myImages.info_icon, new Size(20, 20));
            btnBroweseDocument.Image = new Bitmap(myImages.browse_icon, new Size(20, 20));
            btnBrowseImage.Image = new Bitmap(myImages.browse_icon, new Size(20, 20));
            btnSaveImage.Image = new Bitmap(myImages.green_checkmark, new Size(16, 16));
            btnRemoveImage.Image = new Bitmap(myImages.redcross, new Size(16, 16));
            btnSaveDoc.Image = new Bitmap(myImages.green_checkmark, new Size(16, 16));
            btnRemoveDocument.Image = new Bitmap(myImages.redcross, new Size(16, 16));
        }
        public void ShowButtons()
        {
            btnSaveImage.Visible = false;
            btnSaveDoc.Visible = false;
            btnRemoveDocument.Visible = false;
            btnRemoveImage.Visible = false;

            if (linkLabelDoc.Text.Contains(txtParameterId.Text))
            {
                btnRemoveDocument.Visible = true;                
            }
            if (linkLabelImage.Text.Contains(txtParameterId.Text))
            {
                btnRemoveImage.Visible = true;
            }
        }
        private void BrowseDocument(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = @"All Files|*.txt;*.docx;*.doc;*.pdf*.xls;*.xlsx;";
            DialogResult dr = openFileDialog.ShowDialog();
            string name = openFileDialog.FileName;
            if (dr == DialogResult.OK)
            {
                btnSaveDoc.Visible = true;
                linkLabelDoc.Text = name;
            }
            else
            {
                return;
            }
        }
        private void BrowseImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = @"Image Files|*.jpg;*.png;*.gif";
            DialogResult dr = openFileDialog.ShowDialog();
            string name = openFileDialog.FileName;
            if (dr == DialogResult.OK)
            {
                btnSaveImage.Visible = true;
                linkLabelImage.Text = name;
            }
            else
            {
                return;
            }
        }        
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            string file = linkLabelImage.Text;
            string extension = new FileInfo(file).Extension;
            string fileNameToDb = txtParameterId.Text + extension;
            byte[] imageArray = File.ReadAllBytes(file);

            cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET imageFile=@imageFile, imagefileName=@imagefileName, imagefileExtension=@imagefileExtension WHERE objectId=@id", con);

            cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
            cmd.Parameters.AddWithValue("@imageFile", imageArray);
            cmd.Parameters.AddWithValue("@imagefileName", fileNameToDb);
            cmd.Parameters.AddWithValue("@imagefileExtension", extension);

            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageUploadPictureToDb);
            con.Close();
            btnSaveImage.Visible = false;
            btnRemoveImage.Visible = true;
        }
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du ta bort bilden", "Ta bort bild", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET imageFile=@imageFile, imagefileName=@imagefileName, imagefileExtension=@imagefileExtension WHERE objectId=@id", con);
                cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
                cmd.Parameters.AddWithValue("@imageFile", SqlBinary.Null);
                cmd.Parameters.AddWithValue("@imagefileName", SqlBinary.Null);
                cmd.Parameters.AddWithValue("@imagefileExtension", SqlBinary.Null);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                linkLabelImage.Text = null;
                ShowButtons();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }
        private void btnSaveDoc_Click(object sender, EventArgs e)
        {
            string file = linkLabelDoc.Text;
            string extension = new FileInfo(file).Extension;
            string fileNameToDb = txtParameterId.Text + extension;
            byte[] document = File.ReadAllBytes(file);
            con.Open();
            cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData SET documentFile=@documentFile, documentfileName=@documentfileName, documentfileExtension=@documentfileExtension WHERE objectId=@id", con);
            cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
            cmd.Parameters.AddWithValue("@documentFile", document);
            cmd.Parameters.AddWithValue("@documentfileName", fileNameToDb);
            cmd.Parameters.AddWithValue("@documentfileExtension", extension);
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageUploadDocumentToDb);
            con.Close();
            btnSaveDoc.Visible = false;
            btnRemoveDocument.Visible = true;
        }
        private void btnRemoveDocument_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du ta bort dokumentet", "Ta bort dokument", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET documentFile=@documentFile, documentfileName=@documentfileName, documentfileExtension=@documentfileExtension WHERE objectId=@id", con);
                cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
                cmd.Parameters.AddWithValue("@documentFile", SqlBinary.Null);
                cmd.Parameters.AddWithValue("@documentfileName", SqlBinary.Null);
                cmd.Parameters.AddWithValue("@documentfileExtension", SqlBinary.Null);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                linkLabelDoc.Text = null;
                ShowButtons();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET stringvalue=@stringvalue, numValue=@numValue, note=@note, updated=@updated, objectSwedishTitle=@objectSwedishTitle, objectCategory=@objectCategory WHERE objectId=@objectId", con);
            cmd.Parameters.AddWithValue("@objectId", txtParameterId.Text);
            cmd.Parameters.AddWithValue("@stringvalue", txtboxnumValue.Text);
            cmd.Parameters.AddWithValue("@numValue", txtboxnumValue.Text);
            cmd.Parameters.AddWithValue("@note", richTextBoxnote.Text);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);
            cmd.Parameters.AddWithValue("@objectSwedishTitle", txtParameterNameSwe.Text);
            cmd.Parameters.AddWithValue("@objectCategory", comboBoxCategory.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageParameterUpdatedToDb);
            con.Close();
            ActiveForm.Close();
        }
        private void linkLabelDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = linkLabelDoc.Text;
            string extension = name.Substring(name.LastIndexOf("."));
            FileStream fs = null;
            byte[] dbbyte;

            con.Open();
            cmd = new SqlCommand("SELECT documentFile FROM Prodex_ApplicationParameterData WHERE objectId=@objectId", con);
            cmd.Parameters.AddWithValue("@objectId", txtParameterId.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                dbbyte = (byte[])dt.Rows[0]["documentFile"];
                string filepath = Path.Combine(Path.GetTempPath(), $"{txtParameterId.Text}{extension}");
                fs = new FileStream(filepath, FileMode.Create);
                fs.Write(dbbyte, 0, dbbyte.Length);
                fs.Dispose();
                fs.Close();
                Process proc = new();

                proc.StartInfo = new ProcessStartInfo(filepath)
                {
                    UseShellExecute = true
                };
                proc.Start();
            }
            con.Close();
        }
        private void linkLabelImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmd = new SqlCommand("SELECT imageFile FROM Prodex_ApplicationParameterData WHERE objectId=@objectId", con);
            cmd.Parameters.AddWithValue("@objectId", txtParameterId.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (linkLabelImage.Text == null)
                {
                    MessageBox.Show(messages.MessageNoPictureExist);
                }
                else
                {
                    byte[] data = (byte[])dr["imageFile"];
                    ms = new MemoryStream(data);
                    Form form = new();
                    PictureBox pb = new();

                    pb.Image = Image.FromStream(ms);
                    pb.Dock = DockStyle.Fill;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    form.Controls.Add(pb);
                    form.Size = new Size(900, 900);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.WindowState = FormWindowState.Normal;
                    form.ShowDialog();
                }
            }
            con.Close();
        }

    }
}