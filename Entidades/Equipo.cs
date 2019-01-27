using System;


namespace Entidades
{
    /// <author>
	/// Jose Javier Pardines Garcia
	/// </author>
    public class Equipo
    {

        /// <summary>
        /// Atributos
        /// </summary>
		public string nombreEquipo { get; set; }
        public string pais { get; set; }
        public string seleccionador { get; set; }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Equipo() { }

        public Equipo(
            string nombreEquipo,
            string pais,
            string seleccionador)
        {

            this.nombreEquipo = nombreEquipo;
            this.pais = pais;
            this.seleccionador = seleccionador;

        }

        public Equipo(Equipo previousEquipo)
        {

            this.nombreEquipo = previousEquipo.nombreEquipo;
            this.pais = previousEquipo.pais;
            this.seleccionador = previousEquipo.seleccionador;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Equipo()
        {

            this.nombreEquipo = "";
            this.pais = null;
            this.seleccionador = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this.nombreEquipo }#{ this.pais }#{ this.seleccionador }";

        }

    }
}
