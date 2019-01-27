using Negocio;
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

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formPswRecovery : Form
    {

        public formPswRecovery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mundial mundial;

            if ( !string.IsNullOrEmpty(tbUser.Text ) && 
                !string.IsNullOrEmpty( tbPsw.Text ) && 
                !string.IsNullOrEmpty( tbPsw2.Text ) )
            {
                if ( tbPsw.Text == tbPsw2.Text )
                {
                    if ( utils.isValidPsw( tbPsw.Text ) )
                    {
                        try
                        {
                            mundial = new Mundial();
                            if (mundial.updatePsw( tbUser.Text, utils.MD5Encrypt( tbPsw.Text ) ) > 0)
                            {
                                MessageBox.Show("La contraseña se han cambiado correctamente");
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("La contraseña no se ha cambiado.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al realizar el cambio de contraseña: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseña debe contener: mayúsculas, minúsculas y números.");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios.");
            }
        }
    }
}
