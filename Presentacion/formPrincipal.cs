using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public static Entidades.Usuario usuario;
        public static int yearPreferences { get; set; }
        private string rolTipo;
        private Mundial mundial;
        private DateTime d = DateTime.Now;
        private double timeSeg = 0;
        private double timeMin = 0;
        private double timeHour = 0;

        public formPrincipal(Entidades.Usuario user)
        {
            InitializeComponent();
            usuario = user;
            userToolStripMenuItem.Text = (usuario.name + " " + usuario.surname).Trim();
            this.mundial = new Mundial();
            this.rolTipo = "";
            this.FormClosing += FormPrincipal_FormClosing;
            this.CompruebaRolUser();
            yearPreferences = DateTime.Now.Year;


            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler( OnTimedEvent );
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                String timeLapsed = "";
                TimeSpan diffTime = (DateTime.Now - d);

                timeSeg = diffTime.Seconds;
                timeMin = diffTime.Minutes;
                timeHour = diffTime.Hours;

                if (timeHour > 0)
                {
                    timeLapsed += (timeHour > 9) ? timeHour.ToString() : "0" + timeHour.ToString();
                    timeLapsed += "h ";
                }
                if (timeMin > 0)
                {
                    timeLapsed += (timeMin > 9) ? timeMin.ToString() : "0" + timeMin.ToString();
                    timeLapsed += "m ";
                }
                if (timeSeg >= 0)
                {
                    timeLapsed += (timeSeg > 9) ? timeSeg.ToString() : "0" + timeSeg.ToString();
                    timeLapsed += "s";
                }
                
                sbHora.Text = "Hora del sistema: " + DateTime.Now.ToShortTimeString() + "  |  Tiempo de uso: " + timeLapsed;
            }
            catch(Exception ex)
            {
                
            }
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
        /// Se carga la pantalla para crer nuevo usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void msFormPrincipalUsuariosInsertar_Click(object sender, EventArgs e)
        {
            formInsertarUsuario fiu = new formInsertarUsuario();
            fiu.MdiParent = this;
            fiu.WindowState = FormWindowState.Maximized;
            fiu.Show();
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
                    if (rol.idRol == usuario.idRol)
                    {
                        this.rolTipo = rol.descRol;
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
 
        private void organizarVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void organizarEnHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Se carga la pantalla de About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 acercade = new AboutBox1();
            acercade.MdiParent = this;
            acercade.WindowState = FormWindowState.Maximized;
            acercade.Show();
        }

        /// <summary>
        /// Se carga la pantalla para elegir el año de mundial y listar todos sus partidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void añoDelMundialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAnyoMundial anyoMundial = new formAnyoMundial();
            anyoMundial.MdiParent = this;
            anyoMundial.WindowState = FormWindowState.Maximized;
            anyoMundial.Show();
        }

        /// <summary>
        /// Se carga la pantalla para modificar los datos de un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formModificarUsuario fmu = new formModificarUsuario();
            fmu.MdiParent = this;
            fmu.WindowState = FormWindowState.Maximized;
            fmu.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEliminarUsuario feu = new formEliminarUsuario();
            feu.MdiParent = this;
            feu.WindowState = FormWindowState.Maximized;
            feu.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formJugadores fj = new formJugadores();
            fj.MdiParent = this;
            fj.WindowState = FormWindowState.Maximized;
            fj.Show();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPartidos fp = new formPartidos();
            fp.MdiParent = this;
            fp.WindowState = FormWindowState.Maximized;
            fp.Show();
        }

        private void clasificaciónDeUnMundialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReportMundial frm = new formReportMundial();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
