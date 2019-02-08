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
    public partial class formModificarPartido : Form
    {
        private Negocio.Mundial mundial;
        private Entidades.Partido datosPartido;

        public formModificarPartido(Entidades.Partido datosPartido)
        {
            InitializeComponent();

            if( formPrincipal.usuario.idRol == 1001)
            {
                dtgGolesLocal.Enabled = false;
                dtgGolesVisitante.Enabled = false;
                btAddGolesLocal.Enabled = false;
                btAddGolesVisitante.Enabled = false;
                btDeleteGolesLocal.Enabled = false;
                btDeleteGolesVisitante.Enabled = false;
            }
            this.datosPartido = datosPartido;
            getDatosPartidos();
        }

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
                    titularesLocales++;
                }

                setCombo(listLocales, listVisitantes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error recogiendo los datos del partido: " + ex.Message);
            }
        }
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
    }
}
