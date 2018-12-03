using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable getJugador( string name)
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
                Debug.WriteLine("Error en getJugador(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return dtJugador;
        }

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

                _sql = $@"SELECT DISTINC 
                            j.NOMBRE,
                            j.DIRECCION,
                            j.PUESTO_HAB,
                            j.FECHA_NAC,
                            j.EQUIPO_JUGADOR
                        FROM
                            jugador j, jugar ju, partido p
                        LEFT JOIN 
                            equipos e ON e.EQUIPO = j.EQUIPO_JUGADOR
                        LEFT JOIN 
                            jugar ju ON j.NOMBRE = ju.NOMBRE_JUG
                        LEFT JOIN 
                            partido p ON ( ju.EQUIPO_L_PART = p.EQUIPO_L OR ju.EQUIPO_V_PART = p.EQUIPO_V )";

                if(_name != null &&
                    _name != String.Empty)
                {
                    _where += $@" j.NOMBRE LIKE UPPER('%{ _name }%')";
                }
                if (_team != null &&
                    _team != String.Empty)
                {
                    _where += $@" e.EQUIPO LIKE UPPER('%{ _team }%')";
                }

                if (_year != null)
                {
                    _where += $@" TO_CHAR(p.FECHA, 'yyyy') = '{ _year }'";
                }

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();

                while (_dataSQL.Read())
                {
                    listJugadores.Add(new Entidades.Jugador
                    {
                        Nombre = _dataSQL[0].ToString(),
                        Direccion = _dataSQL[1].ToString(),
                        PuestoHab = _dataSQL[2].ToString(),
                        FechaNac = (_dataSQL[3] is DBNull)?DateTime.Now:(DateTime)_dataSQL[3],
                        EquipoJugador = _dataSQL[4].ToString()
                    });
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en getJugador(): " + e.Message);
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
        public int updateJugador(Entidades.Jugador newDatosJugador)
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
                _execSQL.Parameters.Add("v_nombre", OracleDbType.Varchar2, newDatosJugador.Nombre, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_equipo", OracleDbType.Varchar2, newDatosJugador.EquipoJugador, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_direccion", OracleDbType.Varchar2, newDatosJugador.Direccion, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_puesto_h", OracleDbType.Varchar2, newDatosJugador.PuestoHab, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_fec_na", OracleDbType.Date, newDatosJugador.FechaNac, ParameterDirection.Input);
                _execSQL.Parameters.Add("v_foto", OracleDbType.Blob, newDatosJugador.Avatar, ParameterDirection.Input);

                affectedRows = _db.execSQL();
                return affectedRows;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en updateJugador(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return affectedRows;
        }
    }
}
