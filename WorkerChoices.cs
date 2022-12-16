//Author: Ian Flores
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.TaskScheduler
{
    /// <summary>
    /// The WorkerChoices class0
    /// </summary>
    public partial class WorkerChoices : Form
    {
        /// <summary>
        /// The WorkerChoices constructor
        /// </summary>
        public WorkerChoices()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// The result of no workers being selected
        /// </summary>
        private const string _noWorkerAssigned = "[None]";

        /// <summary>
        /// Sets the ListBox to a list of qualified workers
        /// </summary>
        public List<string> QualifiedWorkers
        {
            set
            {
                ux_workersListBox.Items.Clear();
                ux_workersListBox.Items.Add(_noWorkerAssigned);
                foreach(string s in value)
                {
                    ux_workersListBox.Items.Add(s);
                }
                ux_workersListBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the name of a selected worker
        /// </summary>
        public string Worker
        {
            get
            {
                string worker = (string)ux_workersListBox.SelectedItem;
                if(worker == _noWorkerAssigned)
                {
                    return "";
                }
                return worker;
            }
        }

        /// <summary>
        /// The event handler for the OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
