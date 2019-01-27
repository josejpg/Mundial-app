using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                    usuario = mundial.login(tbUser.Text, utils.MD5Encrypt(tbPassword.Text));
                    Debug.Write( usuario.ToString() );
                    if (usuario.active == "S") 
                    {
                        if (!string.IsNullOrEmpty(usuario.nick))
                        {
                        
                            if (usuario.psw == usuario.email)
                            {
                                MessageBox.Show("Se ha detectado que es la primera vez que entra, por lo que deberá cambiar la contraseña e iniciar sesión otra vez");
                                formPswRecovery frp = new formPswRecovery();
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
        /// Evento click del enlace para iniciar el proceso de recuperar contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formPswRecovery frp = new formPswRecovery();
            frp.ShowDialog();
        }
    }
}
