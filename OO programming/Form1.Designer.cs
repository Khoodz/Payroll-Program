
namespace OO_programming
{
    /// <summary>
    /// form1 used for the winForms design
    /// </summary>
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
            this.Hours = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstEmployee = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHoursInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hours
            // 
            this.Hours.AutoSize = true;
            this.Hours.Location = new System.Drawing.Point(20, 228);
            this.Hours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(99, 13);
            this.Hours.TabIndex = 2;
            this.Hours.Text = "Hours Worked (hrs)";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(124, 228);
            this.txtHours.Margin = new System.Windows.Forms.Padding(2);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(70, 20);
            this.txtHours.TabIndex = 3;
            this.txtHours.Text = "0";
            this.txtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 284);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 19);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstEmployee);
            this.groupBox1.Controls.Add(this.Hours);
            this.groupBox1.Controls.Add(this.txtHours);
            this.groupBox1.Location = new System.Drawing.Point(34, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(218, 308);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // lstEmployee
            // 
            this.lstEmployee.FormattingEnabled = true;
            this.lstEmployee.Location = new System.Drawing.Point(22, 39);
            this.lstEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(170, 173);
            this.lstEmployee.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtHoursInfo);
            this.groupBox2.Location = new System.Drawing.Point(302, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(211, 308);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Summary";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(137, 262);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 19);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtHoursInfo
            // 
            this.txtHoursInfo.Location = new System.Drawing.Point(17, 35);
            this.txtHoursInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoursInfo.Multiline = true;
            this.txtHoursInfo.Name = "txtHoursInfo";
            this.txtHoursInfo.ReadOnly = true;
            this.txtHoursInfo.Size = new System.Drawing.Size(176, 207);
            this.txtHoursInfo.TabIndex = 0;
            this.txtHoursInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Weekly Payment Calculator";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Hours;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHoursInfo;
        private System.Windows.Forms.ListBox lstEmployee;
        private System.Windows.Forms.Button btnSave;
    }
}

