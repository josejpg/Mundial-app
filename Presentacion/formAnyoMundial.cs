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
    public partial class formAnyoMundial : Form
    {
        public formAnyoMundial()
        {
            InitializeComponent();


            for ( var year = DateTime.Now.Year; year >= 1900; year--)
            {

                cbYear.Items.Add(year) ;

            }
            cbYear.SelectedItem = formPrincipal.yearPreferences;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formPrincipal.yearPreferences = (int)cbYear.SelectedItem;
            getPartidos();
        }

        /// <summary>
        /// Se cargan en el DataGrid los partidos correspondientes al año seleccionado
        /// </summary>
        private void getPartidos()
        {
            Negocio.Mundial mundial;
            List<Entidades.Partido> listPartidos;
            cbYear.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView1.DataSource = null;
            try
            {
                mundial = new Negocio.Mundial();
                listPartidos = mundial.getPartidosAnyo((int)cbYear.SelectedItem);
                dataGridView1.DataSource = listPartidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error obteniendo los datos del mundial: " + ex.Message);
            }

            cbYear.Enabled = true;
            dataGridView1.Enabled = true;
        }
    }
}
