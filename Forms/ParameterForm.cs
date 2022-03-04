using ApplicationParameterTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ApplicationParameterTest.Forms;
using System.Linq;
using System.Globalization;
using System.IO;

namespace ApplicationParameterTest
{
    public partial class ParameterForm : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ApplicationParam; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public CustomComboBox comboBox =new();
        public MemoryStream ms;
        public MessagesModel messages;
        public List<ColumnName> columnNames;
        public DataGridView view { get; set; }

        public ParameterForm()
        {   
            InitializeComponent();
            tcApplicationParam.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public class ColumnName
        {
            public int ColumnIndex { get; set; }
            public string ColumnNames { get; set; }
        }

        public void AppParamForm_Load(object sender, EventArgs e)
        {
            comboBox.Load();
            CreateTabPagesDynamically();
            FillDataDynamically();
        }

        #region Buttons
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            tcApplicationParam.Controls.Clear();
            CreateTabPagesDynamically();
            FillDataDynamically();
        }
        #endregion

        #region Tabs and datatables 
        public void CreateTabPagesDynamically()
        { 
            con.Open();            
            SqlDataAdapter sda = new("SELECT DISTINCT objectCategory FROM Prodex_ApplicationParameterData", con);
            DataTable dataTable = new();
            sda.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                var tabPage = new TabPage(dr["objectCategory"].ToString());
                tabPage.Tag = dr["objectCategory"].ToString();            
                tcApplicationParam.TabPages.Add(tabPage);
            }
            con.Close();
        }
        public void FillDataDynamically()
        {
            foreach (TabPage page in tcApplicationParam.TabPages)
            {
                con.Open();
                SqlDataAdapter sdaCurrentCategory = new SqlDataAdapter("SELECT * FROM Prodex_ApplicationParameterData WHERE objectCategory ='" + page.Tag + "'", con);
                DataTable dtByCategory = new DataTable();
                sdaCurrentCategory.Fill(dtByCategory);
                con.Close();

                view = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    Name = "dgw_" + page.Tag.ToString(),
                    RowHeadersVisible = false,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AllowUserToAddRows = false,
                    AllowUserToOrderColumns = false
                };
                page.Controls.Add(view);

                view.DataSource = dtByCategory;
                if (string.IsNullOrWhiteSpace(page.Text))
                {
                    page.Text = $"Okategoriserade - ({ view.RowCount})";
                }
                else
                {
                    page.Text = $"{page.Text} - ({view.Rows.Count})";
                }

                for (int i = 0; i < view.Columns.Count; i++)
                {
                    SetColumnNames(view);
                    SortColumns(view);
                    HideColumns(view);
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                view.CellDoubleClick += CellDoubleClick;
                view.CellFormatting += CellPainting;
                AddImageColumn(view);
            }
        }
        private void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (sender as DataGridView);
            if (view.CurrentRow.Cells["propertyId"].Value.ToString().Contains("char"))
            {
                if (view.CurrentRow.Cells["stringValue"].Value.ToString().ToLower().Contains("true") || view.CurrentRow.Cells["stringValue"].Value.ToString().ToLower().Contains("false"))
                {
                    EditParameterBool form = new EditParameterBool();
                    if (view.SelectedRows != null)
                    {
                        form.txtParameterId.Text = view.CurrentRow.Cells["objectId"].Value.ToString();
                        form.txtParameterNameSwe.Text = view.CurrentRow.Cells["objectSwedishTitle"].Value.ToString();
                        form.txtStringValue.Text = view.CurrentRow.Cells["stringValue"].Value.ToString();
                        form.comboBoxCategory.Text = view.CurrentRow.Cells["objectCategory"].Value.ToString();
                        form.txtboxUpdatedBy.Text = view.CurrentRow.Cells["updatedUser"].Value.ToString();
                        form.txtUpdatedTime.Text = view.CurrentRow.Cells["updated"].Value.ToString();
                        form.richTextBoxnote.Text = view.CurrentRow.Cells["note"].Value.ToString();
                        form.linkLabelImage.Text = view.CurrentRow.Cells["imagefileName"].Value.ToString();
                        form.linkLabelDoc.Text = view.CurrentRow.Cells["documentfileName"].Value.ToString();
                        if (view.CurrentRow.Cells["stringValue"].Value.ToString().ToLower().Contains("true"))
                        {
                            form.checkboxBool.Checked = true;
                        }
                        var img = view.CurrentRow.Cells["imageFile"].Value == DBNull.Value ? null : (byte[])view.CurrentRow.Cells["imageFile"].Value;
                        if (img != null)
                        {
                            Byte[] data = new Byte[0];
                            data = (Byte[])(view.CurrentRow.Cells["imageFile"].Value);
                            ms = new MemoryStream(data);
                        }
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show(messages.MessageEmptyRow);
                }
                else
                {
                    EditParameterList form = new();
                    if (view.SelectedRows != null)
                    {
                        form.txtParameterId.Text = view.CurrentRow.Cells["objectId"].Value.ToString();
                        form.txtParameterNameSwe.Text = view.CurrentRow.Cells["objectSwedishTitle"].Value.ToString();
                        form.txtStringValue.Text = view.CurrentRow.Cells["stringValue"].Value.ToString();
                        form.txtboxnumValue.Text = view.CurrentRow.Cells["numValue"].Value.ToString();
                        form.comboBoxCategory.Text = view.CurrentRow.Cells["objectCategory"].Value.ToString();
                        form.txtboxUpdatedBy.Text = view.CurrentRow.Cells["updatedUser"].Value.ToString();
                        form.txtUpdatedTime.Text = view.CurrentRow.Cells["updated"].Value.ToString();
                        form.richTextBoxnote.Text = view.CurrentRow.Cells["note"].Value.ToString();
                        form.linkLabelImage.Text = view.CurrentRow.Cells["imagefileName"].Value.ToString();
                        form.linkLabelDoc.Text = view.CurrentRow.Cells["documentfileName"].Value.ToString();

                        var listOfStrings = view.CurrentRow.Cells["stringValue"].Value.ToString();
                        var separatedList = listOfStrings.Split(';');
                        foreach (var item in separatedList)
                        {
                            form.semicolonList.Items.Add(item);
                        }
                        var img = view.CurrentRow.Cells["imageFile"].Value == DBNull.Value ? null : (byte[])view.CurrentRow.Cells["imageFile"].Value;
                        if (img != null)
                        {
                            Byte[] data = new Byte[0];
                            data = (Byte[])(view.CurrentRow.Cells["imageFile"].Value);
                            ms = new MemoryStream(data);

                        }
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show(messages.MessageEmptyRow);
                }
            }
            else if (view.CurrentRow.Cells["propertyId"].Value.ToString().Contains("int"))
            {
                EditParameterInt form = new EditParameterInt();
                if (view.SelectedRows != null)
                {
                    form.txtParameterId.Text = view.CurrentRow.Cells["objectId"].Value.ToString();
                    form.txtParameterNameSwe.Text = view.CurrentRow.Cells["objectSwedishTitle"].Value.ToString();
                    form.txtStringValue.Text = view.CurrentRow.Cells["stringValue"].Value.ToString();
                    form.txtboxnumValue.Text = view.CurrentRow.Cells["numValue"].Value.ToString();
                    form.comboBoxCategory.Text = view.CurrentRow.Cells["objectCategory"].Value.ToString();
                    form.txtboxUpdatedBy.Text = view.CurrentRow.Cells["updatedUser"].Value.ToString();
                    form.txtUpdatedTime.Text = view.CurrentRow.Cells["updated"].Value.ToString();
                    form.richTextBoxnote.Text = view.CurrentRow.Cells["note"].Value.ToString();
                    form.linkLabelImage.Text = view.CurrentRow.Cells["imagefileName"].Value.ToString();
                    form.linkLabelDoc.Text = view.CurrentRow.Cells["documentfileName"].Value.ToString();

                    var img = view.CurrentRow.Cells["imageFile"].Value == DBNull.Value ? null : (byte[])view.CurrentRow.Cells["imageFile"].Value;
                    if (img != null)
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(view.CurrentRow.Cells["imageFile"].Value);
                        ms = new MemoryStream(data);
                    }
                    form.ShowDialog();
                }
                else
                    MessageBox.Show(messages.MessageEmptyRow);
            }
        }
        #endregion

        #region Column & TabSettings
        public void SetColumnNames(DataGridView view)
        {
            columnNames = new List<ColumnName>()
            {
               new ColumnName()
                {
                    ColumnNames = "Kategori",
                    ColumnIndex = 21,
                },
                new ColumnName()
                {
                    ColumnNames = "Namn",
                    ColumnIndex = 20,
                },
                new ColumnName()
                {
                    ColumnNames = "Id",
                    ColumnIndex = 1,
                },
                new ColumnName()
                {
                    ColumnNames = "Variabel",
                    ColumnIndex = 2,
                },
                new ColumnName()
                {
                    ColumnNames = "Strängvärde",
                    ColumnIndex = 4,
                },
                new ColumnName()
                {
                    ColumnNames = "Numeriskt värde",
                    ColumnIndex = 5,
                },
                new ColumnName()
                {
                    ColumnNames = "Anteckningar",
                    ColumnIndex = 6,
                },
                new ColumnName()
                {
                    ColumnNames = "Uppdaterad",
                    ColumnIndex = 12,
                },
                new ColumnName()
                {
                    ColumnNames = "Användare",
                    ColumnIndex = 13,
                },
            };
            foreach (var name in columnNames)
            {
                view.Columns[name.ColumnIndex].HeaderText = name.ColumnNames;
            }
        }
        public void SortColumns(DataGridView view)
        {
            int[] sortColumns = new int[] { 21, 20 };
            foreach (int i in sortColumns)
            {
                view.Columns[i].DisplayIndex = 0;
                view.Columns[i].DisplayIndex = 1;
            }
        }
        public void HideColumns(DataGridView view)
        {
            int[] hideColumns = new int[] { 0, 3, 7, 8, 9, 10, 11, 14, 15, 16, 17, 18, 19 };
            foreach (int i in hideColumns)
            {
                view.Columns[i].Visible = false;
            }
        }
        public void AddImageColumn(DataGridView view)
        {
            view.Columns.Add(new DataGridViewImageColumn()
            {
                Name = "Status",
                HeaderText = "Status",
                DisplayIndex = 0,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Image = new Bitmap(myImages.green_icon, Height = 16, Width = 16)
            });
        }
        private void CellPainting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView view = (sender as DataGridView);
            if (view.Columns[e.ColumnIndex].Name == "Status")
            {
                if (view["stringValue", e.RowIndex].Value != null)
                {
                    string s = view["stringValue", e.RowIndex].Value.ToString().ToLower();
                    switch (s)
                    {
                        //case "true":
                        //    e.Value = myImages.circle_16;
                        //    break;

                        case "false":
                            e.Value = new Bitmap(myImages.red_icon24, Height = 16, Width = 16);
                            break;
                            //case "Yes":
                            //    e.Value = myImages.circle_16;
                            //    break;
                            //case "1":
                            //    e.Value= myImages.circle_16;
                            //    break;
                            //case "0":
                            //    e.Value = myImages.redcircle_16;
                            //    break;
                    }
                }
            }            
        }
        private void tcApplicationParam_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font tabFont;
            Brush tabBack;
            Brush tabFront;

            if (e.Index == tcApplicationParam.SelectedIndex)
            {
                tabFont = new Font(e.Font, FontStyle.Bold);
                tabBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                tabFront = Brushes.Black;
            }
            else
            {
                tabFont = e.Font;
                tabBack = new SolidBrush(SystemColors.Control);
                tabFront = new SolidBrush(Color.Black);
            }
            string tabName = tcApplicationParam.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(tabBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, tabFont, tabFront, recTab, sftTab);
        }
        #endregion

    }
}