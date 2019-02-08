using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formEliminarUsuario : Form
    {
        List<Entidades.Rol> aRoles = new List<Entidades.Rol>();
        List<Entidades.Usuario> aUsers = new List<Entidades.Usuario>();
        Negocio.Mundial mundial = new Negocio.Mundial();
        Entidades.Usuario user = new Entidades.Usuario();
        public formEliminarUsuario()
        {
            InitializeComponent();
            gbDatosUsuario.Visible = false;
            tbNick.Enabled = false;
            tbNick.Enabled = false;
            tbEmail.Enabled = false;
            tbName.Enabled = false;
            tbSurname.Enabled = false;
            cbActive.Enabled = false;
            cbRol.Enabled = false;
            setRoles();
            setUsers();
        }
        private void setRoles()
        {
            aRoles = mundial.getRoles();
            foreach (var i in aRoles)
            {
                cbRol.Items.Add(i.descRol);
            }
        }
        private void setUsers()
        {
            aUsers = mundial.getUsuarios();
            List<Entidades.Usuario> aTmpUsers = new List<Entidades.Usuario>(aUsers.Count);
            aUsers.ForEach(datosUsuario => aTmpUsers.Add(new Entidades.Usuario(datosUsuario)));
            for (var i = 0; i < aTmpUsers.Count; i++)
            {
                aTmpUsers[i].avatar = null;
            }
            dgUsers.DataSource = null;
            dgUsers.DataSource = aTmpUsers;
            for (var i = 0; i < aUsers.Count; i++)
            {
                if (aUsers[i].avatar != null)
                {
                    MemoryStream ms = new MemoryStream(aUsers[i].avatar);
                    Image image = Image.FromStream(ms);
                    dgUsers.Rows[i].Cells[0].Value = image;
                    dgUsers.Rows[i].Height = image.Height;
                }
                else
                {
                    Bitmap image = new Bitmap(Presentacion.Properties.Resources.user_default);
                    dgUsers.Rows[i].Cells[0].Value = image;
                    dgUsers.Rows[i].Height = image.Height;
                }
            }
        }

        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUsers.CurrentRow != null)
            {
                gbDatosUsuario.Visible = true;

                try
                {
                    int idUser = Convert.ToInt32(dgUsers.CurrentRow.Cells[1].Value);

                    user = mundial.getUsuarioById(idUser);
                    tbNick.Text = user.nick;
                    tbEmail.Text = user.email;
                    tbName.Text = user.name;
                    tbSurname.Text = user.surname;
                    setAvatar(user.avatar);
                    cbActive.Checked = user.active == "S";
                    cbRol.SelectedItem = aRoles.Find(datosRol => datosRol.idRol == user.idRol).descRol;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al obtener al usuario: " + ex.Message);
                }
            }
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

        private void btnSendForm_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que desea eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (mundial.deleteUsuario(user) > 0)
                {
                    setUsers();
                    MessageBox.Show("El usuario se ha eliminado correctamente.");
                    gbDatosUsuario.Visible = false;
                }
                else
                {
                    MessageBox.Show("No ha sido posible eliminar el usuario. Vuelva a intentarlo en unos momentos.");
                }
            }
        }

        private void btnCancelForm_Click(object sender, EventArgs e)
        {
            gbDatosUsuario.Visible = false;
            user = new Entidades.Usuario();
            tbNick.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbName.Text = String.Empty;
            tbSurname.Text = String.Empty;
            setAvatar(user.avatar);
            cbActive.Checked = false;
            cbRol.SelectedItem = null;
        }
    }
}
