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
    public partial class formReportMundial : Form
    {

        /// <summary>
        /// Variables
        /// </summary>
        private Negocio.Mundial mundial;
        private List<Entidades.Partido> listPartidos;

        public formReportMundial()
        {
            InitializeComponent();
            for (var year = DateTime.Now.Year; year >= 1900; year--)
            {

                cbYearFiltro.Items.Add(year);

            }
            cbYearFiltro.SelectedItem = formPrincipal.yearPreferences;
            mundial = new Negocio.Mundial();
            btnImprimir.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listPartidos = new List<Entidades.Partido>();
            cbYearFiltro.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            dgPartidosMundial.Enabled = false;
            dgPartidosMundial.DataSource = null;
            try
            {
                listPartidos = mundial.getPartidosAnyo(Convert.ToInt32(cbYearFiltro.SelectedItem));
                dgPartidosMundial.DataSource = listPartidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error recogiendo los datos: " + ex.Message);
            }

            cbYearFiltro.Enabled = true;
            btnBuscar.Enabled = true;
            btnImprimir.Enabled = true;
            dgPartidosMundial.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            formImprimirReportMundial firm = new formImprimirReportMundial();
            firm.listPartidos = listPartidos;
            firm.Year = cbYearFiltro.SelectedItem.ToString();
            firm.Width = 1280;
            firm.Height = 1024;
            firm.Show();
        }
        /// <summary>
        /// Activa el botón para imprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPartidosMundial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnImprimir.Enabled = true;
        }
    }
}
