using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                            idUser = int.Parse(_dataSQL[0].ToString()),
                            nick = _dataSQL[1].ToString(),
                            psw = _dataSQL[2].ToString(),
                            email = _dataSQL[3].ToString(),
                            name = _dataSQL[4].ToString(),
                            surname = _dataSQL[5].ToString(),
                            startDate = (DateTime)_dataSQL[6],
                            idRol = int.Parse(_dataSQL[7].ToString()),
                            active = _dataSQL[8].ToString()
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
                                ROL_USUARIO_APP,
                                ACTIVO_USUARIO_APP, 
                                FOTO_USUARIO_APP
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
                datosUsuario = new Entidades.Usuario
                {
                    idUser =Convert.ToInt32(_dataSQL[0]),
                    nick = _dataSQL[1].ToString(),
                    psw = _dataSQL[2].ToString(),
                    email = _dataSQL[3].ToString(),
                    name = _dataSQL[4].ToString(),
                    surname = _dataSQL[5].ToString(),
                    startDate = (DateTime)_dataSQL[6],
                    idRol = Convert.ToInt32(_dataSQL[7]),
                    active = _dataSQL[8].ToString()
                };

                datosUsuario.avatar = ObjectToByteArray(_dataSQL[9]);
                _dataSQL.Close();

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
        public int updateUsuario(Entidades.Usuario newDatosUsuario, PictureBox avatar)
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
                            ACTIVO_USUARIO_APP = :newActive,
                            FOTO_USUARIO_APP = :newAvatar
                        WHERE
                            ID_USUARIO_APP = :idUser";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":newPsw", OracleDbType.Varchar2).Value = newDatosUsuario.psw;
                _db.Sql.Parameters.Add(":newEmail", OracleDbType.Varchar2).Value = newDatosUsuario.email;
                _db.Sql.Parameters.Add(":newName", OracleDbType.Varchar2).Value = newDatosUsuario.name;
                _db.Sql.Parameters.Add(":newSurname", OracleDbType.Varchar2).Value = newDatosUsuario.surname;
                _db.Sql.Parameters.Add(":newRol", OracleDbType.Int32).Value = newDatosUsuario.idRol;
                _db.Sql.Parameters.Add(":newActive", OracleDbType.Varchar2).Value = newDatosUsuario.active;
                _db.Sql.Parameters.Add(":newAvatar", OracleDbType.Blob).Value = getBlob(avatar);
                _db.Sql.Parameters.Add(":idUser", OracleDbType.Varchar2).Value = newDatosUsuario.idUser;

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
                                ACTIVO_USUARIO_APP, 
                                FOTO_USUARIO_APP)
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
                _db.Sql.Parameters.Add(":nickUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.nick;
                _db.Sql.Parameters.Add(":pswUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.psw;
                _db.Sql.Parameters.Add(":emailUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.email;
                _db.Sql.Parameters.Add(":nameUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.name;
                _db.Sql.Parameters.Add(":surnameUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.surname;
                _db.Sql.Parameters.Add(":startDateUsuario", OracleDbType.Date).Value = newDatosUsuario.startDate;
                _db.Sql.Parameters.Add(":idRolUsuario", OracleDbType.Int32).Value = newDatosUsuario.idRol;
                _db.Sql.Parameters.Add(":activeUsuario", OracleDbType.Varchar2).Value = newDatosUsuario.active;
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
                _db.Sql.Parameters.Add(":idUser", OracleDbType.Varchar2).Value = datosUsuario.idUser;

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
        /// Genera un array de bytes desde un PictureBox para que pueda ser insertada en la DB
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public static byte[] getBlob(PictureBox avatar)
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
        /// Transforma un objeto a un array de byte
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
