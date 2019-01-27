namespace Presentacion
{
    partial class formJugadores
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
            this.cbTeamFiltro = new System.Windows.Forms.ComboBox();
            this.cbYearFiltro = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEquipoFiltro = new System.Windows.Forms.Label();
            this.txtNameFiltro = new System.Windows.Forms.Label();
            this.tbNameFiltro = new System.Windows.Forms.TextBox();
            this.dgPlayers = new System.Windows.Forms.DataGridView();
            this.gbDataPlayer = new System.Windows.Forms.GroupBox();
            this.txtErrorTeam = new System.Windows.Forms.Label();
            this.cbTeam = new System.Windows.Forms.ComboBox();
            this.txtEquipo = new System.Windows.Forms.Label();
            this.btnAvatar = new System.Windows.Forms.Button();
            this.dtFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtErrorFechaNac = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.Label();
            this.txtErrorPuestoHab = new System.Windows.Forms.Label();
            this.tbPuestoHab = new System.Windows.Forms.TextBox();
            this.txtPuestoHab = new System.Windows.Forms.Label();
            this.btnCancelForm = new System.Windows.Forms.Button();
            this.btnSendForm = new System.Windows.Forms.Button();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.txtErrorAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            this.gbDataPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.cbTeamFiltro);
            this.groupBox1.Controls.Add(this.cbYearFiltro);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEquipoFiltro);
            this.groupBox1.Controls.Add(this.txtNameFiltro);
            this.groupBox1.Controls.Add(this.tbNameFiltro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1240, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cbTeamFiltro
            // 
            this.cbTeamFiltro.FormattingEnabled = true;
            this.cbTeamFiltro.Location = new System.Drawing.Point(539, 17);
            this.cbTeamFiltro.Name = "cbTeamFiltro";
            this.cbTeamFiltro.Size = new System.Drawing.Size(200, 21);
            this.cbTeamFiltro.TabIndex = 57;
            // 
            // cbYearFiltro
            // 
            this.cbYearFiltro.FormattingEnabled = true;
            this.cbYearFiltro.Location = new System.Drawing.Point(1043, 22);
            this.cbYearFiltro.Name = "cbYearFiltro";
            this.cbYearFiltro.Size = new System.Drawing.Size(175, 21);
            this.cbYearFiltro.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(539, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 31);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(895, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mundial de participación";
            // 
            // txtEquipoFiltro
            // 
            this.txtEquipoFiltro.AutoSize = true;
            this.txtEquipoFiltro.Location = new System.Drawing.Point(444, 25);
            this.txtEquipoFiltro.Name = "txtEquipoFiltro";
            this.txtEquipoFiltro.Size = new System.Drawing.Size(78, 13);
            this.txtEquipoFiltro.TabIndex = 4;
            this.txtEquipoFiltro.Text = "Equipo jugador";
            // 
            // txtNameFiltro
            // 
            this.txtNameFiltro.AutoSize = true;
            this.txtNameFiltro.Location = new System.Drawing.Point(23, 26);
            this.txtNameFiltro.Name = "txtNameFiltro";
            this.txtNameFiltro.Size = new System.Drawing.Size(82, 13);
            this.txtNameFiltro.TabIndex = 3;
            this.txtNameFiltro.Text = "Nombre jugador";
            // 
            // tbNameFiltro
            // 
            this.tbNameFiltro.Location = new System.Drawing.Point(121, 22);
            this.tbNameFiltro.Name = "tbNameFiltro";
            this.tbNameFiltro.Size = new System.Drawing.Size(238, 20);
            this.tbNameFiltro.TabIndex = 0;
            // 
            // dgPlayers
            // 
            this.dgPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayers.Location = new System.Drawing.Point(12, 115);
            this.dgPlayers.Name = "dgPlayers";
            this.dgPlayers.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgPlayers.Size = new System.Drawing.Size(610, 858);
            this.dgPlayers.TabIndex = 3;
            this.dgPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPlayers_CellClick);
            // 
            // gbDataPlayer
            // 
            this.gbDataPlayer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbDataPlayer.Controls.Add(this.txtErrorTeam);
            this.gbDataPlayer.Controls.Add(this.cbTeam);
            this.gbDataPlayer.Controls.Add(this.txtEquipo);
            this.gbDataPlayer.Controls.Add(this.btnAvatar);
            this.gbDataPlayer.Controls.Add(this.dtFechaNac);
            this.gbDataPlayer.Controls.Add(this.txtErrorFechaNac);
            this.gbDataPlayer.Controls.Add(this.txtFechaNac);
            this.gbDataPlayer.Controls.Add(this.txtErrorPuestoHab);
            this.gbDataPlayer.Controls.Add(this.tbPuestoHab);
            this.gbDataPlayer.Controls.Add(this.txtPuestoHab);
            this.gbDataPlayer.Controls.Add(this.btnCancelForm);
            this.gbDataPlayer.Controls.Add(this.btnSendForm);
            this.gbDataPlayer.Controls.Add(this.pbAvatar);
            this.gbDataPlayer.Controls.Add(this.txtErrorAddress);
            this.gbDataPlayer.Controls.Add(this.tbAddress);
            this.gbDataPlayer.Controls.Add(this.txtAddress);
            this.gbDataPlayer.Controls.Add(this.tbName);
            this.gbDataPlayer.Controls.Add(this.txtName);
            this.gbDataPlayer.Location = new System.Drawing.Point(629, 115);
            this.gbDataPlayer.Name = "gbDataPlayer";
            this.gbDataPlayer.Size = new System.Drawing.Size(623, 858);
            this.gbDataPlayer.TabIndex = 4;
            this.gbDataPlayer.TabStop = false;
            this.gbDataPlayer.Text = "Datos Jugador";
            this.gbDataPlayer.Visible = false;
            // 
            // txtErrorTeam
            // 
            this.txtErrorTeam.AutoSize = true;
            this.txtErrorTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorTeam.Location = new System.Drawing.Point(278, 517);
            this.txtErrorTeam.Name = "txtErrorTeam";
            this.txtErrorTeam.Size = new System.Drawing.Size(105, 13);
            this.txtErrorTeam.TabIndex = 57;
            this.txtErrorTeam.Text = "No puede ser vacío.";
            this.txtErrorTeam.Visible = false;
            // 
            // cbTeam
            // 
            this.cbTeam.FormattingEnabled = true;
            this.cbTeam.Location = new System.Drawing.Point(279, 493);
            this.cbTeam.Name = "cbTeam";
            this.cbTeam.Size = new System.Drawing.Size(200, 21);
            this.cbTeam.TabIndex = 56;
            // 
            // txtEquipo
            // 
            this.txtEquipo.AutoSize = true;
            this.txtEquipo.Location = new System.Drawing.Point(161, 496);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(40, 13);
            this.txtEquipo.TabIndex = 55;
            this.txtEquipo.Text = "Equipo";
            // 
            // btnAvatar
            // 
            this.btnAvatar.Location = new System.Drawing.Point(165, 286);
            this.btnAvatar.Name = "btnAvatar";
            this.btnAvatar.Size = new System.Drawing.Size(307, 23);
            this.btnAvatar.TabIndex = 54;
            this.btnAvatar.Text = "Seleccionar avatar";
            this.btnAvatar.UseVisualStyleBackColor = true;
            this.btnAvatar.Click += new System.EventHandler(this.btnAvatar_Click);
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.Location = new System.Drawing.Point(281, 632);
            this.dtFechaNac.Name = "dtFechaNac";
            this.dtFechaNac.Size = new System.Drawing.Size(196, 20);
            this.dtFechaNac.TabIndex = 53;
            // 
            // txtErrorFechaNac
            // 
            this.txtErrorFechaNac.AutoSize = true;
            this.txtErrorFechaNac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorFechaNac.Location = new System.Drawing.Point(279, 655);
            this.txtErrorFechaNac.Name = "txtErrorFechaNac";
            this.txtErrorFechaNac.Size = new System.Drawing.Size(162, 13);
            this.txtErrorFechaNac.TabIndex = 52;
            this.txtErrorFechaNac.Text = "No puede ser menor de 16 años.";
            this.txtErrorFechaNac.Visible = false;
            // 
            // txtFechaNac
            // 
            this.txtFechaNac.AutoSize = true;
            this.txtFechaNac.Location = new System.Drawing.Point(162, 640);
            this.txtFechaNac.Name = "txtFechaNac";
            this.txtFechaNac.Size = new System.Drawing.Size(91, 13);
            this.txtFechaNac.TabIndex = 51;
            this.txtFechaNac.Text = "Fecha nacimiento";
            // 
            // txtErrorPuestoHab
            // 
            this.txtErrorPuestoHab.AutoSize = true;
            this.txtErrorPuestoHab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorPuestoHab.Location = new System.Drawing.Point(278, 582);
            this.txtErrorPuestoHab.Name = "txtErrorPuestoHab";
            this.txtErrorPuestoHab.Size = new System.Drawing.Size(188, 13);
            this.txtErrorPuestoHab.TabIndex = 49;
            this.txtErrorPuestoHab.Text = "No puede ser de más de 2 caracteres.";
            this.txtErrorPuestoHab.Visible = false;
            // 
            // tbPuestoHab
            // 
            this.tbPuestoHab.Location = new System.Drawing.Point(281, 559);
            this.tbPuestoHab.Name = "tbPuestoHab";
            this.tbPuestoHab.Size = new System.Drawing.Size(197, 20);
            this.tbPuestoHab.TabIndex = 47;
            // 
            // txtPuestoHab
            // 
            this.txtPuestoHab.AutoSize = true;
            this.txtPuestoHab.Location = new System.Drawing.Point(162, 562);
            this.txtPuestoHab.Name = "txtPuestoHab";
            this.txtPuestoHab.Size = new System.Drawing.Size(80, 13);
            this.txtPuestoHab.TabIndex = 48;
            this.txtPuestoHab.Text = "Puesto habitual";
            // 
            // btnCancelForm
            // 
            this.btnCancelForm.Location = new System.Drawing.Point(336, 716);
            this.btnCancelForm.Name = "btnCancelForm";
            this.btnCancelForm.Size = new System.Drawing.Size(142, 23);
            this.btnCancelForm.TabIndex = 46;
            this.btnCancelForm.Text = "Cancelar";
            this.btnCancelForm.UseVisualStyleBackColor = true;
            this.btnCancelForm.Click += new System.EventHandler(this.btnCancelForm_Click);
            // 
            // btnSendForm
            // 
            this.btnSendForm.Location = new System.Drawing.Point(165, 716);
            this.btnSendForm.Name = "btnSendForm";
            this.btnSendForm.Size = new System.Drawing.Size(165, 23);
            this.btnSendForm.TabIndex = 43;
            this.btnSendForm.Text = "Modificar";
            this.btnSendForm.UseVisualStyleBackColor = true;
            this.btnSendForm.Click += new System.EventHandler(this.btnSendForm_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAvatar.Enabled = false;
            this.pbAvatar.ErrorImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Image = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.InitialImage = global::Presentacion.Properties.Resources.user_default;
            this.pbAvatar.Location = new System.Drawing.Point(189, 66);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(260, 203);
            this.pbAvatar.TabIndex = 35;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.Click += new System.EventHandler(this.pbAvatar_Click);
            // 
            // txtErrorAddress
            // 
            this.txtErrorAddress.AutoSize = true;
            this.txtErrorAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtErrorAddress.Location = new System.Drawing.Point(277, 450);
            this.txtErrorAddress.Name = "txtErrorAddress";
            this.txtErrorAddress.Size = new System.Drawing.Size(200, 13);
            this.txtErrorAddress.TabIndex = 39;
            this.txtErrorAddress.Text = "No puede ser de más de 150 caracteres.";
            this.txtErrorAddress.Visible = false;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(280, 427);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(198, 20);
            this.tbAddress.TabIndex = 30;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Location = new System.Drawing.Point(161, 430);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(52, 13);
            this.txtAddress.TabIndex = 34;
            this.txtAddress.Text = "Dirección";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(280, 352);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(198, 20);
            this.tbName.TabIndex = 29;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(161, 355);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(44, 13);
            this.txtName.TabIndex = 32;
            this.txtName.Text = "Nombre";
            // 
            // formJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.gbDataPlayer);
            this.Controls.Add(this.dgPlayers);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "formJugadores";
            this.Text = "Listar y editar jugadores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
            this.gbDataPlayer.ResumeLayout(false);
            this.gbDataPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbYearFiltro;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtEquipoFiltro;
        private System.Windows.Forms.Label txtNameFiltro;
        private System.Windows.Forms.TextBox tbNameFiltro;
        private System.Windows.Forms.DataGridView dgPlayers;
        private System.Windows.Forms.GroupBox gbDataPlayer;
        private System.Windows.Forms.Button btnCancelForm;
        private System.Windows.Forms.Button btnSendForm;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Label txtErrorAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtErrorPuestoHab;
        private System.Windows.Forms.TextBox tbPuestoHab;
        private System.Windows.Forms.Label txtPuestoHab;
        private System.Windows.Forms.DateTimePicker dtFechaNac;
        private System.Windows.Forms.Label txtErrorFechaNac;
        private System.Windows.Forms.Label txtFechaNac;
        private System.Windows.Forms.Button btnAvatar;
        private System.Windows.Forms.ComboBox cbTeam;
        private System.Windows.Forms.Label txtEquipo;
        private System.Windows.Forms.ComboBox cbTeamFiltro;
        private System.Windows.Forms.Label txtErrorTeam;
    }
}