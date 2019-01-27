using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formInsertarUsuario : Form
    {
        List<Entidades.Rol> aRoles = new List<Entidades.Rol>();
        Negocio.Mundial mundial = new Negocio.Mundial();
        Entidades.Usuario user = new Entidades.Usuario();

        public formInsertarUsuario()
        {
            InitializeComponent();
            setRoles();
            dtpStartDate.MaxDate = DateTime.Now;
        }

        private void setRoles()
        {
            Negocio.Mundial _mundial = new Negocio.Mundial();
            aRoles = _mundial.getRoles();
            foreach ( var i in aRoles)
            {
                cbRol.Items.Add(i.descRol);
            }
        }

        private void tbNick_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxNick = (TextBox)sender;
            string nick = textBoxNick.Text;

            if( nick.Length > 50)
            {
                textBoxNick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtErrorNick.Visible = true;
            }
            else
            {
                textBoxNick.ForeColor = System.Drawing.Color.Black;
                txtErrorNick.Visible = false;
            }

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxEmail = (TextBox)sender;
            string email = textBoxEmail.Text;

            if (email.Length > 100)
            {
                textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtErrorEmail.Visible = true;
            }
            else
            {
                textBoxEmail.ForeColor = System.Drawing.Color.Black;
                txtErrorEmail.Visible = false;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxName = (TextBox)sender;
            string name = textBoxName.Text;

            if (name.Length > 80)
            {
                textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtErrorName.Visible = true;
            }
            else
            {
                textBoxName.ForeColor = System.Drawing.Color.Black;
                txtErrorName.Visible = false;
            }
        }

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxSurname = (TextBox)sender;
            string surname = textBoxSurname.Text;

            if (surname.Length > 80)
            {
                textBoxSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtErrorSurname.Visible = true;
            }
            else
            {
                textBoxSurname.ForeColor = System.Drawing.Color.Black;
                txtErrorSurname.Visible = false;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtpStartDate = (DateTimePicker)sender;
            DateTime startDate = dtpStartDate.Value;

            if(startDate > DateTime.Now)
            {
                dtpStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                txtErrorStartDate.Visible = true;
            }
            else
            {
                dtpStartDate.ForeColor = System.Drawing.Color.Black;
                txtErrorStartDate.Visible = false;
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
            Stream fileContent;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    var fileStream = openFileDialog.OpenFile();

                    fileContent = fileStream;
                    pbAvatar.Image = System.Drawing.Image.FromStream(fileStream);
                    pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnSendForm_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            txtErrorNick.Visible = false;
            txtErrorEmail.Visible = false;
            txtErrorName.Visible = false;
            txtErrorSurname.Visible = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(tbNick.Text) && tbNick.Text.Length <= 50)
                {
                    if (Negocio.utils.isRegisteredNick(tbNick.Text))
                    {
                        MessageBox.Show("El nick ya está registrado en el sistema");
                        txtErrorNick.Text = "El nick ya está registrado en el sistema";
                        txtErrorNick.Visible = true;
                        error = true;
                    }
                }
                else
                {
                    MessageBox.Show("El nick sobrepasa los 50 caracteres o está vacío");
                    txtErrorNick.Text = "El nick sobrepasa los 50 caracteres o está vacío";
                    txtErrorNick.Visible = true;
                    error = true;
                }

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
                if (txtErrorStartDate.Visible == true)
                {
                    MessageBox.Show("La fecha es posterior a hoy");
                    txtErrorStartDate.Text = "La fecha es posterior a hoy";
                    error = true;
                }

                if (!error)
                {
                    user = new Entidades.Usuario();
                    user.nick = tbNick.Text;
                    user.psw = Negocio.utils.MD5Encrypt(tbPsw.Text);
                    user.email = tbEmail.Text;
                    user.name = tbName.Text;
                    user.surname = tbSurname.Text;
                    user.startDate = dtpStartDate.Value;
                    user.idRol = aRoles.Find(datosRol => datosRol.descRol == cbRol.SelectedItem.ToString()).idRol;
                    user.active = cbActive.Checked == true ? "S" : "N";
   

                    if( mundial.setNuevoUsuario(user, pbAvatar) > 0 )
                    {
                        MessageBox.Show("El usuario se ha insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible insertar el usuario. Vuelva a intentarlo en unos momentos.");
                    }
                    
                }
            }catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
