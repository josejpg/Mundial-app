using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Rol
    {
        /// <summary>
        /// Constructor  Sin argumentos
        /// </summary>
        public Rol() { }

        /// <summary>
        /// Recupera todos los roles de la db
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Rol> getRoles()
        {

            List<Entidades.Rol> _listRoles = new List<Entidades.Rol>();
            DataBase _db = new DataBase();
            OracleDataReader _dataSQL;
            string _sql = "SELECT * FROM ROL_APP";

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
                    _listRoles.Add(
                        new Entidades.Rol
                        {
                            idRol = int.Parse(_dataSQL[0].ToString()),
                            descRol = _dataSQL[1].ToString()
                        }
                    );
                }

                _dataSQL.Close();
                _dataSQL.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Error en getRoles(): " + e.Message);
            }
            finally
            {
                // Llamar siempre a Close una vez finalizada la lectura
                _db.closeDB();
            }
            return _listRoles;
        }
    }
}
