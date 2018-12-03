using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formLogin : Form
    {
        /// <summary>
        /// Declaración de variables
        /// </summary>
        private int accessTry;

        /// <summary>
        /// Contructor del formLogin, inicializamos las variables
        /// </summary>
        public formLogin()
        {
            InitializeComponent();
            this.accessTry = 0;
            this.tbUser.GotFocus += TbUser_GotFocus;
            this.tbPassword.GotFocus += TbPassword_GotFocus;
            this.tbUser.LostFocus += TbUser_LostFocus;
            this.tbPassword.LostFocus += TbPassword_LostFocus;
        }

        private void TbPassword_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                this.tbPassword.Text = "Contraseña";
            }
        }

        private void TbUser_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text))
            {
                this.tbUser.Text = "Usuario";
            }
        }

        private void TbPassword_GotFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Contraseña")
            {
                this.tbPassword.Text = "";
            }
        }

        private void TbUser_GotFocus(object sender, EventArgs e)
        {
            if (tbUser.Text == "Usuario")
            {
                this.tbUser.Text = "";
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Evento click del button acceder donde comprobamos que los datos no sean vacios y se verifica si ese user existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAcceder_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(tbUser.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text)) && (tbUser.Text != "Usuario"))
            {
                Mundial mundial;
                Entidades.Usuario usuario;

                try
                {
                    mundial = new Mundial();
                    usuario = new Entidades.Usuario();
                    usuario = mundial.CompruebaLogin(tbUser.Text, utils.MD5Encrypt(tbPassword.Text));
                    if (usuario.Active == "S") 
                    {
                        if (!string.IsNullOrEmpty(usuario.Nick))
                        {
                        
                            if (usuario.Psw == usuario.Email)
                            {
                                MessageBox.Show("Se ha detectado que es la primera vez que entra, por lo que deberá cambiar la contraseña e iniciar sesión otra vez");
                                formPswRecovery frp = new formPswRecovery(usuario.Nick);
                                frp.ShowDialog();
                            }
                            else
                            {
                                this.Hide();
                                formPrincipal fp = new formPrincipal(usuario);
                                fp.Show();

                            }
                        
                        }
                        else
                        {
                            MessageBox.Show("Los datos introducidos son erróneos.");
                            accessTry += 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario esta actualmente desactivado.");
                        accessTry += 1;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido la siguiente excepción mientras se comprobaba el usuario y password: "+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Es obligatorio escribir el usuario y contraseña para poder acceder.");
                accessTry += 1;
            }

            if (this.accessTry == 3)
            {
                MessageBox.Show("Ha superado los intentos de login, el programa se cerrará.");
                this.Dispose();
            }
        }

        /// <summary>
        /// evento del boton recuperar contraseña para inicializar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRecPass_Click(object sender, EventArgs e)
        {
            if (tbUser.Text != "Usuario" && !string.IsNullOrWhiteSpace(tbUser.Text))
            {
                formPswRecovery frp = new formPswRecovery(tbUser.Text);
                frp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe indicar primero el usuario sobre el que ha olvidado la cotnraseña y después seleccionar la opción ¿Has olvidado la contraseña?");
                tbUser.Focus();
            }
        }

    }
}
