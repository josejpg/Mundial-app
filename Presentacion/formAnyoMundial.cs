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
    public partial class formAnyoMundial : Form
    {
        public formAnyoMundial()
        {
            InitializeComponent();


            for ( var year = DateTime.Now.Year; year >= 1900; year--)
            {

                comboBox1.Items.Add(year) ;

            }
            comboBox1.SelectedItem = formPrincipal.yearPreferences;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formPrincipal.yearPreferences = (int)comboBox1.SelectedItem;
            getPartidos();
        }

        /// <summary>
        /// Se cargan en el DataGrid los partidos correspondientes al año seleccionado
        /// </summary>
        private void getPartidos()
        {
            Negocio.Mundial mundial;
            List<Entidades.Partido> listPartidos;
            comboBox1.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView1.DataSource = null;
            try
            {
                mundial = new Negocio.Mundial();
                listPartidos = mundial.getPartidos((int)comboBox1.SelectedItem);
                dataGridView1.DataSource = listPartidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error obteniendo los datos del mundial: " + ex.Message);
            }

            comboBox1.Enabled = true;
            dataGridView1.Enabled = true;
        }
    }
}
