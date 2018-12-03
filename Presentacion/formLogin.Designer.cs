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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btAcceder = new System.Windows.Forms.Button();
            this.btRecPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(51, 303);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(294, 20);
            this.tbUser.TabIndex = 4;
            this.tbUser.Text = "Usuario";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(51, 340);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(294, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.Text = "Contraseña";
            // 
            // btAcceder
            // 
            this.btAcceder.BackColor = System.Drawing.SystemColors.Window;
            this.btAcceder.Location = new System.Drawing.Point(51, 387);
            this.btAcceder.Name = "btAcceder";
            this.btAcceder.Size = new System.Drawing.Size(294, 31);
            this.btAcceder.TabIndex = 3;
            this.btAcceder.Text = "Acceder";
            this.btAcceder.UseVisualStyleBackColor = false;
            this.btAcceder.Click += new System.EventHandler(this.btAcceder_Click);
            // 
            // btRecPass
            // 
            this.btRecPass.BackColor = System.Drawing.Color.White;
            this.btRecPass.Location = new System.Drawing.Point(51, 424);
            this.btRecPass.Name = "btRecPass";
            this.btRecPass.Size = new System.Drawing.Size(294, 23);
            this.btRecPass.TabIndex = 4;
            this.btRecPass.Text = "¿Has olvidado contraseña?";
            this.btRecPass.UseVisualStyleBackColor = false;
            this.btRecPass.Click += new System.EventHandler(this.btRecPass_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(991, 556);
            this.Controls.Add(this.btRecPass);
            this.Controls.Add(this.btAcceder);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btAcceder;
        private System.Windows.Forms.Button btRecPass;
    }
}