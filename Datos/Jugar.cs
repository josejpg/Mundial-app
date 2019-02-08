using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Jugar
    {

        /// <summary>
        /// Constructor  Sin argumentos
        /// </summary>
        public Jugar() { }

        /// <summary>
        /// Devuelve los datos de un jugador cuyo nombre se pasa por parametro utilizando un procedure
        /// Al no funcionar el procedure se hace una consulta directa a DB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Entidades.Jugar> getJugadoresPartido(string name, DateTime date)
        {
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            List<Entidades.Jugar> listJugadores = new List<Entidades.Jugar>();
            string _sql = "";

            try
            {
                _sql = $@"SELECT DISTINCT 
                                j.NOMBRE_JUG, 
                                j.MIN_JUGAR, 
                                j.PUESTO_JUGAR, 
                                j.DORSAL
                            FROM 
                                jugador jug, , 
                            LEFT JOIN 
                                equipos e 
                                ON 
                                    jug.EQUIPO_JUGADOR = e.EQUIPO
                            LEFT JOIN 
                                jugar j 
                                ON 
                                    jug.NOMBRE = j.NOMBRE_JUG
                            LEFT JOIN 
                               partido p
                                ON 
                                    jug.NOMBRE = j.NOMBRE_JUG
                            LEFT JOIN 
                               partido p 
                                ON 
                                    j.EQUIPO_L_PART = p.EQUIPO_L
                                OR 
                                    j.EQUIPO_V_PART = p.EQUIPO_V
                            WHERE  
                            AND 
                                p.FECHA = '{ date.ToString( "dd/MM/yy" ) }'
                            AND 
                                e.EQUIPO like upper('%{ name }%')
                            ORDER BY
                                j.MIN_JUGAR DESC";

                _db.startDB();
                _db.Sql = _db.DbConnection.CreateCommand();
                _db.Sql.CommandType = CommandType.Text;
                _db.Sql.CommandText = _sql;
                _dataSQL = _db.selectSQL();
                while (_dataSQL.Read())
                {
                    listJugadores.Add(new Entidades.Jugar {
                        nombreJug = _dataSQL[ 0 ].ToString(),
                        minJugar = Convert.ToInt32( _dataSQL[ 1 ] ),
                        puestoJugar = _dataSQL[ 2 ].ToString(),
                        dorsal = Convert.ToInt32( _dataSQL[ 3 ] ),
                    });
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en getJugadoresPartido(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return listJugadores;
        }

    }
}
