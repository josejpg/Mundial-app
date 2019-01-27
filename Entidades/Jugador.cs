using System;

namespace Entidades
{
    /// <author>
	/// Jose Javier Pardines Garcia
	/// </author>
    public class Jugador
    {

        /// <summary>
        /// Atributos
        /// </summary>
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string puestoHab { get; set; }
        public DateTime fechaNac { get; set; }
        public string equipoJugador { get; set; }
        public byte[] avatar { get; set; }

        /// <summary>
        /// Constructor Sin argumentos
        /// </summary>
        public Jugador() { }

        /// <summary>
        /// Constructor Con argumentos
        /// </summary>
        public Jugador(
            string newNombre,
            string newDireccion,
            string newPuestoHab,
            DateTime newFechaNac,
            string newEquipoJugador
        )
        {
            this.nombre = newNombre;
            this.direccion = newDireccion;
            this.puestoHab = newPuestoHab;
            this.fechaNac = newFechaNac;
            this.equipoJugador = newEquipoJugador;
        }

        /// <summary>
        /// Constructor Copia
        /// </summary>
        public Jugador(Jugador previousJugador)
        {
            this.nombre = previousJugador.nombre;
            this.direccion = previousJugador.direccion;
            this.puestoHab = previousJugador.puestoHab;
            this.fechaNac = previousJugador.fechaNac;
            this.equipoJugador = previousJugador.equipoJugador;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Jugador()
        {
            this.nombre = "";
            this.direccion = null;
            this.puestoHab = null;
            this.fechaNac = DateTime.Now;
            this.equipoJugador = "";
        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()
        {
            return $"{ this.nombre }#{ this.direccion }#{ this.puestoHab }#{ this.fechaNac.ToString("dd/MM/yyyy") }#{ this.equipoJugador }";
        }
    }
}
