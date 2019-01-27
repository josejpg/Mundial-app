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
        public int idRol { get; set; }
        public string descRol { get; set; }

        /// <summary>
        /// Constructor Sin argumentos
        /// </summary>
        public Rol() { }

        /// <summary>
        /// Constructor Con argumentos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rol"></param>
        public Rol( int id, string rol )
        {
            this.idRol = id;
            this.descRol = rol;
        }
        /// <summary>
        /// Constructor Copia
        /// </summary>
        /// <param name="previousRol"></param>
        public Rol(Rol previousRol)
        {
            this.idRol = previousRol.idRol;
            this.descRol = previousRol.descRol;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Rol()
        {
            this.idRol = 0;
            this.descRol = "";
        }

        /// <summary>
        /// Devuelve el objeto en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ this.idRol }#{ this.descRol }";
        }
    }
}
