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
                var a = aUsers[i].avatar;
                MemoryStream ms = new MemoryStream(aUsers[i].avatar);
                Image image = Image.FromStream(ms);
                dgUsers.Rows[i].Cells[0].Value = image;
                dgUsers.Rows[i].Height = image.Height;
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
                    tbNick.Enabled = false;
                    tbNick.Text = user.nick;
                    tbNick.Enabled = false;
                    tbEmail.Text = user.email;
                    tbEmail.Enabled = false;
                    tbName.Text = user.name;
                    tbName.Enabled = false;
                    tbSurname.Text = user.surname;
                    tbSurname.Enabled = false;
                    setAvatar(user.avatar);
                    cbActive.Checked = user.active == "S";
                    cbActive.Enabled = false;
                    cbRol.SelectedItem = aRoles.Find(datosRol => datosRol.idRol == user.idRol).descRol;
                    cbRol.Enabled = false;
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
    }
}
