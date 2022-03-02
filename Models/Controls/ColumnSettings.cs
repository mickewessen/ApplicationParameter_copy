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
            dvgAll = form.dvg_all;
            showControls = form.dvg_showcontrols;
            settings = form.dvg_settings;
            email = form.dvg_email;
            movex = form.dvg_movex;
            printer = form.dvg_printer;
            timeInterval = form.dvg_timeinterval;
            tableSettings = form.dvg_tablesettings;
            admission = form.dvg_admission;
            machineRecipe = form.dvg_machinerecipe;
            planningGroup = form.dvg_planninggroup;
            completion = form.dvg_completion;
            ITAG = form.dvg_itag;
            shift = form.dvg_shift;
            misc = form.dvg_misc;
            watchDog = form.dvg_watchdog;

            dvgList.Add(dvgAll);
            dvgList.Add(showControls);
            dvgList.Add(settings);
            dvgList.Add(email);
            dvgList.Add(movex);
            dvgList.Add(printer);
            dvgList.Add(timeInterval);
            dvgList.Add(tableSettings);
            dvgList.Add(admission);
            dvgList.Add(machineRecipe);
            dvgList.Add(planningGroup);
            dvgList.Add(completion);
            dvgList.Add(ITAG);
            dvgList.Add(shift);
            dvgList.Add(misc);
            dvgList.Add(watchDog);
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