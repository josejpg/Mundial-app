namespace Presentacion
{
    partial class formPswRecovery
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
            this.tbPsw = new System.Windows.Forms.TextBox();
            this.tbPsw2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPsw = new System.Windows.Forms.Label();
            this.txtPsw2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPsw
            // 
            this.tbPsw.Location = new System.Drawing.Point(119, 83);
            this.tbPsw.Name = "tbPsw";
            this.tbPsw.PasswordChar = '*';
            this.tbPsw.Size = new System.Drawing.Size(211, 20);
            this.tbPsw.TabIndex = 4;
            // 
            // tbPsw2
            // 
            this.tbPsw2.Location = new System.Drawing.Point(119, 117);
            this.tbPsw2.Name = "tbPsw2";
            this.tbPsw2.PasswordChar = '*';
            this.tbPsw2.Size = new System.Drawing.Size(211, 20);
            this.tbPsw2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Asistente para cambiar su contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(318, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPsw
            // 
            this.txtPsw.AutoSize = true;
            this.txtPsw.Location = new System.Drawing.Point(12, 86);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(95, 13);
            this.txtPsw.TabIndex = 3;
            this.txtPsw.Text = "Nueva contraseña";
            // 
            // txtPsw2
            // 
            this.txtPsw2.AutoSize = true;
            this.txtPsw2.Location = new System.Drawing.Point(9, 120);
            this.txtPsw2.Name = "txtPsw2";
            this.txtPsw2.Size = new System.Drawing.Size(104, 13);
            this.txtPsw2.TabIndex = 5;
            this.txtPsw2.Text = "Confirme contraseña";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(119, 47);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(211, 20);
            this.tbUser.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Location = new System.Drawing.Point(12, 50);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(43, 13);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "Usuario";
            // 
            // formPswRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 209);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.txtPsw2);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.tbPsw2);
            this.Controls.Add(this.tbPsw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "formPswRecovery";
            this.Text = "Recuperar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPsw;
        private System.Windows.Forms.TextBox tbPsw2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtPsw;
        private System.Windows.Forms.Label txtPsw2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label txtUser;
    }
}