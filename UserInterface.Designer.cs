namespace Ksu.Cis300.Scheduler
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uxLength = new System.Windows.Forms.NumericUpDown();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxScheduleView = new System.Windows.Forms.TabControl();
            this.uxScheduleDataTab = new System.Windows.Forms.TabPage();
            this.uxScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.uxComputedScheduleTab = new System.Windows.Forms.TabPage();
            this.uxComputedScheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ux_fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_computeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ux_balanceLabel = new System.Windows.Forms.Label();
            this.ux_scheduleLengthLabel = new System.Windows.Forms.Label();
            this.ux_balanceComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxLength)).BeginInit();
            this.uxScheduleView.SuspendLayout();
            this.uxScheduleDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxScheduleDataGrid)).BeginInit();
            this.uxComputedScheduleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxComputedScheduleDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxLength
            // 
            this.uxLength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uxLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxLength.Location = new System.Drawing.Point(544, 2);
            this.uxLength.Margin = new System.Windows.Forms.Padding(4);
            this.uxLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLength.Name = "uxLength";
            this.uxLength.Size = new System.Drawing.Size(117, 27);
            this.uxLength.TabIndex = 3;
            this.uxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "CSV files|*.csv|All files|*.*";
            this.uxOpenDialog.Title = "Select Input File";
            // 
            // uxSaveDialog
            // 
            this.uxSaveDialog.Filter = "CSV files|*.csv|All files|*.*";
            this.uxSaveDialog.Title = "Save Output File As";
            // 
            // uxScheduleView
            // 
            this.uxScheduleView.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.uxScheduleView.Controls.Add(this.uxScheduleDataTab);
            this.uxScheduleView.Controls.Add(this.uxComputedScheduleTab);
            this.uxScheduleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxScheduleView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uxScheduleView.Location = new System.Drawing.Point(0, 28);
            this.uxScheduleView.Margin = new System.Windows.Forms.Padding(4);
            this.uxScheduleView.Name = "uxScheduleView";
            this.uxScheduleView.SelectedIndex = 0;
            this.uxScheduleView.Size = new System.Drawing.Size(1369, 756);
            this.uxScheduleView.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.uxScheduleView.TabIndex = 5;
            // 
            // uxScheduleDataTab
            // 
            this.uxScheduleDataTab.BackColor = System.Drawing.Color.Transparent;
            this.uxScheduleDataTab.Controls.Add(this.uxScheduleDataGrid);
            this.uxScheduleDataTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxScheduleDataTab.Location = new System.Drawing.Point(4, 28);
            this.uxScheduleDataTab.Margin = new System.Windows.Forms.Padding(4);
            this.uxScheduleDataTab.Name = "uxScheduleDataTab";
            this.uxScheduleDataTab.Padding = new System.Windows.Forms.Padding(4);
            this.uxScheduleDataTab.Size = new System.Drawing.Size(1361, 724);
            this.uxScheduleDataTab.TabIndex = 0;
            this.uxScheduleDataTab.Text = "Schedule Data";
            this.uxScheduleDataTab.UseVisualStyleBackColor = true;
            // 
            // uxScheduleDataGrid
            // 
            this.uxScheduleDataGrid.AllowUserToAddRows = false;
            this.uxScheduleDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uxScheduleDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.uxScheduleDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.uxScheduleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.uxScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uxScheduleDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.uxScheduleDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxScheduleDataGrid.Location = new System.Drawing.Point(4, 4);
            this.uxScheduleDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.uxScheduleDataGrid.Name = "uxScheduleDataGrid";
            this.uxScheduleDataGrid.ReadOnly = true;
            this.uxScheduleDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.uxScheduleDataGrid.Size = new System.Drawing.Size(1353, 716);
            this.uxScheduleDataGrid.TabIndex = 0;
            // 
            // uxComputedScheduleTab
            // 
            this.uxComputedScheduleTab.Controls.Add(this.uxComputedScheduleDataGrid);
            this.uxComputedScheduleTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxComputedScheduleTab.Location = new System.Drawing.Point(4, 28);
            this.uxComputedScheduleTab.Margin = new System.Windows.Forms.Padding(4);
            this.uxComputedScheduleTab.Name = "uxComputedScheduleTab";
            this.uxComputedScheduleTab.Padding = new System.Windows.Forms.Padding(4);
            this.uxComputedScheduleTab.Size = new System.Drawing.Size(1361, 724);
            this.uxComputedScheduleTab.TabIndex = 1;
            this.uxComputedScheduleTab.Text = "Computed Schedule";
            this.uxComputedScheduleTab.UseVisualStyleBackColor = true;
            // 
            // uxComputedScheduleDataGrid
            // 
            this.uxComputedScheduleDataGrid.AllowUserToAddRows = false;
            this.uxComputedScheduleDataGrid.AllowUserToDeleteRows = false;
            this.uxComputedScheduleDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.uxComputedScheduleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.uxComputedScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxComputedScheduleDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxComputedScheduleDataGrid.Location = new System.Drawing.Point(4, 4);
            this.uxComputedScheduleDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.uxComputedScheduleDataGrid.Name = "uxComputedScheduleDataGrid";
            this.uxComputedScheduleDataGrid.ReadOnly = true;
            this.uxComputedScheduleDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.uxComputedScheduleDataGrid.Size = new System.Drawing.Size(1353, 716);
            this.uxComputedScheduleDataGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ux_fileToolStripMenuItem,
            this.ux_scheduleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1369, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ux_fileToolStripMenuItem
            // 
            this.ux_fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ux_openToolStripMenuItem,
            this.ux_saveAsToolStripMenuItem});
            this.ux_fileToolStripMenuItem.Name = "ux_fileToolStripMenuItem";
            this.ux_fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.ux_fileToolStripMenuItem.Text = "File";
            // 
            // ux_openToolStripMenuItem
            // 
            this.ux_openToolStripMenuItem.Name = "ux_openToolStripMenuItem";
            this.ux_openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.ux_openToolStripMenuItem.Text = "Open";
            this.ux_openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // ux_saveAsToolStripMenuItem
            // 
            this.ux_saveAsToolStripMenuItem.Enabled = false;
            this.ux_saveAsToolStripMenuItem.Name = "ux_saveAsToolStripMenuItem";
            this.ux_saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ux_saveAsToolStripMenuItem.Text = "Save As";
            this.ux_saveAsToolStripMenuItem.Click += new System.EventHandler(this.ux_saveAsToolStripMenuItem_Click);
            // 
            // ux_scheduleToolStripMenuItem
            // 
            this.ux_scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ux_computeToolStripMenuItem,
            this.ux_clearToolStripMenuItem});
            this.ux_scheduleToolStripMenuItem.Name = "ux_scheduleToolStripMenuItem";
            this.ux_scheduleToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.ux_scheduleToolStripMenuItem.Text = "Schedule";
            // 
            // ux_computeToolStripMenuItem
            // 
            this.ux_computeToolStripMenuItem.Enabled = false;
            this.ux_computeToolStripMenuItem.Name = "ux_computeToolStripMenuItem";
            this.ux_computeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ux_computeToolStripMenuItem.Text = "Compute";
            this.ux_computeToolStripMenuItem.Click += new System.EventHandler(this.computeToolStripMenuItem_Click);
            // 
            // ux_clearToolStripMenuItem
            // 
            this.ux_clearToolStripMenuItem.Enabled = false;
            this.ux_clearToolStripMenuItem.Name = "ux_clearToolStripMenuItem";
            this.ux_clearToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ux_clearToolStripMenuItem.Text = "Clear";
            this.ux_clearToolStripMenuItem.Click += new System.EventHandler(this.ux_clearToolStripMenuItem_Click);
            // 
            // ux_balanceLabel
            // 
            this.ux_balanceLabel.AutoSize = true;
            this.ux_balanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ux_balanceLabel.Location = new System.Drawing.Point(172, 5);
            this.ux_balanceLabel.Name = "ux_balanceLabel";
            this.ux_balanceLabel.Size = new System.Drawing.Size(68, 20);
            this.ux_balanceLabel.TabIndex = 8;
            this.ux_balanceLabel.Text = "Balance: ";
            // 
            // ux_scheduleLengthLabel
            // 
            this.ux_scheduleLengthLabel.AutoSize = true;
            this.ux_scheduleLengthLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ux_scheduleLengthLabel.Location = new System.Drawing.Point(403, 6);
            this.ux_scheduleLengthLabel.Name = "ux_scheduleLengthLabel";
            this.ux_scheduleLengthLabel.Size = new System.Drawing.Size(125, 20);
            this.ux_scheduleLengthLabel.TabIndex = 9;
            this.ux_scheduleLengthLabel.Text = "Schedule Length: ";
            // 
            // ux_balanceComboBox
            // 
            this.ux_balanceComboBox.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.ux_balanceComboBox.FormattingEnabled = true;
            this.ux_balanceComboBox.Items.AddRange(new object[] {
            "Workers Only",
            "Tasks First"});
            this.ux_balanceComboBox.Location = new System.Drawing.Point(239, 4);
            this.ux_balanceComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ux_balanceComboBox.Name = "ux_balanceComboBox";
            this.ux_balanceComboBox.Size = new System.Drawing.Size(136, 23);
            this.ux_balanceComboBox.TabIndex = 10;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 784);
            this.Controls.Add(this.ux_balanceComboBox);
            this.Controls.Add(this.ux_scheduleLengthLabel);
            this.Controls.Add(this.ux_balanceLabel);
            this.Controls.Add(this.uxScheduleView);
            this.Controls.Add(this.uxLength);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            ((System.ComponentModel.ISupportInitialize)(this.uxLength)).EndInit();
            this.uxScheduleView.ResumeLayout(false);
            this.uxScheduleDataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxScheduleDataGrid)).EndInit();
            this.uxComputedScheduleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxComputedScheduleDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown uxLength;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
        private System.Windows.Forms.TabControl uxScheduleView;
        private System.Windows.Forms.TabPage uxScheduleDataTab;
        private System.Windows.Forms.DataGridView uxScheduleDataGrid;
        private System.Windows.Forms.TabPage uxComputedScheduleTab;
        private System.Windows.Forms.DataGridView uxComputedScheduleDataGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ux_fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ux_openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ux_saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ux_scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ux_computeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ux_clearToolStripMenuItem;
        private System.Windows.Forms.Label ux_balanceLabel;
        private System.Windows.Forms.Label ux_scheduleLengthLabel;
        private System.Windows.Forms.ComboBox ux_balanceComboBox;
    }
}

