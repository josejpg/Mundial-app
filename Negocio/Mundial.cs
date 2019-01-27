using System;
using System.Collections.Generic;
using System.Data;
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
                _listRoles = new Datos.Rol().getRoles();
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
                _listUsuarios = new Datos.Usuario().getUsuarios();
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
        /// Obtiene y devuelve el listado de usuarios de la app
        /// haciendo de intermediario entre la capa Datos y Presentación
        /// </summary>
        /// <returns></returns>
        public Entidades.Usuario getUsuarioById(int idUser)
        {
            Entidades.Usuario datosUser = new Entidades.Usuario();
            try
            {
                datosUser = new Datos.Usuario().getUsuarioById(idUser);
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
            return datosUser;
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
        public int updateUsuario(Entidades.Usuario datosUsuario, PictureBox imagePb)
        {
            return new Datos.Usuario().updateUsuario(datosUsuario, imagePb);
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

        /// <summary>
        /// Devuelve un listado de partidos por año o sino todos
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Partido> getPartidos(int anyo)
        {
            return new Datos.Partido().getPartidosAnyo(anyo);
        }

        /// <summary>
        /// Devuelve una lista de usuarios que coinciden con el filtro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="equipo"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Entidades.Jugador> filtraJugador(string name, string team, int year)
        {
            return new Datos.Jugador().getJugadores(name, team, year);
        }

        /// <summary>
        /// Recopera los datos de un jugador concreto
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Entidades.Jugador getJugador(string name)
        {
            return new Datos.Jugador().getJugador(name);
        }

        /// <summary>
        /// Actualiza los datos de un juegador
        /// </summary>
        /// <param name="datosJugador"></param>
        /// <returns></returns>
        public int updateJugador(Entidades.Jugador datosJugador)
        {
            return new Datos.Jugador().updateJugador(datosJugador);
        }

        /// <summary>
        /// Devuelve un listado de partidos por año o sino todos
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Equipo> getEquipos()
        {
            return new Datos.Jugador().getEquipos();
        }
    }
}
