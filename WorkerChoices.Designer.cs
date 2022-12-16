namespace Ksu.Cis300.TaskScheduler
{
    partial class WorkerChoices
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
            this.ux_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ux_qualifiedWorkersLabel = new System.Windows.Forms.Label();
            this.ux_workersListBox = new System.Windows.Forms.ListBox();
            this.ux_okButton = new System.Windows.Forms.Button();
            this.ux_flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ux_flowLayoutPanel
            // 
            this.ux_flowLayoutPanel.Controls.Add(this.ux_qualifiedWorkersLabel);
            this.ux_flowLayoutPanel.Controls.Add(this.ux_workersListBox);
            this.ux_flowLayoutPanel.Controls.Add(this.ux_okButton);
            this.ux_flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ux_flowLayoutPanel.Location = new System.Drawing.Point(21, 24);
            this.ux_flowLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ux_flowLayoutPanel.Name = "ux_flowLayoutPanel";
            this.ux_flowLayoutPanel.Size = new System.Drawing.Size(164, 233);
            this.ux_flowLayoutPanel.TabIndex = 0;
            // 
            // ux_qualifiedWorkersLabel
            // 
            this.ux_qualifiedWorkersLabel.AutoSize = true;
            this.ux_qualifiedWorkersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ux_qualifiedWorkersLabel.Location = new System.Drawing.Point(2, 0);
            this.ux_qualifiedWorkersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_qualifiedWorkersLabel.Name = "ux_qualifiedWorkersLabel";
            this.ux_qualifiedWorkersLabel.Size = new System.Drawing.Size(104, 15);
            this.ux_qualifiedWorkersLabel.TabIndex = 0;
            this.ux_qualifiedWorkersLabel.Text = "Qualified Workers:";
            // 
            // ux_workersListBox
            // 
            this.ux_workersListBox.FormattingEnabled = true;
            this.ux_workersListBox.Location = new System.Drawing.Point(2, 17);
            this.ux_workersListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ux_workersListBox.Name = "ux_workersListBox";
            this.ux_workersListBox.Size = new System.Drawing.Size(155, 173);
            this.ux_workersListBox.TabIndex = 1;
            // 
            // ux_okButton
            // 
            this.ux_okButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ux_okButton.Location = new System.Drawing.Point(2, 194);
            this.ux_okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ux_okButton.Name = "ux_okButton";
            this.ux_okButton.Size = new System.Drawing.Size(154, 31);
            this.ux_okButton.TabIndex = 2;
            this.ux_okButton.Text = "OK";
            this.ux_okButton.UseVisualStyleBackColor = true;
            this.ux_okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 281);
            this.Controls.Add(this.ux_flowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ux_flowLayoutPanel.ResumeLayout(false);
            this.ux_flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ux_flowLayoutPanel;
        private System.Windows.Forms.Label ux_qualifiedWorkersLabel;
        private System.Windows.Forms.ListBox ux_workersListBox;
        private System.Windows.Forms.Button ux_okButton;
    }
}