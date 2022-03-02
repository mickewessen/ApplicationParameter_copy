using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ApplicationParameterTest.Models
{
    public class ColumnSettings
    {
        public ParameterForm form;
        public DataGridView dvgAll;
        public DataGridView showControls;
        public DataGridView settings;
        public DataGridView email;
        public DataGridView movex;
        public DataGridView printer;
        public DataGridView timeInterval;
        public DataGridView tableSettings;
        public DataGridView admission;
        public DataGridView machineRecipe;
        public DataGridView planningGroup;
        public DataGridView completion;
        public DataGridView ITAG;
        public DataGridView shift;
        public DataGridView misc;
        public DataGridView watchDog;
        private List<DataGridView> dvgList = new();

        public class ColumnName
        {
            public int ColumnIndex { get; set; }
            public string ColumnNames { get; set; }
        }

        public ColumnSettings(ParameterForm form)
        {
        }
        public void HideColumns(int[] columnIndex)
        {
            foreach (var item in dvgList)
            {
                foreach (int i in columnIndex)
                {
                    item.Columns[i].Visible = false;
                }
            }
        }
        public void SetColumnNames()
        {
            List<ColumnName> columnNames = new List<ColumnName>()
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
            foreach (DataGridView view in dvgList)
            {
                foreach (var name in columnNames)
                {
                    view.Columns[name.ColumnIndex].HeaderText = name.ColumnNames;
                }
            }

        }
        public void SortColumns(int[] sortColumns)
        {
            foreach (var gridview in dvgList)
            {
                foreach (int i in sortColumns)
                {
                    gridview.Columns[i].DisplayIndex = 0;
                    gridview.Columns[i].DisplayIndex = 1;
                }
            }
        }
        public void SetColumnWidth(int[] setColumnWidth)
        {
            foreach (var gridview in dvgList)
            {
                foreach (int i in setColumnWidth)
                {
                    gridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

    }
}