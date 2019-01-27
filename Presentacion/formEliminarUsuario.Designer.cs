namespace Presentacion
{
    partial class formEliminarUsuario
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
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.gbDatosUsuario = new System.Windows.Forms.GroupBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnSendForm = new System.Windows.Forms.Button();
            this.txtRol = new System.Windows.Forms.Label();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.txtNick = new System.Windows.Forms.Label();
            this.txtErrorSurname = new System.Windows.Forms.Label();
            this.txtErrorName = new System.Windows.Forms.Label();
            this.txtErrorNick = new System.Windows.Forms.Label();
            this.txtErrorEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.Label();
            this.btnCancelForm = new System.Windows.Forms.Button();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            this.gbDatosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgUsers
            // 
            this.dgUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Location = new System.Drawing.Point(12, 12);
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgUsers.Size = new System.Drawing.Size(610, 960);
            this.dgUsers.TabIndex = 1;
            this.dgUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsers_CellClick);
            // 
            // gbDatosUsuario
            // 
            this.gbDatosUsuario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbDatosUsuario.Controls.Add(this.btnCancelForm);
            this.gbDatosUsuario.Controls.Add(this.cbRol);
            this.gbDatosUsuario.Controls.Add(this.cbActive);
            this.gbDatosUsuario.Controls.Add(this.btnSendForm);
            this.gbDatosUsuario.Controls.Add(this.txtRol);
            this.gbDatosUsuario.Controls.Add(this.tbNick);
            this.gbDatosUsuario.Controls.Add(this.pbAvatar);
            this.gbDatosUsuario.Controls.Add(this.txtNick);
            this.gbDatosUsuario.Controls.Add(this.txtErrorSurname);
            this.gbDatosUsuario.Controls.Add(this.txtErrorName);
            this.gbDatosUsuario.Controls.Add(this.txtErrorNick);
            this.gbDatosUsuario.Controls.Add(this.txtErrorEmail);
            this.gbDatosUsuario.Controls.Add(this.txtEmail);
            this.gbDatosUsuario.Controls.Add(this.tbEmail);
            this.gbDatosUsuario.Controls.Add(this.tbSurname);
            this.gbDatosUsuario.Controls.Add(this.txtSurname);
            this.gbDatosUsuario.Controls.Add(this.tbName);
            this.gbDatosUsuario.Controls.Add(this.txtName);
            this.gbDatosUsuario.Location = new System.Drawing.Point(629, 13);
            this.gbDatosUsuario.Name = "gbDatosUsuario";
            this.gbDatosUsuario.Size = new System.Drawing.Size(623, 960);
            this.gbDatosUsuario.TabIndex = 2;
            this.gbDatosUsuario.TabStop = false;
            this.gbDatosUsuario.Text = "Datos Usuario";
            this.gbDatosUsuario.Visible = false;
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(281, 567);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(168, 21);
            this.cbRol.TabIndex = 40;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(165, 625);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 42;
            this.cbActive.Text = "Activo";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnSendForm
            // 
            this.btnSendForm.Location = new System.Drawing.Point(165, 716);
            this.btnSendForm.Name = "btnSendForm";
            this.btnSendForm.Size = new System.Drawing.Size(138, 23);
            this.btnSendForm.TabIndex = 43;
            this.btnSendForm.Text = "Eliminar";
            this.btnSendForm.UseVisualStyleBackColor = true;
            this.btnSendForm.Click += new System.EventHandler(this.btnSendForm_Click);
            // 
            // txtRol
            // 
            this.txtRol.AutoSize = true;
            this.txtRol.Location = new System.Drawing.Point(162, 570);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(23, 13);
            this.txtRol.TabIndex = 45;
            this.txtRol.Text = "Rol";
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(281, 274);
            this.tbNick.Name = "tbNick";
            this.tbNick.ShortcutsEnabled = false;
            this.tbNick.Size = new System.Drawing.Size(168, 20);
            this.tbNick.TabIndex = 23;
            // 
            // txtNick
            // 
            this.txtNick.AutoSize = true;
            this.txtNick.Location = new System.Drawing.Point(162, 277);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(29, 13);
            this.txtNick.TabIndex = 22;
            this.txtNick.Text = "Nick";
            // 
            // txtErrorSurname
            // 
            this.txtErrorSurname.AutoSize = true;
            this.txtErrorSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorSurname.Location = new System.Drawing.Point(268, 518);
            this.txtErrorSurname.Name = "txtErrorSurname";
            this.txtErrorSurname.Size = new System.Drawing.Size(200, 13);
            this.txtErrorSurname.TabIndex = 39;
            this.txtErrorSurname.Text = "No puede ser de más de 150 caracteres.";
            this.txtErrorSurname.Visible = false;
            // 
            // txtErrorName
            // 
            this.txtErrorName.AutoSize = true;
            this.txtErrorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorName.Location = new System.Drawing.Point(268, 448);
            this.txtErrorName.Name = "txtErrorName";
            this.txtErrorName.Size = new System.Drawing.Size(194, 13);
            this.txtErrorName.TabIndex = 38;
            this.txtErrorName.Text = "No puede ser de más de 80 caracteres.";
            this.txtErrorName.Visible = false;
            // 
            // txtErrorNick
            // 
            this.txtErrorNick.AutoSize = true;
            this.txtErrorNick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorNick.Location = new System.Drawing.Point(268, 297);
            this.txtErrorNick.Name = "txtErrorNick";
            this.txtErrorNick.Size = new System.Drawing.Size(194, 13);
            this.txtErrorNick.TabIndex = 36;
            this.txtErrorNick.Text = "No puede ser de más de 50 caracteres.";
            this.txtErrorNick.Visible = false;
            // 
            // txtErrorEmail
            // 
            this.txtErrorEmail.AutoSize = true;
            this.txtErrorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorEmail.Location = new System.Drawing.Point(268, 370);
            this.txtErrorEmail.Name = "txtErrorEmail";
            this.txtErrorEmail.Size = new System.Drawing.Size(200, 13);
            this.txtErrorEmail.TabIndex = 37;
            this.txtErrorEmail.Text = "No puede ser de más de 100 caracteres.";
            this.txtErrorEmail.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(162, 350);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(32, 13);
            this.txtEmail.TabIndex = 31;
            this.txtEmail.Text = "Email";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(281, 347);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(168, 20);
            this.tbEmail.TabIndex = 26;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(281, 495);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(168, 20);
            this.tbSurname.TabIndex = 30;
            // 
            // txtSurname
            // 
            this.txtSurname.AutoSize = true;
            this.txtSurname.Location = new System.Drawing.Point(162, 498);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(49, 13);
            this.txtSurname.TabIndex = 34;
            this.txtSurname.Text = "Apellidos";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(281, 425);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(168, 20);
            this.tbName.TabIndex = 29;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(162, 428);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(44, 13);
            this.txtName.TabIndex = 32;
            this.txtName.Text = "Nombre";
            // 
            // btnCancelForm
            // 
            this.btnCancelForm.Location = new System.Drawing.Point(309, 716);
            this.btnCancelForm.Name = "btnCancelForm";
            this.btnCancelForm.Size = new System.Drawing.Size(140, 23);
            this.btnCancelForm.TabIndex = 46;
            this.btnCancelForm.Text = "Cancelar";
            this.btnCancelForm.UseVisualStyleBackColor = true;
            this.btnCancelForm.Click += new System.EventHandler(this.btnCancelForm_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.No;
            this.pbAvatar.Enabled = false;
            this.pbAvatar.ErrorImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Image = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.InitialImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Location = new System.Drawing.Point(176, 19);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(260, 203);
            this.pbAvatar.TabIndex = 35;
            this.pbAvatar.TabStop = false;
            // 
            // formEliminarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.gbDatosUsuario);
            this.Controls.Add(this.dgUsers);
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "formEliminarUsuario";
            this.Text = "formEliminarUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.gbDatosUsuario.ResumeLayout(false);
            this.gbDatosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.GroupBox gbDatosUsuario;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnSendForm;
        private System.Windows.Forms.Label txtRol;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Label txtNick;
        private System.Windows.Forms.Label txtErrorSurname;
        private System.Windows.Forms.Label txtErrorName;
        private System.Windows.Forms.Label txtErrorNick;
        private System.Windows.Forms.Label txtErrorEmail;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label txtSurname;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button btnCancelForm;
    }
}