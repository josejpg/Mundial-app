using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Negocio
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Mundial
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Mundial(){}

        /// <summary>
        /// Obtiene y devuelve el listado de roles de la app
        /// haciendo de intermediario entre la capa Datos y Presentación
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Rol> getRoles()
        {
            List<Entidades.Rol> _listRoles = new List<Entidades.Rol>();
            try
            {
                Datos.Rol _rol = new Datos.Rol();
                _listRoles = _rol.getRoles();
            }
            catch(InvalidOperationException e)
            {
                MessageBox.Show( e.ToString() );
            }
            catch(ApplicationException e)
            {
                MessageBox.Show( e.ToString() );
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException e)
            {
                MessageBox.Show( e.ToString() );
            }
            return _listRoles;
        }

        /// <summary>
        /// Obtiene y devuelve el listado de usuarios de la app
        /// haciendo de intermediario entre la capa Datos y Presentación
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Usuario> getUsuarios()
        {
            List<Entidades.Usuario> _listUsuarios = new List<Entidades.Usuario>();
            try
            {
                Datos.Usuario _usuario = new Datos.Usuario();
                _listUsuarios = _usuario.getUsuarios();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (ApplicationException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException e)
            {
                MessageBox.Show(e.ToString());
            }
            return _listUsuarios;
        }

        /// <summary>
        /// Devuelve el usuario logueado
        /// </summary>
        /// <param name="user"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public Entidades.Usuario login(string user, string psw)
        {
            return new Datos.Usuario().compruebaLogin(user, psw);
        }

        public Usuario CompruebaLogin(string text, object v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Llama a la funcion para crear un nuevo usuario
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <param name="imagePb"></param>
        /// <returns></returns>
        public int setNuevoUsuario(Entidades.Usuario datosUsuario, PictureBox imagePb)
        {
            return new Datos.Usuario().newUsuario(datosUsuario, imagePb);
        }

        /// <summary>
        /// Llama a la función de actualizar datos del usuario
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
        public int updateUsuario(Entidades.Usuario datosUsuario)
        {
            return new Datos.Usuario().updateUsuario(datosUsuario);
        }

        /// <summary>
        /// Llama a la función de actualizar la contraseña del usuario
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public int updatePsw(string nick, string psw)
        {
            return new Datos.Usuario().updatePswUsuario(nick, psw);
        }

        /// <summary>
        /// Llama a la función para eliminar un usuario
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
        public int deleteUsuario(Entidades.Usuario datosUsuario)
        {
            return new Datos.Usuario().deleteUsuario(datosUsuario);
        }
    }
}
