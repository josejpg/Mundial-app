using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Gol
    {
        /// <summary>
        /// Constructor  Sin argumentos
        /// </summary>
        public Gol() { }

        /// <summary>
        /// Devuelve un listado de golEntidad generados a partir de una select
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Entidades.Gol> getGoles(string name, DateTime date)
        {
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            List<Entidades.Gol> listGoles = new List<Entidades.Gol>();
            string _sql = "";

            try
            {
                _sql = $@"SELECT 
                            DISTINCT g.*
                        FROM 
                            GOL g
                        LEFT JOIN 
                            JUGADOR jug 
                            ON 
                                jug.NOMBRE = g.JUGADOR_GOL
                        LEFT JOIN 
                            PARTIDO p
                            ON 
                                p.EQUIPO_L = g.EQUIPO_L_GOL
                            AND 
                                 p.EQUIPO_V = g.EQUIPO_V_GOL
                        LEFT JOIN 
                            EQUIPOS e 
                            ON 
                                e.EQUIPO = jug.EQUIPO_JUGADOR
                        WHERE   
                            p.FECHA = '{ date.ToString("dd/MM/yy") }'
                        AND 
                            e.EQUIPO = upper('{ name }')
                        ORDER BY
                            g.MINUTO DESC";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();
                while (_dataSQL.Read())
                {
                    listGoles.Add(new Entidades.Gol
                    {
                        minuto = Convert.ToInt32(_dataSQL[0]),
                        jugadorGol = _dataSQL[1].ToString(),
                        equipoLGol = _dataSQL[2].ToString(),
                        equipoVGol = _dataSQL[3].ToString(),
                        fechaGol = (DateTime)_dataSQL[4]
                    });
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en getGoles(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return listGoles;
        }

        /// <summary>
        /// Elimina un gol concreto de la DB
        /// </summary>
        /// <param name="ge"></param>
        /// <returns></returns>
        public int removeGol(Entidades.Gol datosGol)
        {
            string sql;
            DataBase _db = new DataBase();
            int affectedRows = 0;

            try
            {
                sql = @"DELETE 
                        FROM gol 
                        WHERE MINUTO = :minuto 
                        and JUGADOR_GOL = :jugadorGol 
                        and EQUIPO_L_GOL = :equipoLGol 
                        and EQUIPO_V_GOL = :equipoVGol
                        and FECHA_GOL = :fechaGol";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = sql;
                _db.Sql.Parameters.Add(":minuto", OracleDbType.Int32).Value = datosGol.minuto;
                _db.Sql.Parameters.Add(":jugadorGol", OracleDbType.Varchar2).Value = datosGol.jugadorGol;
                _db.Sql.Parameters.Add(":equipoLGol", OracleDbType.Varchar2).Value = datosGol.equipoLGol;
                _db.Sql.Parameters.Add(":equipoVGol", OracleDbType.Varchar2).Value = datosGol.equipoVGol;
                _db.Sql.Parameters.Add(":fechaGol", OracleDbType.Date).Value = datosGol.fechaGol;

                affectedRows = _db.execSQL();
            }
            catch (Exception e)
            {
                throw new Exception("Error en removeGol(): " + e.Message);
            }
            finally
            {
                _db.closeDB();

            }
            return affectedRows;
        }

        // <summary>
        /// Funcion para insertar un gol de un partido, fecha etc concreto.
        /// </summary>
        /// <returns></returns>
        public int addGol(Entidades.Gol datosGol)
        {
            string sql;
            DataBase _db = new DataBase();
            int affectedRows = 0;

            try
            {

                sql = @"INSERT INTO GOL
                            (MINUTO, JUGADOR_GOL, EQUIPO_L_GOL, EQUIPO_V_GOL, FECHA_GOL)
                        VALUES
                            (:minuto, :jugadorGol, :equipoLGol, :equipoVGol, :fechaGol)";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = sql;
                _db.Sql.Parameters.Add(":minuto", OracleDbType.Int32).Value = datosGol.minuto;
                _db.Sql.Parameters.Add(":jugadorGol", OracleDbType.Varchar2).Value = datosGol.jugadorGol;
                _db.Sql.Parameters.Add(":equipoLGol", OracleDbType.Varchar2).Value = datosGol.equipoLGol;
                _db.Sql.Parameters.Add(":equipoVGol", OracleDbType.Varchar2).Value = datosGol.equipoVGol;
                _db.Sql.Parameters.Add(":fechaGol", OracleDbType.Date).Value = datosGol.fechaGol;

                affectedRows = _db.execSQL();
            }
            catch (Exception e)
            {
                throw new Exception("Error en addGol(): " + e.Message);
            }
            finally
            {
                _db.closeDB();

            }
            return affectedRows;
        }
    }
}
