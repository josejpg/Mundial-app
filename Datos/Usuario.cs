using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Usuario
    {
        public Usuario() { }

        /// <summary>
        /// Recupera todos los roles de la db
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Usuario> getUsuarios()
        {

            List<Entidades.Usuario> _listUsuarios = new List<Entidades.Usuario>();
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            string _sql = @"SELECT 
                                ID_USUARIO_APP,
                                NICK_USUARIO_APP,
                                CONTRASENYA_USUARIO_APP,
                                EMAIL_USUARIO_APP,
                                NOMBRE_USUARIO_APP,
                                APELLIDOS_USUARIO_APP,
                                FECHA_ALTA_USUARIO_APP,
                                ROL_USUARIO_APP
                                ACTIVO_USUARIO_APP
                            FROM USUARIO_APP";

            try
            {
                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();

                // Llamar siempre a Read antes de acceder a los datos
                while (_dataSQL.Read())
                {

                    _listUsuarios.Add(
                        new Entidades.Usuario
                        {
                            IdUser = int.Parse(_dataSQL[0].ToString()),
                            Nick = _dataSQL[1].ToString(),
                            Psw = _dataSQL[2].ToString(),
                            Email = _dataSQL[3].ToString(),
                            Name = _dataSQL[4].ToString(),
                            Surname = _dataSQL[5].ToString(),
                            StartDate = (DateTime)_dataSQL[6],
                            IdRol = int.Parse(_dataSQL[7].ToString()),
                            Active = _dataSQL[8].ToString()
                        }
                    );

                }

                _dataSQL.Close();
                _dataSQL.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en getUsuarios(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return _listUsuarios;

        }
        /// <summary>
        /// Comprueba si los datos del usuario existen en la DB
        /// </summary>
        /// <param name="user"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public Entidades.Usuario compruebaLogin(string user, string psw)
        {
            Entidades.Usuario datosUsuario = new Entidades.Usuario();
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            string _sql = $@"SELECT 
                                ID_USUARIO_APP,
                                NICK_USUARIO_APP,
                                CONTRASENYA_USUARIO_APP,
                                EMAIL_USUARIO_APP,
                                NOMBRE_USUARIO_APP,
                                APELLIDOS_USUARIO_APP,
                                FECHA_ALTA_USUARIO_APP,
                                ROL_USUARIO_APP
                                ACTIVO_USUARIO_APP
                            FROM 
                                USUARIO_APP
                            WHERE
                                NICK_USUARIO_APP = '{ user }'
                            AND
                                (
                                    CONTRASENYA_USUARIO_APP = '{ psw }'
                                OR
                                    CONTRASENYA_USUARIO_APP = EMAIL_USUARIO_APP
                                )";

            try
            {
                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();
                _dataSQL.Read();
                datosUsuario = new Entidades.Usuario {
                    IdUser = int.Parse(_dataSQL[0].ToString()),
                    Nick = _dataSQL[1].ToString(),
                    Psw = _dataSQL[2].ToString(),
                    Email = _dataSQL[4].ToString(),
                    Name = _dataSQL[5].ToString(),
                    Surname = _dataSQL[6].ToString(),
                    StartDate = (DateTime)_dataSQL[7],
                    IdRol = int.Parse(_dataSQL[8].ToString()),
                    Active = _dataSQL[8].ToString()
                };
                _dataSQL.Close();
                _dataSQL.Dispose();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en compruebaLogin(): " + ex.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }

            return datosUsuario;
        }

       /// <summary>
       /// Actualiza los datos del usuario
       /// </summary>
       /// <param name="newDatosUsuario"></param>
       /// <returns></returns>
        public int updateUsuario(Entidades.Usuario newDatosUsuario)
        {

            DataBase _db = new DataBase();
            string _sql;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _sql = $@"UPDATE
                            USUARIO_APP
                        SET 
                            CONTRASENYA_USUARIO_APP = :newPsw,
                            EMAIL_USUARIO_APP = :newEmail,
                            NOMBRE_USUARIO_APP = :newName,
                            APELLIDOS_USUARIO_APP = :newSurname,
                            ROL_USUARIO_APP = :newRol,
                            ACTIVO_USUARIO_APP = :newActive
                        WHERE
                            ID_USUARIO_APP = :idUser";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":newPsw", OracleDbType.Varchar2).Value = newDatosUsuario.Psw;
                _db.Sql.Parameters.Add(":newEmail", OracleDbType.Varchar2).Value = newDatosUsuario.Email;
                _db.Sql.Parameters.Add(":newName", OracleDbType.Varchar2).Value = newDatosUsuario.Name;
                _db.Sql.Parameters.Add(":newSurname", OracleDbType.Varchar2).Value = newDatosUsuario.Surname;
                _db.Sql.Parameters.Add(":newRol", OracleDbType.Int32).Value = newDatosUsuario.IdRol;
                _db.Sql.Parameters.Add(":newActive", OracleDbType.Varchar2).Value = newDatosUsuario.Active;
                _db.Sql.Parameters.Add(":idUser", OracleDbType.Varchar2).Value = newDatosUsuario.IdUser;

                affectedRows = _db.execSQL();

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en updateUsuario(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }

            return affectedRows;
        }
        
        /// <summary>
        /// Actualiza la contraseña de un usuario
        /// </summary>
        /// <param name="newPsw"></param>
        /// <param name="nickUser"></param>
        /// <returns></returns>
        public int updatePswUsuario(string nickUser, string newPsw)
        {

            DataBase _db = new DataBase();
            string _sql;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _sql = $@"UPDATE
                            USUARIO_APP
                        SET 
                            CONTRASENYA_USUARIO_APP = :newPsw
                        WHERE
                            NICK_USUARIO_APP = :nickUser";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":newPsw", OracleDbType.Varchar2).Value = newPsw;
                _db.Sql.Parameters.Add(":nickUser", OracleDbType.Varchar2).Value = nickUser;

                affectedRows = _db.execSQL();

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en updatePswUsuario(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }

            return affectedRows;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la DB
        /// </summary>
        /// <param name="newDatosUsuario"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public int newUsuario(Entidades.Usuario newDatosUsuario, PictureBox avatar)
        {

            DataBase _db = new DataBase();
            string _sql;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _sql = $@"INSERT INTO 
                            USUARIO_APP(
                                ID_USUARIO_APP, 
                                NICK_USUARIO_APP, 
                                CONTRASENYA_USUARIO_APP, 
                                EMAIL_USUARIO_APP, 
                                NOMBRE_USUARIO_APP, 
                                APELLIDOS_USUARIO_APP, 
                                FECHA_ALTA_USUARIO_APP, 
                                ROL_USUARIO_APP, 
                                FOTO_USUARIO_APP, 
                                ACTIVO_USUARIO_APP)
                            VALUES(
                                USUARIO_APP_SEQ.NEXTVAL, 
                                :nickUsuario, 
                                :pswUsuario, 
                                :emailUsuario, 
                                :nameUsuario, 
                                :surnameUsuario, 
                                :startDateUsuario, 
                                :idRolUsuario, 
                                :activeUsuario, 
                                :avatarUsuario)";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":nickUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Nick;
                _db.Sql.Parameters.Add(":pswUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Psw;
                _db.Sql.Parameters.Add(":emailUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Email;
                _db.Sql.Parameters.Add(":nameUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Name;
                _db.Sql.Parameters.Add(":surnameUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Surname;
                _db.Sql.Parameters.Add(":startDateUsuario", OracleDbType.Date).Value = newDatosUsuario.StartDate;
                _db.Sql.Parameters.Add(":idRolUsuario", OracleDbType.Int32).Value = newDatosUsuario.IdRol;
                _db.Sql.Parameters.Add(":activeUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.Active;
                _db.Sql.Parameters.Add(":avatarUsuario", OracleDbType.Blob).Value = getBlob(avatar);

                affectedRows = _db.execSQL();

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en newUsuario(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }

            return affectedRows;
        }
        /// <summary>
        /// Genera un array de bytes desde un PictureBox para que pueda ser insertada en la DB
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public static byte[] getBlob( PictureBox avatar )
        {
            MemoryStream _memoryStream;
            byte[] _bytesAvatar;

            try
            {
                _memoryStream = new MemoryStream();
                avatar.Image.Save(_memoryStream, ImageFormat.Jpeg);
                _bytesAvatar = new byte[_memoryStream.Length];
                _memoryStream.Position = 0;
                _memoryStream.Read(_bytesAvatar, 0, _bytesAvatar.Length);
            }
            catch (Exception e)
            {
                throw new Exception("Error en getBlob():\n" + e.Message);
            }
            return _bytesAvatar;
        }

        /// <summary>
        /// Elimina un usuario de la DB
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
        public int deleteUsuario(Entidades.Usuario datosUsuario)
        {

            DataBase _db = new DataBase();
            string _sql;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _sql = $@"DELETE FROM
                            USUARIO_APP
                        WHERE
                            ID_USUARIO_APP = :idUser";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = System.Data.CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":idUser", OracleDbType.Varchar2).Value = datosUsuario.IdUser;

                affectedRows = _db.execSQL();

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en deleteUsuario(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }

            return affectedRows;
        }

        /// <summary>
        /// Recoge y muestra un listado d epartidos según el año
        /// </summary>
        /// <param name="_year"></param>
        /// <returns></returns>
        public List<Entidades.Partido> getPartidosAnyo(int _year)
        {
            return new Datos.Partido().getPartidosAnyo(_year);
        }

        /// <summary>
        /// Devuelve una lista de usuarios que coinciden con el filtro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="equipo"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Entidades.Jugador> filtraUsuarios(string name, string team, int year)
        {
            return new Datos.Jugador().getJugadores(name,team,year);
        }

        /// <summary>
        /// Recopera los datos de un jugador concreto
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable getJugador(string name)
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
    }
}
