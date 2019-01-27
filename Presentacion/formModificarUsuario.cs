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
    public partial class formModificarUsuario : Form
    {
        List<Entidades.Rol> aRoles = new List<Entidades.Rol>();
        List<Entidades.Usuario> aUsers = new List<Entidades.Usuario>();
        Negocio.Mundial mundial = new Negocio.Mundial();
        Entidades.Usuario user = new Entidades.Usuario();
        public formModificarUsuario()
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
            for( var i = 0; i < aTmpUsers.Count; i++)
            {
                aTmpUsers[i].avatar = null;
            }
            dgUsers.DataSource = null;
            dgUsers.DataSource = aTmpUsers;
            for ( var i = 0; i < aUsers.Count; i++)
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
        }

        private void btnAvatar_Click(object sender, EventArgs e)
        {
            openDialogImage();
        }
        private void pbAvatar_Click(object sender, EventArgs e)
        {
            openDialogImage();
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

        private void btnSendForm_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            txtErrorEmail.Visible = false;
            txtErrorName.Visible = false;
            txtErrorSurname.Visible = false;
            try
            {

                if (!string.IsNullOrWhiteSpace(tbEmail.Text) && tbEmail.Text.Length <= 100)
                {
                    if (!Negocio.utils.isValidEmail(tbEmail.Text))
                    {
                        MessageBox.Show("El email no tiene un formato válido");
                        txtErrorEmail.Text = "El email no tiene un formato válido";
                        txtErrorEmail.Visible = true;
                        error = true;
                    }
                }
                else
                {
                    MessageBox.Show("El email sobrepasa los 100 caracteres o está vacío");
                    txtErrorEmail.Text = "El email sobrepasa los 100 caracteres o está vacío";
                    txtErrorEmail.Visible = true;
                    error = true;
                }
                if (string.IsNullOrWhiteSpace(tbName.Text) || tbName.Text.Length > 100)
                {
                    MessageBox.Show("El nombre sobrepasa los 100 caracteres o está vacío");
                    txtErrorName.Text = "El nombre sobrepasa los 100 caracteres o está vacío";
                    txtErrorName.Visible = true;
                    error = true;
                }
                if (string.IsNullOrWhiteSpace(tbSurname.Text) || tbSurname.Text.Length > 150)
                {
                    MessageBox.Show("El apellido sobrepasa los 100 caracteres o está vacío");
                    txtErrorSurname.Text = "El apellido sobrepasa los 100 caracteres o está vacío";
                    txtErrorSurname.Visible = true;
                    error = true;
                }
                if (string.IsNullOrWhiteSpace(cbRol.Text))
                {
                    MessageBox.Show("El rol es obligatorio");
                    error = true;
                }

                if (!error)
                {
                    user.nick = tbNick.Text;
                    user.email = tbEmail.Text;
                    user.name = tbName.Text;
                    user.surname = tbSurname.Text;
                    user.idRol = aRoles.Find(datosRol => datosRol.descRol == cbRol.SelectedItem.ToString()).idRol;
                    user.active = cbActive.Checked == true ? "S" : "N";


                    if (mundial.updateUsuario(user, pbAvatar) > 0)
                    {
                        setUsers();
                        MessageBox.Show("El usuario se ha modificado correctamente.");
                        gbDatosUsuario.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible modificar el usuario. Vuelva a intentarlo en unos momentos.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
