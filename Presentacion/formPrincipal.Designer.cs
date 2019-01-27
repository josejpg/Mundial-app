namespace Presentacion
{
    partial class formPrincipal
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
            this.msFormPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añoDelMundialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msFormPrincipalUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.msFormPrincipalUsuariosInsertar = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jugadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.partidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unPartidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificaciónDeUnMundialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarEnHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.sbHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msFormPrincipal.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // msFormPrincipal
            // 
            this.msFormPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.msFormPrincipalUsuarios,
            this.jugadoresToolStripMenuItem,
            this.equiposToolStripMenuItem,
            this.partidosToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.ventanaToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.userToolStripMenuItem});
            this.msFormPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msFormPrincipal.Name = "msFormPrincipal";
            this.msFormPrincipal.Size = new System.Drawing.Size(1264, 24);
            this.msFormPrincipal.TabIndex = 0;
            this.msFormPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añoDelMundialToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // añoDelMundialToolStripMenuItem
            // 
            this.añoDelMundialToolStripMenuItem.Name = "añoDelMundialToolStripMenuItem";
            this.añoDelMundialToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.añoDelMundialToolStripMenuItem.Text = "Año del mundial";
            this.añoDelMundialToolStripMenuItem.Click += new System.EventHandler(this.añoDelMundialToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // msFormPrincipalUsuarios
            // 
            this.msFormPrincipalUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFormPrincipalUsuariosInsertar,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.msFormPrincipalUsuarios.Name = "msFormPrincipalUsuarios";
            this.msFormPrincipalUsuarios.Size = new System.Drawing.Size(89, 20);
            this.msFormPrincipalUsuarios.Text = "Usuarios App";
            // 
            // msFormPrincipalUsuariosInsertar
            // 
            this.msFormPrincipalUsuariosInsertar.Name = "msFormPrincipalUsuariosInsertar";
            this.msFormPrincipalUsuariosInsertar.Size = new System.Drawing.Size(125, 22);
            this.msFormPrincipalUsuariosInsertar.Text = "Insertar";
            this.msFormPrincipalUsuariosInsertar.Click += new System.EventHandler(this.msFormPrincipalUsuariosInsertar_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // jugadoresToolStripMenuItem
            // 
            this.jugadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem});
            this.jugadoresToolStripMenuItem.Name = "jugadoresToolStripMenuItem";
            this.jugadoresToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.jugadoresToolStripMenuItem.Text = "Jugadores";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.consultarToolStripMenuItem.Text = "Consultar y modificar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // equiposToolStripMenuItem
            // 
            this.equiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem1});
            this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
            this.equiposToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.equiposToolStripMenuItem.Text = "Equipos";
            // 
            // consultarToolStripMenuItem1
            // 
            this.consultarToolStripMenuItem1.Name = "consultarToolStripMenuItem1";
            this.consultarToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.consultarToolStripMenuItem1.Text = "Consultar";
            // 
            // partidosToolStripMenuItem
            // 
            this.partidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem,
            this.modificarToolStripMenuItem2});
            this.partidosToolStripMenuItem.Name = "partidosToolStripMenuItem";
            this.partidosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.partidosToolStripMenuItem.Text = "Partidos";
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            // 
            // modificarToolStripMenuItem2
            // 
            this.modificarToolStripMenuItem2.Name = "modificarToolStripMenuItem2";
            this.modificarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem2.Text = "Modificar";
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unPartidoToolStripMenuItem,
            this.clasificaciónDeUnMundialToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // unPartidoToolStripMenuItem
            // 
            this.unPartidoToolStripMenuItem.Name = "unPartidoToolStripMenuItem";
            this.unPartidoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.unPartidoToolStripMenuItem.Text = "Un Partido";
            // 
            // clasificaciónDeUnMundialToolStripMenuItem
            // 
            this.clasificaciónDeUnMundialToolStripMenuItem.Name = "clasificaciónDeUnMundialToolStripMenuItem";
            this.clasificaciónDeUnMundialToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.clasificaciónDeUnMundialToolStripMenuItem.Text = "Clasificación de un mundial";
            // 
            // ventanaToolStripMenuItem
            // 
            this.ventanaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizarVerticalToolStripMenuItem,
            this.organizarEnHorizontalToolStripMenuItem});
            this.ventanaToolStripMenuItem.Name = "ventanaToolStripMenuItem";
            this.ventanaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ventanaToolStripMenuItem.Text = "Ventana";
            // 
            // organizarVerticalToolStripMenuItem
            // 
            this.organizarVerticalToolStripMenuItem.Name = "organizarVerticalToolStripMenuItem";
            this.organizarVerticalToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.organizarVerticalToolStripMenuItem.Text = "Organizar vertical";
            this.organizarVerticalToolStripMenuItem.Click += new System.EventHandler(this.organizarVerticalToolStripMenuItem_Click);
            // 
            // organizarEnHorizontalToolStripMenuItem
            // 
            this.organizarEnHorizontalToolStripMenuItem.Name = "organizarEnHorizontalToolStripMenuItem";
            this.organizarEnHorizontalToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.organizarEnHorizontalToolStripMenuItem.Text = "Organizar en horizontal";
            this.organizarEnHorizontalToolStripMenuItem.Click += new System.EventHandler(this.organizarEnHorizontalToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbHora});
            this.statusBar.Location = new System.Drawing.Point(0, 963);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1264, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // sbHora
            // 
            this.sbHora.Name = "sbHora";
            this.sbHora.Size = new System.Drawing.Size(82, 17);
            this.sbHora.Text = "Fecha Sistema";
            this.sbHora.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.msFormPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msFormPrincipal;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "formPrincipal";
            this.Text = "Mundial";
            this.msFormPrincipal.ResumeLayout(false);
            this.msFormPrincipal.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msFormPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msFormPrincipalUsuarios;
        private System.Windows.Forms.ToolStripMenuItem msFormPrincipalUsuariosInsertar;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añoDelMundialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jugadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem partidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unPartidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificaciónDeUnMundialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizarVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizarEnHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel sbHora;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
    }
}