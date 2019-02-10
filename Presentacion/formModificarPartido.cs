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
    public partial class formModificarPartido : Form
    {
        private Negocio.Mundial mundial = new Negocio.Mundial();
        private Entidades.Partido datosPartido;

        public formModificarPartido(Entidades.Partido datosPartido)
        {
            InitializeComponent();

            // Si el rol es Usuario (1001) se desactivan los botones
            if( formPrincipal.usuario.idRol == 1001)
            {
                dtgGolesLocal.Enabled = false;
                dtgGolesVisitante.Enabled = false;
                btAddGolesLocal.Enabled = false;
                btAddGolesVisitante.Enabled = false;
            }
            btDeleteGolesLocal.Enabled = false;
            btDeleteGolesVisitante.Enabled = false;
            this.datosPartido = datosPartido;
            getDatosPartidos();
            getGolesPartido();
        }

        /// <summary>
        /// Recoge todos los datos del partido y los plasma en el formulario
        /// </summary>
        private void getDatosPartidos()
        {
            List<Entidades.Jugar> listLocales = new List<Entidades.Jugar>();
            List<string> listSupLocales = new List<string>();
            List<Entidades.Jugar> listVisitantes = new List<Entidades.Jugar>();
            List<string> listSupVisitantes = new List<string>();

            int titularesLocales = 1;
            int suplentesLocales = 1;

            int titularesVisitantes = 1;
            int suplentesVisitantes = 1;

            lblFecha.Text = $@"Fecha: { datosPartido.FechaPartido }";
            lblSede.Text = $@"Sede: { datosPartido.sede }";
            lblResultado.Text = $@"{ datosPartido.resultadoL } - { datosPartido.resultadoV }";
            lblEquipoL.Text = $@"{ datosPartido.equipoL }";
            lblEquipoV.Text = $@"{ datosPartido.equipoV }";

            try
            {
                listLocales = mundial.getJugadoresPorPartido(datosPartido.equipoL, datosPartido.fecha);
                listVisitantes = mundial.getJugadoresPorPartido(datosPartido.equipoV, datosPartido.fecha);
                foreach (var datosJugador in listLocales)
                {
                    if (titularesLocales <= 11)
                    {
                        if (datosJugador.minJugar == 90)
                        {
                            rtbLocal.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") \n";
                        }
                        else if (datosJugador.minJugar == 120)
                        {
                            rtbLocal.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") \n";
                        }
                        else
                        {
                            rtbLocal.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") -> Sustituido \n";
                            listSupLocales.Add(datosJugador.nombreJug);
                        }
                    }

                    if (titularesLocales > 11)
                    {
                        if (datosJugador.minJugar < 90 && 
                            datosJugador.minJugar < 120 &&
                            suplentesLocales <= listSupLocales.Count)
                            {
                            rtbCambiosLocal.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") entra por " + listSupLocales[ listSupLocales.Count - suplentesLocales ].ToString() + " \n";
                            suplentesLocales++;
                        }
                    }
                    titularesLocales++;
                }
                foreach (var datosJugador in listVisitantes)
                {
                    if (titularesVisitantes <= 11)
                    {
                        if (datosJugador.minJugar == 90)
                        {
                            rtbVisitante.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") \n";
                        }
                        else if (datosJugador.minJugar == 120)
                        {
                            rtbVisitante.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") \n";
                        }
                        else
                        {
                            rtbVisitante.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") -> Sustituido \n";
                            listSupVisitantes.Add(datosJugador.nombreJug);
                        }
                    }

                    if (titularesVisitantes > 11)
                    {
                        if (datosJugador.minJugar < 90 && 
                            datosJugador.minJugar < 120 &&
                            suplentesVisitantes <= listSupVisitantes.Count)
                            {
                            rtbCambiosVisitante.Text += datosJugador.nombreJug + " (" + datosJugador.minJugar + ") entra por " + listSupVisitantes[listSupVisitantes.Count - suplentesVisitantes].ToString() + " \n";
                            suplentesVisitantes++;
                        }
                    }
                    titularesVisitantes++;
                }

                setCombo(listLocales, listVisitantes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error recogiendo los datos del partido: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga los comboBox con los jugadores del partido
        /// </summary>
        /// <param name="listLocales"></param>
        /// <param name="listVisitantes"></param>
        private void setCombo(List<Entidades.Jugar> listLocales, List<Entidades.Jugar> listVisitantes)
        {
            cbJugadoresLocal.Items.Clear();
            cbJugadoresVisitante.Items.Clear();
            foreach( var datosJugador in listLocales)
            {
                cbJugadoresLocal.Items.Add(datosJugador.nombreJug);
            }
            foreach (var datosJugador in listVisitantes)
            {
                cbJugadoresVisitante.Items.Add(datosJugador.nombreJug);
            }
        }

        /// <summary>
        /// Recoge los goles de cada partido y los carga en su espacio correspondiente
        /// </summary>
        private void getGolesPartido()
        {
            List<Entidades.Gol> listGolesLocales;
            List<Entidades.Gol> listGolesVisitantes;

            try
            {
                listGolesLocales = mundial.getGolesPartido(datosPartido.equipoL, datosPartido.fecha);
                listGolesVisitantes = mundial.getGolesPartido(datosPartido.equipoV, datosPartido.fecha);
                dtgGolesLocal.DataSource = listGolesLocales;
                dtgGolesVisitante.DataSource = listGolesVisitantes;

                dtgGolesLocal.Columns["minuto"].Width = 71;
                dtgGolesLocal.Columns["jugadorGol"].Width = 283;
                dtgGolesLocal.Columns["EquipoLGol"].Visible = false;
                dtgGolesLocal.Columns["EquipoVGol"].Visible = false;
                dtgGolesLocal.Columns["FechaGol"].Visible = false;

                dtgGolesVisitante.Columns["minuto"].Width = 71;
                dtgGolesVisitante.Columns["jugadorGol"].Width = 283;
                dtgGolesVisitante.Columns["EquipoLGol"].Visible = false;
                dtgGolesVisitante.Columns["EquipoVGol"].Visible = false;
                dtgGolesVisitante.Columns["FechaGol"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error recogiendo los goles del partido: " + ex.Message);
            }
        }

        /// <summary>
        /// Activa el formulario para insertar goles locales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAddGolesLocal_Click(object sender, EventArgs e)
        {
            gbNuevoGolLoc.Visible = true;
        }

        /// <summary>
        /// Activa el formulario para insertar goles visitantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAddGolesVisitante_Click(object sender, EventArgs e)
        {
            gbNuevoGolVis.Visible = true;
        }

        /// <summary>
        /// Activa el botón para eliminar el gol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgGolesLocal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btDeleteGolesLocal.Enabled = true;
        }

        /// <summary>
        /// Activa el botón para eliminar el gol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgGolesVisitante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btDeleteGolesVisitante.Enabled = true;
        }

        /// <summary>
        /// Elimina el gol y actualiza el partido con el nuevo resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteGolesLocal_Click(object sender, EventArgs e)
        {
            if (dtgGolesLocal.CurrentRow != null)
            {
                Entidades.Gol gol;

                try
                {
                    gol = new Entidades.Gol
                    {
                        minuto = Convert.ToInt32(dtgGolesLocal.CurrentRow.Cells[0].Value),
                        jugadorGol = dtgGolesLocal.CurrentRow.Cells[1].Value.ToString(),
                        equipoLGol = dtgGolesLocal.CurrentRow.Cells[2].Value.ToString(),
                        equipoVGol = dtgGolesLocal.CurrentRow.Cells[3].Value.ToString(),
                        fechaGol = (DateTime)dtgGolesLocal.CurrentRow.Cells[4].Value
                    };

                    if (mundial.removeGol(gol) > 0)
                    {
                        MessageBox.Show("El gol se ha eliminado correctamente.");
                        getGolesPartido();

                        ///Le restamos un gol a partidoentidad para así dejar el resultado coherente al borrado del gol
                        datosPartido.resultadoL = dtgGolesLocal.RowCount;

                        if (mundial.updateResultadoPartido(datosPartido) > 0)
                        {
                            MessageBox.Show("El resultado del partido se ha modificado correctamente.");
                            lblResultado.Text = datosPartido.resultadoL.ToString() + " - " + datosPartido.resultadoV.ToString(); ;
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error actualizando el partido.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error eliminando el gol. Inténtelo de nuevo.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar el gol: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un gol para eliminar");
            }
        }

        /// <summary>
        /// Elimina el gol y actualiza el partido con el nuevo resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteGolesVisitante_Click(object sender, EventArgs e)
        {
            if (dtgGolesVisitante.CurrentRow != null)
            {
                Entidades.Gol gol;

                try
                {
                    gol = new Entidades.Gol
                    {
                        minuto = Convert.ToInt32(dtgGolesVisitante.CurrentRow.Cells[0].Value),
                        jugadorGol = dtgGolesVisitante.CurrentRow.Cells[1].Value.ToString(),
                        equipoLGol = dtgGolesVisitante.CurrentRow.Cells[2].Value.ToString(),
                        equipoVGol = dtgGolesVisitante.CurrentRow.Cells[3].Value.ToString(),
                        fechaGol = (DateTime)dtgGolesVisitante.CurrentRow.Cells[4].Value
                    };

                    if (mundial.removeGol(gol) > 0)
                    {
                        MessageBox.Show("El gol se ha eliminado correctamente.");
                        getGolesPartido();

                        datosPartido.resultadoV = dtgGolesVisitante.RowCount;

                        if (mundial.updateResultadoPartido(datosPartido) > 0)
                        {
                            MessageBox.Show("El resultado del partido se ha modificado correctamente.");
                            lblResultado.Text = datosPartido.resultadoL.ToString() + " - " + datosPartido.resultadoV.ToString(); ;
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error actualizando el partido.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error eliminando el gol. Inténtelo de nuevo.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar el gol: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un gol para eliminar");
            }
        }

        /// <summary>
        /// Añade el gol y actualiza el partido con el nuevo resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAceptarGolLocal_Click(object sender, EventArgs e)
        {
            if (cbJugadoresLocal.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(tbMinutoGolLocal.Text))
                {
                    Entidades.Gol gol;

                    try
                    {
                        gol = new Entidades.Gol
                        {
                            minuto = Convert.ToInt32(tbMinutoGolLocal.Text),
                            jugadorGol = cbJugadoresLocal.SelectedItem.ToString(),
                            equipoLGol = datosPartido.equipoL,
                            equipoVGol = datosPartido.equipoV,
                            fechaGol = datosPartido.fecha
                        };

                        if (mundial.addGol(gol) > 0)
                        {
                            MessageBox.Show("El gol se ha añadido correctamente.");
                            getGolesPartido();

                            ///Le restamos un gol a partidoentidad para así dejar el resultado coherente al borrado del gol
                            datosPartido.resultadoL = dtgGolesLocal.RowCount;

                            if (mundial.updateResultadoPartido(datosPartido) > 0)
                            {
                                MessageBox.Show("El resultado del partido se ha modificado correctamente.");
                                lblResultado.Text = datosPartido.resultadoL.ToString() + " - " + datosPartido.resultadoV.ToString(); ;
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error actualizando el partido.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error añadiendo el gol. Inténtelo de nuevo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al añadir el gol: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un jugador para añadir un gol");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un jugador para añadir un gol");
            }
        }

        /// <summary>
        /// Oculta el formulario para añadir un gol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancelarGolLocal_Click(object sender, EventArgs e)
        {
            gbNuevoGolLoc.Visible = false;
        }

        /// <summary>
        /// Elimina el gol y actualiza el partido con el nuevo resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAceptarGolVisitante_Click(object sender, EventArgs e)
        {
            if (cbJugadoresVisitante.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(tbMinutoGolLocal.Text))
                {
                    Entidades.Gol gol;

                    try
                    {
                        gol = new Entidades.Gol
                        {
                            minuto = Convert.ToInt32(tbMinutoGolVisitante.Text),
                            jugadorGol = cbJugadoresVisitante.SelectedItem.ToString(),
                            equipoLGol = datosPartido.equipoL,
                            equipoVGol = datosPartido.equipoV,
                            fechaGol = datosPartido.fecha
                        };

                        if (mundial.addGol(gol) > 0)
                        {
                            MessageBox.Show("El gol se ha añadido correctamente.");
                            getGolesPartido();

                            ///Le restamos un gol a partidoentidad para así dejar el resultado coherente al borrado del gol
                            datosPartido.resultadoV = dtgGolesVisitante.RowCount;

                            if (mundial.updateResultadoPartido(datosPartido) > 0)
                            {
                                MessageBox.Show("El resultado del partido se ha modificado correctamente.");
                                lblResultado.Text = datosPartido.resultadoL.ToString() + " - " + datosPartido.resultadoV.ToString(); ;
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error actualizando el partido.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error añadiendo el gol. Inténtelo de nuevo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al añadir el gol: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un jugador para añadir un gol");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un jugador para añadir un gol");
            }
        }

        /// <summary>
        /// Oculta el formulario para añadir un gol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancelarGolVisitante_Click(object sender, EventArgs e)
        {
            gbNuevoGolVis.Visible = false;
        }
    }
}
