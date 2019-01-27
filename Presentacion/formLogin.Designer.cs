namespace Presentacion
{
    partial class formLogin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkLabel = new System.Windows.Forms.LinkLabel();
            this.btAcceder = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkLabel);
            this.groupBox1.Controls.Add(this.btAcceder);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Location = new System.Drawing.Point(563, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 268);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceso a la aplicación";
            // 
            // lnkLabel
            // 
            this.lnkLabel.AutoSize = true;
            this.lnkLabel.Location = new System.Drawing.Point(122, 222);
            this.lnkLabel.Name = "lnkLabel";
            this.lnkLabel.Size = new System.Drawing.Size(148, 13);
            this.lnkLabel.TabIndex = 4;
            this.lnkLabel.TabStop = true;
            this.lnkLabel.Text = "¿Has olvidado la contraseña?";
            this.lnkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel_LinkClicked);
            // 
            // btAcceder
            // 
            this.btAcceder.BackColor = System.Drawing.SystemColors.Window;
            this.btAcceder.Location = new System.Drawing.Point(7, 128);
            this.btAcceder.Name = "btAcceder";
            this.btAcceder.Size = new System.Drawing.Size(370, 56);
            this.btAcceder.TabIndex = 3;
            this.btAcceder.Text = "Acceder";
            this.btAcceder.UseVisualStyleBackColor = false;
            this.btAcceder.Click += new System.EventHandler(this.btAcceder_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(7, 81);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(370, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "Contraseña";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(7, 55);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(370, 20);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Presentacion.Properties.Resources._280_MAG_FIFA;
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 532);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(991, 556);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "formLogin";
            this.ShowIcon = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAcceder;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkLabel;
    }
}