namespace sibfalcerueu
{
    partial class SetDB
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtserver = new MetroFramework.Controls.MetroTextBox();
            this.txtuid = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtpass = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtnama = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Server DB";
            // 
            // txtserver
            // 
            this.txtserver.Lines = new string[0];
            this.txtserver.Location = new System.Drawing.Point(114, 76);
            this.txtserver.MaxLength = 32767;
            this.txtserver.Name = "txtserver";
            this.txtserver.PasswordChar = '\0';
            this.txtserver.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtserver.SelectedText = "";
            this.txtserver.Size = new System.Drawing.Size(214, 23);
            this.txtserver.TabIndex = 1;
            this.txtserver.UseSelectable = true;
            // 
            // txtuid
            // 
            this.txtuid.Lines = new string[0];
            this.txtuid.Location = new System.Drawing.Point(114, 151);
            this.txtuid.MaxLength = 32767;
            this.txtuid.Name = "txtuid";
            this.txtuid.PasswordChar = '\0';
            this.txtuid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtuid.SelectedText = "";
            this.txtuid.Size = new System.Drawing.Size(214, 23);
            this.txtuid.TabIndex = 3;
            this.txtuid.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 155);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Username DB";
            // 
            // txtpass
            // 
            this.txtpass.Lines = new string[0];
            this.txtpass.Location = new System.Drawing.Point(114, 189);
            this.txtpass.MaxLength = 32767;
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '\0';
            this.txtpass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtpass.SelectedText = "";
            this.txtpass.Size = new System.Drawing.Size(214, 23);
            this.txtpass.TabIndex = 5;
            this.txtpass.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 193);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(84, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Passwrod DB";
            // 
            // txtnama
            // 
            this.txtnama.Lines = new string[0];
            this.txtnama.Location = new System.Drawing.Point(114, 111);
            this.txtnama.MaxLength = 32767;
            this.txtnama.Name = "txtnama";
            this.txtnama.PasswordChar = '\0';
            this.txtnama.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtnama.SelectedText = "";
            this.txtnama.Size = new System.Drawing.Size(214, 23);
            this.txtnama.TabIndex = 7;
            this.txtnama.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 115);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(66, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Nama DB";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(18, 243);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(131, 52);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Test connection";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Enabled = false;
            this.metroButton2.Location = new System.Drawing.Point(180, 243);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(131, 52);
            this.metroButton2.TabIndex = 9;
            this.metroButton2.Text = "Submit!";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // SetDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 333);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtnama);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtuid);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtserver);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "SetDB";
            this.Text = "SetDB";
            this.Load += new System.EventHandler(this.SetDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtserver;
        private MetroFramework.Controls.MetroTextBox txtuid;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtpass;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtnama;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}