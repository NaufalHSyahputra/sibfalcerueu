namespace sibfalcerueu
{
    partial class Login
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
            this.txtusername = new MetroFramework.Controls.MetroTextBox();
            this.txtpassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnsubmit = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Username";
            // 
            // txtusername
            // 
            this.txtusername.Lines = new string[0];
            this.txtusername.Location = new System.Drawing.Point(120, 76);
            this.txtusername.MaxLength = 32767;
            this.txtusername.Name = "txtusername";
            this.txtusername.PasswordChar = '\0';
            this.txtusername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtusername.SelectedText = "";
            this.txtusername.Size = new System.Drawing.Size(196, 23);
            this.txtusername.TabIndex = 1;
            this.txtusername.UseSelectable = true;
            // 
            // txtpassword
            // 
            this.txtpassword.Lines = new string[0];
            this.txtpassword.Location = new System.Drawing.Point(120, 125);
            this.txtpassword.MaxLength = 32767;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtpassword.SelectedText = "";
            this.txtpassword.Size = new System.Drawing.Size(196, 23);
            this.txtpassword.TabIndex = 3;
            this.txtpassword.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 129);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Password";
            // 
            // btnsubmit
            // 
            this.btnsubmit.ActiveControl = null;
            this.btnsubmit.Location = new System.Drawing.Point(23, 174);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(293, 46);
            this.btnsubmit.TabIndex = 4;
            this.btnsubmit.Text = "Login!";
            this.btnsubmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsubmit.UseSelectable = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 242);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtusername;
        private MetroFramework.Controls.MetroTextBox txtpassword;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnsubmit;
    }
}