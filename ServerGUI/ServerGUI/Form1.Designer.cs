using System.Data;

namespace ServerGUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSinceConnection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignalStrength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Graph = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeight = 30;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PackageStatus,
            this.TimeSinceConnection,
            this.SignalStrength,
            this.Graph});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 40;
            this.dataGridView.Size = new System.Drawing.Size(1160, 473);
            this.dataGridView.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // PackageStatus
            // 
            this.PackageStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PackageStatus.HeaderText = "Package Status";
            this.PackageStatus.Name = "PackageStatus";
            this.PackageStatus.ReadOnly = true;
            // 
            // TimeSinceConnection
            // 
            this.TimeSinceConnection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeSinceConnection.HeaderText = "Time Since Connection";
            this.TimeSinceConnection.Name = "TimeSinceConnection";
            this.TimeSinceConnection.ReadOnly = true;
            // 
            // SignalStrength
            // 
            this.SignalStrength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SignalStrength.HeaderText = "Signal Strength";
            this.SignalStrength.Name = "SignalStrength";
            this.SignalStrength.ReadOnly = true;
            // 
            // Graph
            // 
            this.Graph.HeaderText = "";
            this.Graph.Name = "Graph";
            this.Graph.ReadOnly = true;
            this.Graph.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSinceConnection;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignalStrength;
        private System.Windows.Forms.DataGridViewButtonColumn Graph;

        private void setVariables() {

            this.dataGridView.Rows.Add("1234", "TotallyPackage", "0", "9001");
        }

    }
}

