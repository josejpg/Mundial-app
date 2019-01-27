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
    public class Jugador
    {
        /// <summary>
        /// Constructor  Sin argumentos
        /// </summary>
        public Jugador() { }

        /// <summary>
        /// Devuelve los datos de un jugador cuyo nombre se pasa por parametro utilizando un procedure
        /// Al no funcionar el procedure se hace una consulta directa a DB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Entidades.Jugador getJugador(string name)
        {
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            Entidades.Jugador player = new Entidades.Jugador();
            string _sql = "";

            try
            {
                _sql = $@"SELECT 
                            j.FOTO_JUGADOR,
                            j.NOMBRE,
                            j.DIRECCION,
                            j.PUESTO_HAB,
                            j.FECHA_NAC,
                            j.EQUIPO_JUGADOR
                        FROM 
                            JUGADOR j
                        WHERE 
                            j.NOMBRE LIKE UPPER('%{ name }%')";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();
                _dataSQL.Read();

                player = new Entidades.Jugador
                {
                    nombre = _dataSQL[1].ToString(),
                    direccion = _dataSQL[2].ToString(),
                    puestoHab = _dataSQL[3].ToString(),
                    fechaNac = (_dataSQL[4] is DBNull) ? DateTime.Now : (DateTime)_dataSQL[3],
                    equipoJugador = _dataSQL[5].ToString()
                };

            }
            catch (Exception e)
            {
                throw new Exception("Error en getJugador(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return player;
        }
        /*
         *  NO FUNCIONA EL PROCEDURE, DEVUELVE SIEMPRE NULL
         * public DataTable getJugador(string name)
        {
            DataBase _db = new DataBase();
            OracleDataAdapter _adapter;
            DataTable dtJugador = new DataTable();

            try
            {
                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.BindByName = true;
                _db.Sql.CommandType = CommandType.StoredProcedure;
                _db.Sql.CommandText = "CONSULTAS.OBTENER_JUGADOR";
                _db.Sql.Parameters.Add("v_nombre", OracleDbType.Varchar2, name, ParameterDirection.Input);
                _db.Sql.Parameters.Add("est_jugador", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
                _db.Sql.Parameters.Add("C2BLOB", OracleDbType.Blob, DBNull.Value, ParameterDirection.Output);
                _adapter = new OracleDataAdapter(_db.Sql);
                _adapter.Fill(dtJugador);

            }
            catch (Exception e)
            {
                throw new Exception("Error en getJugador(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return dtJugador;
        }*/

        /// <summary>
        /// Recupera un listado de jugadores según los parámetros que se le envíen
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_team"></param>
        /// <param name="_year"></param>
        /// <returns></returns>
        public List<Entidades.Jugador> getJugadores(string _name, string _team, int? _year)
        {
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            List<Entidades.Jugador> listJugadores = new List<Entidades.Jugador>();
            string _sql = "";
            string _where = "";

            try
            {
                if (_name != null &&
                    _name != String.Empty)
                {
                    _where = (_where.Equals(String.Empty)) ? " WHERE " : " AND ";
                    _where += $@"j.NOMBRE LIKE UPPER('%{ _name }%')";
                }
                if (_team != null &&
                    _team != String.Empty)
                {
                    _where = (_where.Equals(String.Empty)) ? " WHERE " : " AND ";
                    _where += $@"e.EQUIPO LIKE UPPER('%{ _team }%')";
                }

                if (_year != null && _year > 0)
                {
                    _where = (_where.Equals(String.Empty)) ? " WHERE " : " AND ";
                    _where += $@"TO_CHAR(p.FECHA, 'yyyy') = '{ _year }'";
                }


                _sql = $@"SELECT 
                            j.FOTO_JUGADOR,
                            j.NOMBRE,
                            j.DIRECCION,
                            j.PUESTO_HAB,
                            j.FECHA_NAC,
                            j.EQUIPO_JUGADOR
                        FROM 
                            JUGADOR j
                        WHERE 
                            j.NOMBRE IN (
                                SELECT
                                    j2.NOMBRE
                                FROM 
                                    JUGADOR j2
                                LEFT JOIN 
                                    EQUIPOS e ON e.EQUIPO = j2.EQUIPO_JUGADOR
                                LEFT JOIN 
                                    JUGAR ju ON ju.NOMBRE_JUG = j2.NOMBRE
                                LEFT JOIN 
                                    PARTIDO p ON ( ju.EQUIPO_L_PART = p.EQUIPO_L OR ju.EQUIPO_V_PART = p.EQUIPO_V ) 
                                { _where }
                                GROUP BY 
                                    j2.NOMBRE)
                        ORDER BY j.NOMBRE";
                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();

                while (_dataSQL.Read())
                {
                    Entidades.Jugador jugador = new Entidades.Jugador
                    {
                        nombre = _dataSQL[1].ToString(),
                        direccion = _dataSQL[2].ToString(),
                        puestoHab = _dataSQL[3].ToString(),
                        fechaNac = (_dataSQL[4] is DBNull) ? DateTime.Now : (DateTime)_dataSQL[3],
                        equipoJugador = _dataSQL[5].ToString()
                    };
                    jugador.avatar = ((_dataSQL[0] is DBNull) ? null : (byte[])_dataSQL[0]);
                    listJugadores.Add(jugador);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en getJugador(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return listJugadores;
        }

        /// <summary>
        /// Actualiza datos de un jugador
        /// </summary>
        /// <param name="newDatosJugador"></param>
        /// <returns></returns>
        public int updateJugador(Entidades.Jugador datosJugador)
        {
            DataBase _db = new DataBase();
            OracleCommand _execSQL;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _execSQL = _db.DbConnection.CreateCommand();
                _execSQL.BindByName = true;
                _execSQL.CommandType = CommandType.StoredProcedure;
                _execSQL.CommandText = "CONSULTAS.GRABAR_JUGADOR";
                _execSQL.Parameters.Add("v_nombre", OracleDbType.Varchar2, datosJugador.nombre, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_equipo", OracleDbType.Varchar2, datosJugador.equipoJugador, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_direccion", OracleDbType.Varchar2, datosJugador.direccion, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_puesto_h", OracleDbType.Varchar2, datosJugador.puestoHab, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_fec_na", OracleDbType.Date, datosJugador.fechaNac, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_foto", OracleDbType.Blob, datosJugador.avatar, ParameterDirection.Input);

                affectedRows = _db.execSQL();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error en updateJugador(): " + e.Message);
            }
            finally
            {
                _db.closeDB();
                
            }
            return affectedRows;
        }

        /// <summary>
        /// Recupera un listado de equipos
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Equipo> getEquipos()
        {
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            List<Entidades.Equipo> listEquipos = new List<Entidades.Equipo>();
            string _sql = "";

            try
            {
                _sql = $@"SELECT 
                            e.*
                        FROM 
                            EQUIPOS e";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();
                while (_dataSQL.Read())
                {
                    Entidades.Equipo team = new Entidades.Equipo
                    {
                        nombreEquipo = _dataSQL[0].ToString(),
                        pais = _dataSQL[1].ToString(),
                        seleccionador = _dataSQL[2].ToString()
                    };
                    listEquipos.Add(team);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en getEquipos(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return listEquipos;
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
    }
}
