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
        private string _nombre;
        private string _direccion;
        private string _puestoHab;
        private DateTime _fechaNac;
        private string _equipoJugador;
        private byte[] _avatar;

        /// <summary>
        /// Variables
        /// </summary>
        public string Nombre
        {
            get => this._nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {
                    if (value.Length <= 60)
                    {
                        this._nombre = value;
                    }
                    else
                    {
                        throw new Exception("El nombre del jugador no puede superar los 60 caracteres.");
                    }
                }
                else
                {
                    throw new Exception("El nombre del jugador no puede ser nulo ni vacío.");
                }
            }
        }
        public string Direccion
        {
            get => this._direccion;
            set
            {
                if (value.Length <= 150)
                {
                    this._direccion = value;
                }
                else
                {
                    throw new Exception("La dirección no puede superar los 150 caracteres.");
                }
            }
        }
        public string PuestoHab
        {
            get => this._puestoHab;
            set
            {
                if (value.Length <= 2)
                {
                    this._puestoHab = value;
                }
                else
                {
                    throw new Exception("El puestoHab no puede superar los 2 caracteres.");
                }
            }
        }
        public DateTime FechaNac
        {
            get => this._fechaNac;
            set => this._fechaNac = value;
        }
        public string EquipoJugador
        {
            get => this._equipoJugador;
            set
            {
                if (!string.IsNullOrWhiteSpace(value.Trim())) { 
                    if (value.Length <= 50) { 
                        this._equipoJugador = value;
                    }
                    else
                    {
                        throw new Exception("El equipo del jugador no puede superar los 50 caracteres.");
                    }
                }
                else
                {
                    throw new Exception("El equipo del jugador no puede ser nulo ni vacío.");
                }
            }
        }
        public byte[] Avatar
        {
            get
            {
                return this._avatar;
            }
            set
            {
                this._avatar = value;
            }
        }

        /// <summary>
        /// Constructor Sin argumentos
        /// </summary>
        public Jugador() {
            this._nombre = "";
            this._direccion = null;
            this._puestoHab = null;
            this._fechaNac = DateTime.Now;
            this._equipoJugador = "";
        }

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
            this._nombre = newNombre;
            this._direccion = newDireccion;
            this._puestoHab = newPuestoHab;
            this._fechaNac = newFechaNac;
            EquipoJugador = newEquipoJugador;
        }

        /// <summary>
        /// Constructor Copia
        /// </summary>
        public Jugador(Jugador previousJugador)
        {
            this._nombre = previousJugador.Nombre;
            this._direccion = previousJugador.Direccion;
            this._puestoHab = previousJugador.PuestoHab;
            this._fechaNac = previousJugador.FechaNac;
            this._equipoJugador = previousJugador.EquipoJugador;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Jugador()
        {
            this._nombre = "";
            this._direccion = null;
            this._puestoHab = null;
            this._fechaNac = DateTime.Now;
            this._equipoJugador = "";
        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()
        {
            return $"{ this._nombre }#{ this._direccion }#{ this._puestoHab }#{ this._fechaNac.ToString("dd/MM/yyyy") }#{ this._equipoJugador }";
        }
    }
}
