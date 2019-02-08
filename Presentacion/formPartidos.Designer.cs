namespace Presentacion
{
    partial class formPartidos
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cbYearFiltro = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.btBuscarPartidos = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbNameFiltro = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbFiltros.Controls.Add(this.btnModificar);
            this.gbFiltros.Controls.Add(this.cbYearFiltro);
            this.gbFiltros.Controls.Add(this.lblYear);
            this.gbFiltros.Controls.Add(this.btBuscarPartidos);
            this.gbFiltros.Controls.Add(this.lblName);
            this.gbFiltros.Controls.Add(this.tbNameFiltro);
            this.gbFiltros.Location = new System.Drawing.Point(18, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(1227, 62);
            this.gbFiltros.TabIndex = 11;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1070, 22);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(136, 25);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cbYearFiltro
            // 
            this.cbYearFiltro.FormattingEnabled = true;
            this.cbYearFiltro.Location = new System.Drawing.Point(537, 24);
            this.cbYearFiltro.Name = "cbYearFiltro";
            this.cbYearFiltro.Size = new System.Drawing.Size(216, 21);
            this.cbYearFiltro.TabIndex = 12;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(442, 28);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(66, 13);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Año Mundial";
            // 
            // btBuscarPartidos
            // 
            this.btBuscarPartidos.Location = new System.Drawing.Point(808, 22);
            this.btBuscarPartidos.Name = "btBuscarPartidos";
            this.btBuscarPartidos.Size = new System.Drawing.Size(230, 25);
            this.btBuscarPartidos.TabIndex = 6;
            this.btBuscarPartidos.Text = "Buscar partidos";
            this.btBuscarPartidos.UseVisualStyleBackColor = true;
            this.btBuscarPartidos.Click += new System.EventHandler(this.btBuscarPartidos_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Nombre equipo";
            // 
            // tbNameFiltro
            // 
            this.tbNameFiltro.Location = new System.Drawing.Point(126, 24);
            this.tbNameFiltro.Name = "tbNameFiltro";
            this.tbNameFiltro.Size = new System.Drawing.Size(238, 20);
            this.tbNameFiltro.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1220, 859);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // formPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbFiltros);
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "formPartidos";
            this.Text = "formPartidos";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btBuscarPartidos;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbNameFiltro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbYearFiltro;
        private System.Windows.Forms.Button btnModificar;
    }
}