using ApplicationParameterTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ApplicationParameterTest
{
    public partial class EditParameterBool : Form
    {
        private MemoryStream ms = new();
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ApplicationParam; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private SqlCommand cmd;
        public MessagesModel messages = new();
        public CustomComboBox controls = new();

        public EditParameterBool()
        {
            InitializeComponent();
            ComboBoxInit();
            btnSaveImage.Visible = false;
            btnSaveDoc.Visible = false;
        }

        public void ComboBoxInit()
        {
            comboBoxCategory.DataSource = new BindingSource(controls.dict, null);
            comboBoxCategory.DisplayMember = "Text";
            comboBoxCategory.ValueMember = "Value";
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT imageFile FROM Prodex_ApplicationParameterData WHERE objectId=@objectId", con);
            cmd.Parameters.AddWithValue("@objectId", txtParameterId.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (pictureBox.Image == null)
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
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = @"All Files|*.txt;*.docx;*.doc;*.pdf*.xls;*.xlsx;
                                                |Text File (.txt)|*.txt;
                                                |Word File (.docx ,.doc)|*.docx;*.doc;
                                                |PDF (.pdf)|*.pdf;
                                                |Spreadsheet (.xls ,.xlsx)|*.xls ;*.xlsx;
                                                |Image Files|*.jpg;*.png;*.gif";
            DialogResult dr = openFileDialog.ShowDialog();
            
            if (dr == DialogResult.OK)
            {
                string name = openFileDialog.FileName;
                string extension = name.Substring(name.LastIndexOf("."));
                if (extension==".jpg" || extension == ".png" || extension == ".gif")
                {
                    btnSaveImage.Visible = true;
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    txtFileName.Text = openFileDialog.FileName;
                }
                else
                {
                    btnSaveDoc.Visible = true;
                    linkLabel1.Text = name;  /*name.Substring(name.LastIndexOf("\\"));*/
                }
            }
            else
            {
                return;
            }
        }

        //private void btnUploadPicture_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new();
        //    openFileDialog.Filter = "Image Files|*.jpg;*.png;*.gif";
        //    DialogResult dr = openFileDialog.ShowDialog();
        //    if (dr == DialogResult.OK)
        //    {
        //        btnSaveImage.Visible = true;
        //        pictureBox.Image = Image.FromFile(openFileDialog.FileName);
        //        txtFileName.Text = openFileDialog.FileName;
        //    }
        //    else
        //    {
        //        return;                
        //    }           
        //}

        private void btnSaveDoc_Click(object sender, EventArgs e)
        {
            string file = linkLabel1.Text;
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
            MessageBox.Show("Dokumentet är uppladdat");
            con.Close();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(imageArray, 0, imageArray.Length);
            string input = txtFileName.Text;
            input = input.Substring(input.LastIndexOf("\\"));
            string extension = new FileInfo(input).Extension;
            cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET imageFile=@imageFile, imagefileName=@imagefileName, imagefileExtension=@imagefileExtension WHERE objectId=@id", con);

            cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
            cmd.Parameters.AddWithValue("@imageFile", imageArray);
            cmd.Parameters.AddWithValue("@imagefileName", input);
            cmd.Parameters.AddWithValue("@imagefileExtension", extension);

            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageUploadPictureToDb);
            con.Close();
        }

        private void btnRemovePicture_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("Vill du ta bort bilden", "Ta bort bild", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    pictureBox.Image = null;
                    txtFileName.Text = null;
                    cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET imageFile=@imageFile, imagefileName=@imagefileName, imagefileExtension=@imagefileExtension WHERE objectId=@id", con);
                    cmd.Parameters.AddWithValue("@id", txtParameterId.Text);
                    cmd.Parameters.AddWithValue("@imageFile", SqlBinary.Null);
                    cmd.Parameters.AddWithValue("@imagefileName", txtFileName.Text);
                    cmd.Parameters.AddWithValue("@imagefileExtension", SqlBinary.Null);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Finns ingen bild uppladdad");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkboxBool.Checked == false)
            {
                checkboxBool.Text = Convert.ToString(0);
                txtStringValue.Text = "false";
            }
            else
            {
                checkboxBool.Text = Convert.ToString(1);
                txtStringValue.Text = "true";
            }

            con.Open();
            cmd = new SqlCommand("UPDATE Prodex_ApplicationParameterData  SET stringvalue=@stringvalue, numValue=@numValue, note=@note, updated=@updated, objectCategory=@objectCategory WHERE objectId=@objectId", con);
            cmd.Parameters.AddWithValue("@objectId", txtParameterId.Text);
            cmd.Parameters.AddWithValue("@stringvalue", txtStringValue.Text);
            cmd.Parameters.AddWithValue("@numValue", checkboxBool.Text);
            cmd.Parameters.AddWithValue("@note", richTextBoxnote.Text);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);
            cmd.Parameters.AddWithValue("@objectCategory", comboBoxCategory.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(messages.MessageParameterUpdatedToDb);
            con.Close();
            ActiveForm.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string name = linkLabel1.Text;
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
    }
}
