using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <author>
	/// Jose Javier Pardines Garcia
	/// </author>
    public class Rol
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private int _idRol;
        private string _descRol;

        /// <summary>
        /// Variables
        /// </summary>
        public int IdRol
        {
            get => this._idRol;
            set => this._idRol = value;
        }
        public string DescRol
        {
            get => this._descRol;
            set => this._descRol = value;
        }

        /// <summary>
        /// Constructor Sin argumentos
        /// </summary>
        public Rol()
        {
            _idRol = 0;
            DescRol = string.Empty;
        }
        /// <summary>
        /// Constructor Con argumentos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rol"></param>
        public Rol( int id, string rol )
        {
            IdRol = id;
            DescRol = rol;
        }
        /// <summary>
        /// Constructor Copia
        /// </summary>
        /// <param name="previousRol"></param>
        public Rol(Rol previousRol)
        {
            this._idRol = previousRol.IdRol;
            this._descRol = previousRol.DescRol;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Rol()
        {
            this._idRol = 0;
            this._descRol = string.Empty;
        }

        /// <summary>
        /// Devuelve el objeto en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ this._idRol }#{ this._descRol }";
        }
    }
}
