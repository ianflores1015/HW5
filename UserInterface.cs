/* UserInterface.cs
 * Author: Josh Weese and Rod Howell
 * 
 * Edited By: Ian Flores
 */
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Ksu.Cis300.TaskScheduler;
using System.Collections.Generic;

namespace Ksu.Cis300.Scheduler
{
    /// <summary>
    /// A GUI for a program to find a schedule for workers qualified for various tasks.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// the index of the "Workers Only" item in the ComboBox
        /// </summary>
        private const int _workersOnly = 0;

        /// <summary>
        /// the header to use in the upper-left corner of the "Schedule Data"
        /// </summary>
        private const string _headerName = "Name";

        /// <summary>
        /// the header to use in the upper-left corner of the "Computed Schedule"
        /// </summary>
        private const string _headerDay = "Day";

        /// <summary>
        /// a WorkerChoices instance
        /// </summary>
        WorkerChoices _workerChoice = new WorkerChoices();

        /// <summary>
        /// the underlying data table for the computed schedule
        /// </summary>
        DataTable _table;

        /// <summary>
        /// The scheduler that will hold workers and schedule information
        /// </summary>
        private Scheduler _schedule;
        private const int _dataTab = 0;
        private const int _computedTab = 1;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            ux_balanceComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// updates the stats of the schedule
        /// </summary>
        private void UpdateStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Each worker was scheduled an average of ");
            sb.Append(_schedule.AverageScheduledTasks);
            sb.Append(" tasks, the least times scheduled was ");
            sb.Append(_schedule.leastTimesAssigned);
            sb.Append(" tasks and the most times scheduled was ");
            sb.Append(_schedule.MostScheduledTasks);
            sb.Append(" tasks. ");
            sb.Append("\nThe least times a task was sheduled was ");
            sb.Append(_schedule.LeastTimesScheduled);
            sb.Append(" days and the most was");
            sb.Append(_schedule.MostTimesScheduled);
            sb.Append(" days.");
            MessageBox.Show(sb.ToString());
        }

        /// <summary>
        /// the event handler for when the data binding is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxScheduleDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            uxScheduleDataGrid.TopLeftHeaderCell.Value = _headerName;
            int index = 0;
            foreach (string name in _schedule.WorkerNames)
            {
                uxScheduleDataGrid.Rows[index].HeaderCell.Value = name;
                index++;
            }
            for (int j = 0; j < uxScheduleDataGrid.ColumnCount; j++)
            {
                uxScheduleDataGrid.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// event handler for rows added to the computed schedule data grid
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxComputedScheduleDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
            {
                uxComputedScheduleDataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();

            }
        }

        // <summary>
        /// event handler for column added to the computer schedule data grid
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args (column added)</param>
        private void uxComputedScheduleDataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        /// <summary>
        /// event handler for the compute schedule button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxComputeSchedule_Click(object sender, EventArgs e)
        {
            uxScheduleView.SelectTab(_computedTab);
            uxComputedScheduleDataGrid.DataSource = null;
            _schedule.ComputeSchedule(uxLength.Value, ux_balanceComboBox.SelectedIndex == _workersOnly, _table);
            uxComputedScheduleDataGrid.DataSource = _table;
            UpdateStats();
        }

        /// <summary>
        /// event handler for the uxlength item
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxLength_ValueChanged(object sender, EventArgs e)
        {
            int rowsToAdd = (int)uxLength.Value - _table.Rows.Count;
            if (rowsToAdd > 0)
            {
                for (int i = 0; i < rowsToAdd; i++)
                {
                    _table.Rows.Add();
                    for (int k = 0; k < _table.Columns.Count; k++)
                    {
                        _table.Rows[_table.Rows.Count - 1][k] = "";
                    }
                }
            }
            else if (rowsToAdd < 0)
            {
                for (int i = rowsToAdd; i > 0; i--)
                {
                    _table.Rows.RemoveAt(_table.Rows.Count - 1);
                }
            }
            uxComputedScheduleDataGrid.DataSource = _table;
        }


        /// <summary>
        /// The event handler for the open button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxScheduleView.SelectTab(_dataTab);
                    DataTable table = new DataTable();
                    foreach (string s in _schedule.TaskNames)
                    {
                        table.Columns.Add(s);
                    }
                    int len = (int)uxLength.Value;
                    for (int i = table.Rows.Count; i < len; i++)
                    {
                        table.Rows.Add();
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            table.Rows[i][j] = "";
                        }
                    }
                    uxComputedScheduleDataGrid.Columns.Clear();
                    uxComputedScheduleDataGrid.DataSource = table;
                    _table = table;
                    uxComputedScheduleDataGrid.TopLeftHeaderCell.Value = _headerDay;
                    this.Text = Path.GetFileName(uxOpenDialog.FileName);
                    ux_saveAsToolStripMenuItem.Enabled = true;
                    ux_computeToolStripMenuItem.Enabled = true;
                    ux_clearToolStripMenuItem.Enabled = true;
                    uxScheduleDataGrid.DataSource = _schedule.GetRawScheduleData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Text = "File Error";
                    uxComputedScheduleDataGrid.DataSource = null;
                    uxScheduleDataGrid.DataSource = null;
                    _table = null;
                    ux_saveAsToolStripMenuItem.Enabled = false;
                    ux_computeToolStripMenuItem.Enabled = false;
                    ux_clearToolStripMenuItem.Enabled = false;
                }
            }
        }

        /// <summary>
        /// the event handler for the compute button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uxScheduleView.SelectTab(_computedTab);
            uxComputedScheduleDataGrid.DataSource = null;
            _schedule.ComputeSchedule(uxLength.Value, ux_balanceComboBox.SelectedIndex == _workersOnly, _table);
            uxComputedScheduleDataGrid.DataSource = _table;
            UpdateStats();
        }

        /// <summary>
        /// Event handler for the clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ux_clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uxComputedScheduleTab.Select();
            uxComputedScheduleDataGrid.DataSource = null;
            for (int i = 0; i < _table.Rows.Count; i++)
            {
                for (int k = 0; k < _table.Columns.Count; k++)
                {
                    _table.Rows[i][k] = "";
                }
            }
            uxComputedScheduleDataGrid.DataSource = _table;
            uxScheduleView.SelectedIndex = _computedTab;
        }

        /// <summary>
        /// event handler for selection changed in computed schedule
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args e</param>
        private void uxComputedScheduleDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in uxComputedScheduleDataGrid.SelectedRows)
            {
                for (int k = 0; k < _table.Columns.Count; k++)
                {
                    _table.Rows[r.Index][k] = "";
                }
            }
        }


        /// <summary>
        /// event handler for a cell click in the computed schedule data grid
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">cell event args</param>
        private void uxComputedScheduleDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string header = uxComputedScheduleDataGrid.Columns[e.ColumnIndex].HeaderText;
                List<string> qualifiedWorkers = _schedule.GetQualifiedWorkers(header);
                qualifiedWorkers.Sort();
                _workerChoice.QualifiedWorkers = qualifiedWorkers;
                if (_workerChoice.ShowDialog() == DialogResult.OK)
                {
                    string currentCellValue = (string)_table.Rows[e.RowIndex][e.ColumnIndex];
                    if (currentCellValue == _workerChoice.Worker)
                    {
                        _table.Rows[e.RowIndex][e.ColumnIndex] = "";
                    }
                    else
                    { 
                        _table.Rows[e.RowIndex][e.ColumnIndex] = _workerChoice.Worker;
                    }
                }
            }
        }


        /// <summary>
        /// the save as event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ux_saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(uxSaveDialog.FileName))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Day,");
                        for (int i = 0; i < uxComputedScheduleDataGrid.ColumnCount; i++)
                        {
                            sb.Append(uxComputedScheduleDataGrid.Columns[i].Name);

                            if (i + 1 < uxComputedScheduleDataGrid.ColumnCount)
                            {
                                sb.Append(",");
                            }
                        }

                        sb.AppendLine();
                        for (int i = 0; i < uxComputedScheduleDataGrid.RowCount; i++)
                        {
                            sb.Append(uxComputedScheduleDataGrid.Rows[i].HeaderCell.Value.ToString());
                            sb.Append(",");
                            for (int k = 0; k < uxComputedScheduleDataGrid.Rows[i].Cells.Count; k++)
                            {
                                sb.Append(uxComputedScheduleDataGrid.Rows[i].Cells[k].Value.ToString());
                                sb.Append(",");
                            }
                            sb.AppendLine();
                        }

                        sw.Write(sb.ToString());
                    }

                    MessageBox.Show("File written.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
