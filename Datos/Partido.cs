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
    public class Partido
    {
        /// <summary>
        /// Constructor  Sin argumentos
        /// </summary>
        public Partido() { }

        /// <summary>
        /// Devuelve un listado de partidos según el año que se solicite,
        /// si se solicita el año actual o ninguno devolverá todos los partidos
        /// </summary>
        /// <param name="_year"></param>
        /// <returns></returns>
        public List<Entidades.Partido> getPartidosAnyo(int? _year)
        {
            List<Entidades.Partido> _listPartidos = new List<Entidades.Partido>();
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            string _sql;

            try
            {
                if( _year == null || 
                    _year == DateTime.Now.Year)
                {
                    _sql = "SELECT * FROM PARTIDO ORDER BY FECHA ASC";
                }
                else
                {
                    _sql = $@"SELECT 
                                * 
                            FROM 
                                PARTIDO 
                            WHERE
                                TO_CHAR(FECHA, 'yyyy') = '{ _year }'
                            ORDER BY 
                                FECHA ASC";
                }

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();

                // Llamar siempre a Read antes de acceder a los datos
                while (_dataSQL.Read())
                {
                    _listPartidos.Add(
                        new Entidades.Partido
                        {
                            equipoL = _dataSQL[0].ToString(),
                            equipoV = _dataSQL[1].ToString(),
                            fecha = (DateTime)_dataSQL[2],
                            hora = _dataSQL[3].ToString(),
                            sede = _dataSQL[4].ToString(),
                            resultadoL = Convert.ToInt32(_dataSQL[5]),
                            resultadoV = Convert.ToInt32(_dataSQL[6]),
                            asistencia = (_dataSQL[7] is DBNull)?0: Convert.ToInt32(_dataSQL[7]),
                        }
                    );
                }

                _dataSQL.Close();
                _dataSQL.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Error en getPartidosAnyo(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return _listPartidos;
        }

        /// <summary>
        /// Devuelve un listado de partidos según el año, el nombre, ambos o todos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="_year"></param>
        /// <returns></returns>
        public List<Entidades.Partido> getPartidos(string name, int? _year)
        {
            List<Entidades.Partido> _listPartidos = new List<Entidades.Partido>();
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            string _sql, _where = "";

            try
            {
                if (_year != null &&
                   _year != DateTime.Now.Year)
                {
                    if (_where.Equals(String.Empty)) { _where += "WHERE "; }
                    else { _where += " AND ";  }
                    _where += $@"TO_CHAR(FECHA, 'yyyy') = '{ _year }'";
                }
                if (name != null &&
                   name != String.Empty)
                {
                    if (_where.Equals(string.Empty)) { _where += "WHERE "; }
                    else { _where += " AND ";  }
                    _where += $@"(equipoL LIKE '%{ name }%' OR equipoV LIKE '%{ name }%')";
                }

                _sql = $@"SELECT 
                            * 
                        FROM 
                            PARTIDO 
                        { _where }
                        ORDER BY 
                            FECHA ASC";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();

                // Llamar siempre a Read antes de acceder a los datos
                while (_dataSQL.Read())
                {
                    _listPartidos.Add(
                        new Entidades.Partido
                        {
                            equipoL = _dataSQL[0].ToString(),
                            equipoV = _dataSQL[1].ToString(),
                            fecha = (DateTime)_dataSQL[2],
                            hora = _dataSQL[3].ToString(),
                            sede = _dataSQL[4].ToString(),
                            resultadoL = Convert.ToInt32(_dataSQL[5]),
                            resultadoV = Convert.ToInt32(_dataSQL[6]),
                            asistencia = (_dataSQL[7] is DBNull) ? 0 : Convert.ToInt32(_dataSQL[7]),
                        }
                    );
                }

                _dataSQL.Close();
                _dataSQL.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Error en getPartidos(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return _listPartidos;
        }

        public int updateResultadoPartido(Entidades.Partido datosPartido)
        {
            DataBase _db = new DataBase();
            string _sql;
            int affectedRows = 0;

            try
            {
                _db.startDB();
                _sql = $@"UPDATE
                            PARTIDO
                        SET 
                            RESULTADO_L = :resultadoL,
                            RESULTADO_V = :resultadoV
                        WHERE
                            EQUIPO_L = :equipoL
                        AND
                            EQUIPO_V = :equipoV
                        AND
                            FECHA = :fecha";

                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _db.Sql.Parameters.Add(":resultadoL", OracleDbType.Varchar2).Value = datosPartido.resultadoL;
                _db.Sql.Parameters.Add(":resultadoV", OracleDbType.Varchar2).Value = datosPartido.resultadoV;
                _db.Sql.Parameters.Add(":equipoL", OracleDbType.Varchar2).Value = datosPartido.equipoL;
                _db.Sql.Parameters.Add(":equipoV", OracleDbType.Varchar2).Value = datosPartido.equipoV;
                _db.Sql.Parameters.Add(":fecha", OracleDbType.Date).Value = datosPartido.fecha;

                affectedRows = _db.execSQL();

            }
            catch (Exception e)
            {
                throw new Exception("Error en updateResultadoPartido(): " + e.Message);
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
