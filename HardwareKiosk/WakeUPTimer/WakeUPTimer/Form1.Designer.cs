namespace WakeUPTimer
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
        	this.components = new System.ComponentModel.Container();
        	this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        	this.lblNow = new System.Windows.Forms.Label();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.label1 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.lblWoken = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// DateTimePicker1
        	// 
        	this.DateTimePicker1.CustomFormat = "yyyy/MM/dd HH.mm.ss";
        	this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.DateTimePicker1.Location = new System.Drawing.Point(83, 51);
        	this.DateTimePicker1.Name = "DateTimePicker1";
        	this.DateTimePicker1.Size = new System.Drawing.Size(160, 20);
        	this.DateTimePicker1.TabIndex = 4;
        	// 
        	// lblNow
        	// 
        	this.lblNow.AutoSize = true;
        	this.lblNow.Location = new System.Drawing.Point(12, 9);
        	this.lblNow.Name = "lblNow";
        	this.lblNow.Size = new System.Drawing.Size(38, 13);
        	this.lblNow.TabIndex = 5;
        	this.lblNow.Text = "Now: -";
        	// 
        	// timer1
        	// 
        	this.timer1.Enabled = true;
        	this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 54);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(66, 13);
        	this.label1.TabIndex = 6;
        	this.label1.Text = "Wake up at:";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(83, 77);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(77, 26);
        	this.button1.TabIndex = 7;
        	this.button1.Text = "Set timer";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(166, 77);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(77, 26);
        	this.button2.TabIndex = 8;
        	this.button2.Text = "Suspend";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// lblWoken
        	// 
        	this.lblWoken.AutoSize = true;
        	this.lblWoken.Location = new System.Drawing.Point(12, 29);
        	this.lblWoken.Name = "lblWoken";
        	this.lblWoken.Size = new System.Drawing.Size(51, 13);
        	this.lblWoken.TabIndex = 9;
        	this.lblWoken.Text = "Woken: -";
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(255, 112);
        	this.Controls.Add(this.lblWoken);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.lblNow);
        	this.Controls.Add(this.DateTimePicker1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.Name = "Form1";
        	this.Text = "WakeUPTimer";
        	this.Load += new System.EventHandler(this.Form1_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblWoken;
    }
}

