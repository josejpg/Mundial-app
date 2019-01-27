namespace Presentacion
{
    partial class formInsertarUsuario
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
            this.txtNick = new System.Windows.Forms.Label();
            this.txtPsw = new System.Windows.Forms.Label();
            this.txtPsw2 = new System.Windows.Forms.Label();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.tbPsw = new System.Windows.Forms.TextBox();
            this.tbPsw2 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.txtStartDate = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.Label();
            this.txtErrorNick = new System.Windows.Forms.Label();
            this.txtErrorEmail = new System.Windows.Forms.Label();
            this.txtErrorName = new System.Windows.Forms.Label();
            this.txtErrorSurname = new System.Windows.Forms.Label();
            this.txtErrorStartDate = new System.Windows.Forms.Label();
            this.btnSendForm = new System.Windows.Forms.Button();
            this.btnAvatar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNick
            // 
            this.txtNick.AutoSize = true;
            this.txtNick.Location = new System.Drawing.Point(118, 355);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(29, 13);
            this.txtNick.TabIndex = 0;
            this.txtNick.Text = "Nick";
            // 
            // txtPsw
            // 
            this.txtPsw.AutoSize = true;
            this.txtPsw.Location = new System.Drawing.Point(118, 491);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(61, 13);
            this.txtPsw.TabIndex = 1;
            this.txtPsw.Text = "Contraseña";
            // 
            // txtPsw2
            // 
            this.txtPsw2.AutoSize = true;
            this.txtPsw2.Location = new System.Drawing.Point(118, 548);
            this.txtPsw2.Name = "txtPsw2";
            this.txtPsw2.Size = new System.Drawing.Size(97, 13);
            this.txtPsw2.TabIndex = 2;
            this.txtPsw2.Text = "Repetir contraseña";
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(237, 352);
            this.tbNick.Name = "tbNick";
            this.tbNick.ShortcutsEnabled = false;
            this.tbNick.Size = new System.Drawing.Size(168, 20);
            this.tbNick.TabIndex = 1;
            this.tbNick.TextChanged += new System.EventHandler(this.tbNick_TextChanged);
            // 
            // tbPsw
            // 
            this.tbPsw.Location = new System.Drawing.Point(237, 488);
            this.tbPsw.Name = "tbPsw";
            this.tbPsw.PasswordChar = '*';
            this.tbPsw.Size = new System.Drawing.Size(168, 20);
            this.tbPsw.TabIndex = 3;
            // 
            // tbPsw2
            // 
            this.tbPsw2.Location = new System.Drawing.Point(237, 545);
            this.tbPsw2.Name = "tbPsw2";
            this.tbPsw2.PasswordChar = '*';
            this.tbPsw2.Size = new System.Drawing.Size(168, 20);
            this.tbPsw2.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(118, 428);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(32, 13);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Text = "Email";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(237, 425);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(168, 20);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(118, 602);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(44, 13);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "Nombre";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(237, 599);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(168, 20);
            this.tbName.TabIndex = 5;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.AutoSize = true;
            this.txtSurname.Location = new System.Drawing.Point(118, 672);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(49, 13);
            this.txtSurname.TabIndex = 10;
            this.txtSurname.Text = "Apellidos";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(237, 669);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(168, 20);
            this.tbSurname.TabIndex = 6;
            this.tbSurname.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(121, 154);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 9;
            this.cbActive.Text = "Activo";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(221, 84);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(168, 20);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(221, 16);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(168, 21);
            this.cbRol.TabIndex = 7;
            // 
            // txtStartDate
            // 
            this.txtStartDate.AutoSize = true;
            this.txtStartDate.Location = new System.Drawing.Point(118, 90);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(72, 13);
            this.txtStartDate.TabIndex = 16;
            this.txtStartDate.Text = "Fecha de alta";
            // 
            // txtRol
            // 
            this.txtRol.AutoSize = true;
            this.txtRol.Location = new System.Drawing.Point(118, 19);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(23, 13);
            this.txtRol.TabIndex = 17;
            this.txtRol.Text = "Rol";
            // 
            // txtErrorNick
            // 
            this.txtErrorNick.AutoSize = true;
            this.txtErrorNick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorNick.Location = new System.Drawing.Point(224, 375);
            this.txtErrorNick.Name = "txtErrorNick";
            this.txtErrorNick.Size = new System.Drawing.Size(194, 13);
            this.txtErrorNick.TabIndex = 18;
            this.txtErrorNick.Text = "No puede ser de más de 50 caracteres.";
            this.txtErrorNick.Visible = false;
            // 
            // txtErrorEmail
            // 
            this.txtErrorEmail.AutoSize = true;
            this.txtErrorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorEmail.Location = new System.Drawing.Point(224, 448);
            this.txtErrorEmail.Name = "txtErrorEmail";
            this.txtErrorEmail.Size = new System.Drawing.Size(200, 13);
            this.txtErrorEmail.TabIndex = 19;
            this.txtErrorEmail.Text = "No puede ser de más de 100 caracteres.";
            this.txtErrorEmail.Visible = false;
            // 
            // txtErrorName
            // 
            this.txtErrorName.AutoSize = true;
            this.txtErrorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorName.Location = new System.Drawing.Point(224, 622);
            this.txtErrorName.Name = "txtErrorName";
            this.txtErrorName.Size = new System.Drawing.Size(194, 13);
            this.txtErrorName.TabIndex = 20;
            this.txtErrorName.Text = "No puede ser de más de 80 caracteres.";
            this.txtErrorName.Visible = false;
            // 
            // txtErrorSurname
            // 
            this.txtErrorSurname.AutoSize = true;
            this.txtErrorSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorSurname.Location = new System.Drawing.Point(224, 692);
            this.txtErrorSurname.Name = "txtErrorSurname";
            this.txtErrorSurname.Size = new System.Drawing.Size(200, 13);
            this.txtErrorSurname.TabIndex = 21;
            this.txtErrorSurname.Text = "No puede ser de más de 150 caracteres.";
            this.txtErrorSurname.Visible = false;
            // 
            // txtErrorStartDate
            // 
            this.txtErrorStartDate.AutoSize = true;
            this.txtErrorStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorStartDate.Location = new System.Drawing.Point(227, 107);
            this.txtErrorStartDate.Name = "txtErrorStartDate";
            this.txtErrorStartDate.Size = new System.Drawing.Size(149, 13);
            this.txtErrorStartDate.TabIndex = 22;
            this.txtErrorStartDate.Text = "No puede ser de mayor a hoy.";
            this.txtErrorStartDate.Visible = false;
            // 
            // btnSendForm
            // 
            this.btnSendForm.Location = new System.Drawing.Point(121, 216);
            this.btnSendForm.Name = "btnSendForm";
            this.btnSendForm.Size = new System.Drawing.Size(268, 23);
            this.btnSendForm.TabIndex = 11;
            this.btnSendForm.Text = "Enviar";
            this.btnSendForm.UseVisualStyleBackColor = true;
            this.btnSendForm.Click += new System.EventHandler(this.btnSendForm_Click);
            // 
            // btnAvatar
            // 
            this.btnAvatar.Location = new System.Drawing.Point(121, 267);
            this.btnAvatar.Name = "btnAvatar";
            this.btnAvatar.Size = new System.Drawing.Size(284, 23);
            this.btnAvatar.TabIndex = 10;
            this.btnAvatar.Text = "Seleccionar avatar";
            this.btnAvatar.UseVisualStyleBackColor = true;
            this.btnAvatar.Click += new System.EventHandler(this.btnAvatar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.tbNick);
            this.groupBox1.Controls.Add(this.pbAvatar);
            this.groupBox1.Controls.Add(this.txtNick);
            this.groupBox1.Controls.Add(this.txtErrorSurname);
            this.groupBox1.Controls.Add(this.btnAvatar);
            this.groupBox1.Controls.Add(this.txtErrorName);
            this.groupBox1.Controls.Add(this.txtErrorNick);
            this.groupBox1.Controls.Add(this.txtErrorEmail);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.txtPsw);
            this.groupBox1.Controls.Add(this.txtPsw2);
            this.groupBox1.Controls.Add(this.tbSurname);
            this.groupBox1.Controls.Add(this.tbPsw);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.tbPsw2);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 864);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.cbRol);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.cbActive);
            this.groupBox2.Controls.Add(this.txtStartDate);
            this.groupBox2.Controls.Add(this.btnSendForm);
            this.groupBox2.Controls.Add(this.txtErrorStartDate);
            this.groupBox2.Controls.Add(this.txtRol);
            this.groupBox2.Location = new System.Drawing.Point(670, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 290);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Registro";
            // 
            // pbAvatar
            // 
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAvatar.ErrorImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Image = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.InitialImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Location = new System.Drawing.Point(132, 19);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(260, 203);
            this.pbAvatar.TabIndex = 13;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.Click += new System.EventHandler(this.pbAvatar_Click);
            // 
            // formInsertarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "formInsertarUsuario";
            this.Text = "Insertar Usuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtNick;
        private System.Windows.Forms.Label txtPsw;
        private System.Windows.Forms.Label txtPsw2;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.TextBox tbPsw;
        private System.Windows.Forms.TextBox tbPsw2;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label txtSurname;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label txtStartDate;
        private System.Windows.Forms.Label txtRol;
        private System.Windows.Forms.Label txtErrorNick;
        private System.Windows.Forms.Label txtErrorEmail;
        private System.Windows.Forms.Label txtErrorName;
        private System.Windows.Forms.Label txtErrorSurname;
        private System.Windows.Forms.Label txtErrorStartDate;
        private System.Windows.Forms.Button btnSendForm;
        private System.Windows.Forms.Button btnAvatar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}