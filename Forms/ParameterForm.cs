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
        public CustomComboBox combo =new();
        public MemoryStream ms;
        public MessagesModel messages;
        public List<DataGridView> dataGridViews;
        public List<DataGridView> list;
        public List<ColumnName> columnNames;
        public DataGridView view { get; set; }
        public ParameterForm()
        {   
            dataGridViews = new List<DataGridView>();
            {
                dataGridViews.Add(dvg_showcontrols);
                dataGridViews.Add(dvg_settings);
                dataGridViews.Add(dvg_email);
                dataGridViews.Add(dvg_movex);
                dataGridViews.Add(dvg_printer);
                dataGridViews.Add(dvg_timeinterval);
                dataGridViews.Add(dvg_tablesettings);
                dataGridViews.Add(dvg_admission);
                dataGridViews.Add(dvg_machinerecipe);
                dataGridViews.Add(dvg_planninggroup);
                dataGridViews.Add(dvg_completion);
                dataGridViews.Add(dvg_itag);
                dataGridViews.Add(dvg_shift);
                dataGridViews.Add(dvg_misc);
                dataGridViews.Add(dvg_watchdog);
            }
            InitializeComponent();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl3.DrawMode = TabDrawMode.OwnerDrawFixed;
        }
        
        public void AppParamForm_Load(object sender, EventArgs e)
        {
            GetData();
            PopulateImageColumn();
            ColumnSettings();
            TabControl();
            combo.LoadCombo();
            AddButtonColumn();
            CreateTabPagesDynamically();
            FillDataDynamically();
        }

        public void AddButtonColumn()
        {
            dvg_admission.Columns.Add(new DataGridViewButtonColumn()
            {
                HeaderText = "Knapp",
                Name = "Knapp",
                DisplayIndex = 1,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
            });
        }
        private void dvg_admission_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dvg_admission.Columns["Knapp"].Index)
            {
                if (dvg_admission["stringValue", e.RowIndex].Value != null)
                {
                    string s = dvg_admission["stringValue", e.RowIndex].Value.ToString();
                    switch (s)
                    {
                        case "true":
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All); ;
                            e.Graphics.DrawImage(new Bitmap(myImages.green_icon, Height = 16, Width = 16), e.CellBounds.Left + 5, e.CellBounds.Top + 5);
                            e.Handled = true;
                            break;

                        case "false":
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                            e.Graphics.DrawImage(new Bitmap(myImages.red_icon24, Height = 16, Width = 16), e.CellBounds.Left + 5, e.CellBounds.Top + 5);
                            e.Handled = true;
                            break;
                        case "Yes":
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All); ;
                            e.Graphics.DrawImage(new Bitmap(myImages.green_icon, Height = 16, Width = 16), e.CellBounds.Left + 5, e.CellBounds.Top + 5);
                            e.Handled = true;
                            break;
                        case "1":
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All); ;
                            e.Graphics.DrawImage(new Bitmap(myImages.green_icon, Height = 16, Width = 16), e.CellBounds.Left + 5, e.CellBounds.Top + 5);
                            e.Handled = true;
                            break;
                        case "0":
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All); ;
                            e.Graphics.DrawImage(new Bitmap(myImages.green_icon, Height = 16, Width = 16), e.CellBounds.Left + 5, e.CellBounds.Top + 5);
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        public void FillDataByCategory(string category, DataGridView gridview)
        {
            SqlDataAdapter sqldata = new("SELECT * FROM Prodex_ApplicationParameterData WHERE objectCategory ='"+category+"'", con);
            DataSet dataSet = new();
            sqldata.Fill(dataSet, gridview.ToString());
            gridview.DataSource = dataSet.Tables[gridview.ToString()].DefaultView;
        }
        public void GetData()
        {
            //Add new row for each category in database
            FillDataByCategory("Visa/Dölj kontroller", dvg_showcontrols);
            FillDataByCategory("Maskininställningar", dvg_settings);
            FillDataByCategory("Email", dvg_email);
            FillDataByCategory("Movex", dvg_movex);
            FillDataByCategory("Utskrift", dvg_printer);
            FillDataByCategory("Tidsintervall", dvg_timeinterval);
            FillDataByCategory("Tabellinställningar", dvg_tablesettings);
            FillDataByCategory("Intag", dvg_admission);
            FillDataByCategory("Maskinrecept", dvg_machinerecipe);
            FillDataByCategory("Planeringsgrupper", dvg_planninggroup);
            FillDataByCategory("Färdigställning", dvg_completion);
            FillDataByCategory("ITAG", dvg_itag);
            FillDataByCategory("Skift", dvg_shift);
            FillDataByCategory("Övrigt", dvg_misc);
            FillDataByCategory("Watchdog", dvg_watchdog);
            FillDataByCategory("", dvg_all);
        }
        public void PopulateImageColumn()
        {
            AddImageColumn(dvg_showcontrols);
            AddImageColumn(dvg_settings);
            AddImageColumn(dvg_email);
            AddImageColumn(dvg_movex);
            AddImageColumn(dvg_printer);
            AddImageColumn(dvg_timeinterval);
            AddImageColumn(dvg_tablesettings);
            AddImageColumn(dvg_admission);
            AddImageColumn(dvg_machinerecipe);
            AddImageColumn(dvg_planninggroup);
            AddImageColumn(dvg_completion);
            AddImageColumn(dvg_itag);
            AddImageColumn(dvg_shift);
            AddImageColumn(dvg_misc);
            AddImageColumn(dvg_watchdog);
        }
        public void ImageColumnFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView view = (sender as DataGridView);
            foreach (var item in dataGridViews)
            {
                if (view.Columns[e.ColumnIndex].Name =="Status")
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
        }
        public void ColumnSettings()
        {
            //Set columnmproperties 
            ColumnSettings columnSettings = new ColumnSettings(this);
            columnSettings.HideColumns(new int[] { 0, 3, 7, 8, 9, 10, 11, 14, 15, 16, 17, 18, 19 });
            columnSettings.SetColumnNames();
            columnSettings.SetColumnWidth(new int[] { 2, 5, 12, 13, 20, 21 });
            columnSettings.SortColumns(new int[] { 21, 20 });
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageSearch;
            string sqlQuery = "SELECT * FROM Prodex_ApplicationParameterData WHERE objectId = '" + txtSearch.Text + "'";
            con.Open();
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataAdapter sdr = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dvg_search.DataSource = dt;
            con.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //GetData();
            FillDataDynamically();
        }
        public void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view =(sender as DataGridView);
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
                        form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();
                        form.comboBoxCategory.Text = view.CurrentRow.Cells["objectCategory"].Value.ToString();
                        form.txtboxUpdatedBy.Text = view.CurrentRow.Cells["updatedUser"].Value.ToString();
                        form.txtUpdatedTime.Text = view.CurrentRow.Cells["updated"].Value.ToString();
                        form.richTextBoxnote.Text = view.CurrentRow.Cells["note"].Value.ToString();
                        form.txtFileName.Text = view.CurrentRow.Cells[16].Value.ToString();
                        form.linkLabel1.Text = view.CurrentRow.Cells[18].Value.ToString();
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
                            form.pictureBox.Image = Image.FromStream(ms);
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
                        form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();
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
                    form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();                    
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
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font tabFont;
            Brush tabBack;
            Brush tabFront;

            if (e.Index == tabControl1.SelectedIndex)
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
            string tabName = tabControl1.TabPages[e.Index].Text;            
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(tabBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, tabFont, tabFront, recTab, sftTab);

        }
        public class TabSettings
        {
            public int TabIndex { get; set; }
            public int RowCount { get; set; }
            public string TabName { get; set; }
        }
        public class ColumnName
        {
            public int ColumnIndex { get; set; }
            public string ColumnNames { get; set; }
        }
        public void TabControl()
        {
            List<TabSettings> tabSettings = new()
            {
                new TabSettings()
                {
                    TabIndex = 0,
                    RowCount = dvg_all.RowCount,
                    TabName = tabPageAll.Text
                },
                new TabSettings()
                {
                    TabIndex = 1,
                    RowCount = dvg_showcontrols.RowCount,
                    TabName = tabshowcontrols.Text
                },
                new TabSettings()
                {
                    TabIndex = 2,
                    RowCount = dvg_settings.RowCount,
                    TabName = tabPageSettings.Text
                },
                new TabSettings()
                {
                    TabIndex = 3,
                    RowCount = dvg_email.RowCount,
                    TabName = tabPageEmail.Text
                },
                new TabSettings()
                {
                    TabIndex = 4,
                    RowCount = dvg_movex.RowCount,
                    TabName = tabPageMovex.Text
                },
                new TabSettings()
                {
                    TabIndex = 5,
                    RowCount = dvg_printer.RowCount,
                    TabName = tabPageprinter.Text
                },
                new TabSettings()
                {
                    TabIndex = 6,
                    RowCount = dvg_timeinterval.RowCount,
                    TabName = tabPagetimeinterval.Text
                },
                new TabSettings()
                {
                    TabIndex = 7,
                    RowCount = dvg_tablesettings.RowCount,
                    TabName = tabPagegridsettings.Text
                },
                new TabSettings()
                {
                    TabIndex = 8,
                    RowCount = dvg_admission.RowCount,
                    TabName = tabPageadmission.Text
                },
                new TabSettings()
                {
                    TabIndex = 9,
                    RowCount = dvg_machinerecipe.RowCount,
                    TabName = tabPageMachineRecipe.Text
                },
                new TabSettings()
                {
                    TabIndex = 10,
                    RowCount = dvg_planninggroup.RowCount,
                    TabName = tabPagePlanningGroup.Text
                },
                new TabSettings()
                {
                    TabIndex = 11,
                    RowCount = dvg_completion.RowCount,
                    TabName = tabPageCompletion.Text
                },
                new TabSettings()
                {
                    TabIndex = 12,
                    RowCount = dvg_itag.RowCount,
                    TabName = tabPageItag.Text
                },
                new TabSettings()
                {
                    TabIndex = 13,
                    RowCount = dvg_shift.RowCount,
                    TabName = tabPageWorkShift.Text
                },
                new TabSettings()
                {
                    TabIndex = 14,
                    RowCount = dvg_misc.RowCount,
                    TabName = tabPageMisc.Text
                },
                new TabSettings()
                {
                    TabIndex = 15,
                    RowCount = dvg_watchdog.RowCount,
                    TabName = tabPageWatchdog.Text
                },
            };            

            foreach (var tab in tabSettings)
            {
                tabControl1.TabPages[tab.TabIndex].Text = $"{ tab.TabName} - ({tab.RowCount})";
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
                tabControl3.TabPages.Add(tabPage);
            }
            con.Close();
        }
        public void SetColumNames(DataGridView view)
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
        public void FillDataDynamically()
        {
            foreach (TabPage page in tabControl3.TabPages)
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
                    DataSource = dtByCategory,
                    RowHeadersVisible = false,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AllowUserToAddRows = false,
                    AllowUserToOrderColumns = false,
                };
                page.Controls.Add(view);
                if (string.IsNullOrWhiteSpace(page.Text))
                {
                    page.Text = $"Okategoriserade - ({ view.RowCount})";
                }

                for (int i = 0; i < view.Columns.Count; i++)
                {                    
                    SetColumNames(view);
                    SortColumns(view);
                    HideColumns(view);
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                view.CellDoubleClick += DatagridView_CellDoubleClick;
                tabControl3.SelectedIndexChanged += TabControl3_SelectedIndexChanged;
                //AddImageColumn(view);
            }
        }
        private void TabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl3.TabPages)
            {                
                foreach (DataGridView grid in page.Controls)
                {                    
                    foreach (var col in grid.Columns)
                    {
                        SetColumNames(grid);
                        SortColumns(grid);
                        HideColumns(grid);
                        //AddImageColumn(grid);
                        for (int i = 0; i < grid.Columns.Count; i++)
                        {
                            grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }            
        }
        private void DatagridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                        form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();
                        form.comboBoxCategory.Text = view.CurrentRow.Cells["objectCategory"].Value.ToString();
                        form.txtboxUpdatedBy.Text = view.CurrentRow.Cells["updatedUser"].Value.ToString();
                        form.txtUpdatedTime.Text = view.CurrentRow.Cells["updated"].Value.ToString();
                        form.richTextBoxnote.Text = view.CurrentRow.Cells["note"].Value.ToString();
                        form.txtFileName.Text = view.CurrentRow.Cells[16].Value.ToString();
                        form.linkLabel1.Text = view.CurrentRow.Cells[18].Value.ToString();
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
                            form.pictureBox.Image = Image.FromStream(ms);
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
                        form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();
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
                    form.txtCreatedBy.Text = view.CurrentRow.Cells["createdUser"].Value.ToString();
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
        private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font tabFont;
            Brush tabBack;
            Brush tabFront;

            if (e.Index == tabControl3.SelectedIndex)
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
            string tabName = tabControl3.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
            sftTab.Alignment = StringAlignment.Center;
            sftTab.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(tabBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, tabFont, tabFront, recTab, sftTab);
        }
    }
}