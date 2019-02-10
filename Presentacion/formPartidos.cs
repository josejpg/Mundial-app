using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formPartidos : Form
    {
        /// <summary>
        /// Variables
        /// </summary>
        private Negocio.Mundial mundial;

        public formPartidos()
        {
            InitializeComponent();

            for (var year = DateTime.Now.Year; year >= 1900; year--)
            {

                cbYearFiltro.Items.Add(year);

            }
            cbYearFiltro.SelectedItem = formPrincipal.yearPreferences;
            this.mundial = new Negocio.Mundial();
        }

        /// <summary>
        /// Recupera los partidos de un mundial según los datos del filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBuscarPartidos_Click(object sender, EventArgs e)
        {
            List<Entidades.Partido> listPartidos;
            this.btnModificar.Visible = false;
            try
            {
                this.dataGridView1.Visible = false;
                String name = (tbNameFiltro.Text != null) ? tbNameFiltro.Text : "";
                int year = (cbYearFiltro.SelectedItem != null) ? (int)cbYearFiltro.SelectedItem : 2109;
                listPartidos = mundial.getPartidos(name, year);
                if (listPartidos.Count > 0)
                {
                    this.dataGridView1.DataSource = listPartidos;
                    this.dataGridView1.Visible = true;
                }
                else
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error al recupear los partidos: " + ex.Message);
            }
        }

        /// <summary>
        /// Cuando se hace click en una celda se activa el botón de modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnModificar.Visible = true;
        }

        /// <summary>
        /// Envía la información del partido a una nueva ventana para ser editado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Entidades.Partido datosPartido;
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    datosPartido = new Entidades.Partido
                    {
                        equipoL = dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                        equipoV = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                        fecha = (DateTime)dataGridView1.CurrentRow.Cells[2].Value,
                        hora = dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                        sede = dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                        resultadoL = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value),
                        resultadoV = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value),
                        asistencia = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value)
                    };

                    formModificarPartido fpd = new formModificarPartido(datosPartido);
                    fpd.MdiParent = this.MdiParent;
                    fpd.WindowState = FormWindowState.Maximized;
                    fpd.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al cargar los datos del partido: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un partido primero.");
            }
        }
    }
}
