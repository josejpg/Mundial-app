using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formInsertarUsuariosAPP : Form
    {
        public formInsertarUsuariosAPP()
        {
            InitializeComponent();
            setRoles();

        }

        private void setRoles()
        {
            Negocio.Mundial _mundial = new Negocio.Mundial();
            foreach ( var i in _mundial.getRoles())
            {
                cbRol.Items.Add(i);
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
            
            if(tbNick.Text == string.Empty)
            {
                MessageBox.Show("El nick es obligatorio");
            }
            else if(txtErrorNick.Visible == true)
            {
                MessageBox.Show("El nick sobrepasa los 50 caracteres");
            }
            else if (tbEmail.Text == string.Empty)
            {
                MessageBox.Show("El email es obligatorio");
            }
            else if (txtErrorEmail.Visible == true)
            {
                MessageBox.Show("El email sobrepasa los 100 caracteres");
            }
            else if (tbName.Text == string.Empty)
            {
                MessageBox.Show("El nombre es obligatorio");
            }
            else if (txtErrorName.Visible == true)
            {
                MessageBox.Show("El nombre sobrepasa los 80 caracteres");
            }
            else if (tbSurname.Text == string.Empty)
            {
                MessageBox.Show("El apellido es obligatorio");
            }
            else if (txtErrorSurname.Visible == true)
            {
                MessageBox.Show("El apellido sobrepasa los 150 caracteres");
            }
            else if (cbRol.Text == string.Empty)
            {
                MessageBox.Show("El rol es obligatorio");
            }
            else if (txtErrorStartDate.Visible == true)
            {
                MessageBox.Show("La fecha es posterior a hoy");
            }
            else
            {
                MessageBox.Show("El formulario se ha insertado correctamente.");
            }

        }
    }
}
