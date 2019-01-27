using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class formJugadores : Form
    {
        List<Entidades.Jugador> aPlayers = new List<Entidades.Jugador>();
        List<Entidades.Equipo> listEquipos = new List<Entidades.Equipo>();
        Negocio.Mundial mundial = new Negocio.Mundial();
        Entidades.Jugador player = new Entidades.Jugador();
        public formJugadores()
        {
            InitializeComponent();
            getEquipos();
            cbYearFiltro.Items.Add("");
            for (var year = DateTime.Now.Year; year >= 1900; year--)
            {

                cbYearFiltro.Items.Add(year);

            }
            cbYearFiltro.SelectedItem = formPrincipal.yearPreferences;
            tbName.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getPlayers();
        }
        private void btnCancelForm_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que desea cancelar la modificación de este jugador?", "Cancelar", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                gbDataPlayer.Visible = false;
                player = new Entidades.Jugador();
                tbName.Text = String.Empty;
                tbAddress.Text = String.Empty;
                setAvatar(player.avatar);
                cbTeam.SelectedItem = false;
                dtFechaNac.Value = DateTime.Now;
            }
        }

        private void dgPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPlayers.CurrentRow != null)
            {
                gbDataPlayer.Visible = true;

                try
                {
                    String namePlayer = dgPlayers.CurrentRow.Cells[0].Value.ToString();

                    player = mundial.getJugador(namePlayer);
                    tbName.Text = player.nombre;
                    tbAddress.Text = player.direccion;
                    tbPuestoHab.Text = player.puestoHab;
                    cbTeam.SelectedItem = player.equipoJugador;
                    dtFechaNac.Value = player.fechaNac;
                    setAvatar(player.avatar);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al obtener al usuario: " + ex.Message);
                }
            }
        }
        private void btnSendForm_Click(object sender, EventArgs e)
        {


            Boolean error = false;
            txtErrorAddress.Visible = false;
            txtErrorTeam.Visible = false;
            txtErrorPuestoHab.Visible = false;
            txtErrorFechaNac.Visible = false;
            try
            {
                if (string.IsNullOrWhiteSpace(tbAddress.Text) || tbAddress.Text.Length > 150)
                {
                    MessageBox.Show("La dirección sobrepasa los 150 caracteres o está vacío");
                    txtErrorAddress.Text = "La dirección sobrepasa los 150 caracteres o está vacío";
                    txtErrorAddress.Visible = true;
                    error = true;
                }

                if (string.IsNullOrWhiteSpace(tbPuestoHab.Text) || tbPuestoHab.Text.Length > 2)
                {
                    MessageBox.Show("El puesto habitual sobrepasa los 2 caracteres o está vacío");
                    txtErrorPuestoHab.Text = "El puesto habitual sobrepasa los 2 caracteres o está vacío";
                    txtErrorPuestoHab.Visible = true;
                    error = true;
                }
                if (cbTeam.SelectedItem == null)
                {
                    MessageBox.Show("El equipo es obligatorio");
                    txtErrorTeam.Text = "El equipo es obligatorio";
                    txtErrorTeam.Visible = true;
                    error = true;
                }
                if (( DateTime.Now - dtFechaNac.Value).TotalDays / 365 < 16 )
                {
                    MessageBox.Show("No puede ser menor de 16 años");
                    txtErrorFechaNac.Text = "No puede ser menor de 16 años";
                    txtErrorFechaNac.Visible = true;
                    error = true;
                }

                if (!error)
                {
                    player.direccion = tbAddress.Text;
                    player.puestoHab = tbPuestoHab.Text;
                    player.equipoJugador = listEquipos.Find(datosEquipo => datosEquipo.nombreEquipo == cbTeam.SelectedItem.ToString()).nombreEquipo;
                    player.fechaNac = dtFechaNac.Value;
                    player.avatar = Negocio.utils.getBloob(pbAvatar);

                    if (mundial.updateJugador(player) > 0)
                    {
                        getPlayers();
                        MessageBox.Show("El jugador se ha modificado correctamente.");
                        gbDataPlayer.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible modificar el jugador. Vuelva a intentarlo en unos momentos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAvatar_Click(object sender, EventArgs e)
        {
            openDialogImage();
        }
        private void pbAvatar_Click(object sender, EventArgs e)
        {
            openDialogImage();
        }

        private void getPlayers()
        {
            dgPlayers.DataSource = null;
            aPlayers = mundial.filtraJugador(tbNameFiltro.Text, (cbTeamFiltro.SelectedItem ==null)?"":cbTeamFiltro.SelectedItem.ToString(), Convert.ToInt32(cbYearFiltro.SelectedItem));
            List<Entidades.Jugador> aTmpPlayers = new List<Entidades.Jugador>(aPlayers.Count);
            if (aPlayers.Count > 0)
            {
                aPlayers.ForEach(datosJugador => aTmpPlayers.Add(new Entidades.Jugador(datosJugador)));
                for (var i = 0; i < aTmpPlayers.Count; i++)
                {
                    aTmpPlayers[i].avatar = null;
                }

                dgPlayers.DataSource = aTmpPlayers;
                for (var i = 0; i < aPlayers.Count; i++)
                {
                    if (aPlayers[i].avatar != null && !aPlayers[i].avatar.Equals(String.Empty))
                    {
                        MemoryStream ms = new MemoryStream(aPlayers[i].avatar);
                        Image image = Image.FromStream(ms);
                        dgPlayers.Rows[i].Cells[5].Value = image;
                        dgPlayers.Rows[i].Height = image.Height;
                    }
                    else
                    {
                        Bitmap image = new Bitmap(Presentacion.Properties.Resources.user_default);
                        dgPlayers.Rows[i].Cells[5].Value = image;
                        dgPlayers.Rows[i].Height = image.Height;
                    }
                }
            }
        }

        private void getEquipos()
        {
            listEquipos = mundial.getEquipos();
            cbTeam.Items.Add("");
            cbTeamFiltro.Items.Add("");
            listEquipos.ForEach(datosEquipo => { cbTeam.Items.Add(datosEquipo.nombreEquipo); cbTeamFiltro.Items.Add(datosEquipo.nombreEquipo); });
        } 

        /// <summary>
        /// Se crea la imagen desde los bytes
        /// </summary>
        /// <param name="bytesAvatar"></param>
        private void setAvatar(byte[] bytesAvatar)
        {
            if (bytesAvatar != null && bytesAvatar.Length > 0)
            {
                MemoryStream memStream;
                try
                {
                    memStream = new MemoryStream(bytesAvatar);
                    pbAvatar.Image = Image.FromStream(memStream);
                    pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al montar el avatar: " + ex.Message);
                    memStream = null;
                }
            }
            else
            {
                pbAvatar.Image = new Bitmap(Presentacion.Properties.Resources.user_default);
                pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void openDialogImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    var fileStream = openFileDialog.OpenFile();
                    pbAvatar.Image = System.Drawing.Image.FromStream(fileStream);
                    pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
