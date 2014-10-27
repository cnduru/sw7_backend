namespace Server
{
    partial class Form1
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
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendTestData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(96, 10);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(176, 23);
            this.buttonLaunch.TabIndex = 0;
            this.buttonLaunch.Text = "Launch";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Location = new System.Drawing.Point(65, 35);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(35, 13);
            this.labelServerStatus.TabIndex = 2;
            this.labelServerStatus.Text = "label2";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(13, 12);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(77, 20);
            this.textBoxPort.TabIndex = 3;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(65, 52);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(35, 13);
            this.labelData.TabIndex = 4;
            this.labelData.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "# clients:";
            // 
            // buttonSendTestData
            // 
            this.buttonSendTestData.Location = new System.Drawing.Point(147, 40);
            this.buttonSendTestData.Name = "buttonSendTestData";
            this.buttonSendTestData.Size = new System.Drawing.Size(125, 23);
            this.buttonSendTestData.TabIndex = 6;
            this.buttonSendTestData.Text = "Send test data";
            this.buttonSendTestData.UseVisualStyleBackColor = true;
            this.buttonSendTestData.Click += new System.EventHandler(this.buttonSendTestData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 74);
            this.Controls.Add(this.buttonSendTestData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLaunch);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.TextBox textBoxPort;
        public System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendTestData;
    }
}

