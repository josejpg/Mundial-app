using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formPrincipal : Form
    {

        private Entidades.Usuario usuario;
        public static DateTime MundialPreferenciaAnyo { get; set; }
        private string rolTipo;
        private Mundial mundial;
        private double tiempoSegundos = 0;
        private double tiempoMinutos = 0;
        private double tiempoHoras = 0;

        public formPrincipal(Entidades.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.mundial = new Mundial();
            this.rolTipo = "";
            this.FormClosing += FormPrincipal_FormClosing;
            this.CompruebaRolUser();
            MundialPreferenciaAnyo = DateTime.Now;


            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

        }

        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            tiempoSegundos += 1;

            tiempoMinutos = Math.Round( tiempoSegundos / 60, 0);
            tiempoHoras = Math.Round(tiempoMinutos / 6, 0);

            sbHora.Text = "Hora del sistema: "+DateTime.Now.ToShortTimeString() +"  |  Tiempo de uso: "+tiempoHoras+":"+tiempoMinutos+":"+tiempoSegundos;
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea cerrar la aplicación?", "Mensaje de confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Invocamos al forms de insertar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void msFormPrincipalUsuariosInsertar_Click(object sender, EventArgs e)
        {
            //Creamos un formulario formusuariosinsertar que será hijo de formprincipal y lo mostramos.
            formInsertarUsuariosAPP fui = new formInsertarUsuariosAPP();
            fui.MdiParent = this;
            fui.WindowState = FormWindowState.Maximized;
            fui.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea cerrar la aplicación?", "Mensaje de confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            } 
        }

        private void CompruebaRolUser()
        {
            try
            {
                foreach (var rol in utils.comboBoxRol())
                {
                    if (rol.IdRol == usuario.IdRol)
                    {
                        this.rolTipo = rol.DescRol;
                    }
                }

                if (this.rolTipo == "Usuario")
                {
                    msFormPrincipalUsuarios.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error obteniendo los roles de la bd: " + ex.Message);
            }
        }


        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
 
        private void organizarVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void organizarEnHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 acercade = new AboutBox1();
            acercade.MdiParent = this;
            acercade.WindowState = FormWindowState.Maximized;
            acercade.Show();
        }
    }
}
