using System;
using System.Data;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    class DataBase
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private string _userDB;
        private string _pswDB;
        private string _hostDB;
        private string _portDB;
        private string _dbDB;
        private OracleConnection _dbConection;
        private OracleCommand _sql;
        private OracleDataReader _reader;

        /// <summary>
        /// Variables
        /// </summary>
        public OracleConnection DbConnection
        {
            get => this._dbConection;
 
        }
        public OracleCommand Sql
        {
            get => this._sql;
            set => this._sql = value;
        }

        /// <summary>
        /// Constructor Con argumentos
        /// </summary>
        /// <param name="user"></param>
        /// <param name="psw"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="db"></param>
        public DataBase(string user, string psw, string host, string port, string db)
        {
            this._userDB = user;
            this._pswDB = psw;
            this._hostDB = host;
            this._portDB = port;
            this._dbDB = db;
        }
        /// <summary>
        /// Constructor Sin argumentos
        /// </summary>
        public DataBase()
        {
            this._userDB = "MUNDIAL";
            this._pswDB = "1234";
            this._hostDB = "localhost";
            this._portDB = "1521";
            this._dbDB = "XE";
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~DataBase()
        {
            this._userDB = "";
            this._pswDB = "";
            this._hostDB = "";
            this._portDB = "";
            this._dbDB = "";
            this.closeDB();
        }

        /// <summary>
        /// Crea la conexión a la DB
        /// </summary>
        public void startDB()
        {
            string strConexion = string.Format("User Id={0}; Password={1}; Data Source={2}:{3}/{4}", this._userDB, this._pswDB, this._hostDB, this._portDB, this._dbDB);
            this._dbConection = new OracleConnection(strConexion);
            this._dbConection.ConnectionString = strConexion;
            this._dbConection.Open();
        }

        /// <summary>
        /// Cierra la conexión a la DB
        /// </summary>
        public void closeDB()
        {
            if (this._reader != null && 
                this._reader.IsClosed == false)
            {
                this._reader.Close();
                this._reader.Dispose();
                this._sql.Dispose();
            }

            if (this._dbConection != null && 
                this._dbConection.State == ConnectionState.Open)
            {
                this._dbConection.Close();
                this._dbConection.Dispose();
            }
        }

        /// <summary>
        /// Ejecuta una consulta SQL (SELECT)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OracleDataReader selectSQL()
        {
            this._reader = null;
            try
            {
                if (this._dbConection.State == ConnectionState.Open)
                {
                    // ExecuteReader hace la consulta y devuelve un OracleDataReader
                    this._reader = _sql.ExecuteReader();
                }
                else
                {
                    throw new ApplicationException("Error en selectSQL():\n\nNo se ha podido abrir la Base de Datos");
                }
            }catch(InvalidOperationException e)
            {
                throw new InvalidOperationException("Error en selectSQL():\n\nEl error devuelto es: " + e.ToString());
            }

            return this._reader;
        }

        /// <summary>
        /// Ejecuta una consulta SQL (INERT,UPDATE,DELETE)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int execSQL()
        {
            int affectedRows = 0;
            try
            {
                if (this._dbConection.State == ConnectionState.Open)
                {

                    // ExecuteNonQuery ejecuta la sql y devuelve la cantidad de filas afectadas
                    affectedRows = this._sql.ExecuteNonQuery();
                    this._sql.Dispose();
                }
                else
                {
                    throw new ApplicationException("No se ha podido abrir la Base de Datos");
                }
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Error al ejecutar la sql:\n" + this._sql + "\n\nEl error devuelto es: " + e.ToString());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return affectedRows;

        }
    }
}
