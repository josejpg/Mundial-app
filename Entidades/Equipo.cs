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
		private string _nombreEquipo;
        private string _pais;
        private string _seleccionador;

        /// <summary>
        /// Variables
        /// </summary>
        public string NombreEquipo
        {

            get => this._nombreEquipo;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._nombreEquipo = value;

                    }
                    else
                    {

                        throw new Exception("El nombre del equipo no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El nombre del equipo no puede ser nulo ni vacío.");

                }

            }

        }

        public string Pais
        {

            get => this._pais;

            set
            {

                if (value.Length <= 30)
                {

                    this._pais = value;

                }
                else
                {

                    throw new Exception("El país no puede superar los 30 caracteres.");

                }

            }

        }

        public string Seleccionador
        {

            get => this._seleccionador;

            set
            {

                if (value.Length <= 50)
                {

                    this._seleccionador = value;

                }
                else
                {

                    throw new Exception("El seleccionador no puede superar los 50 caracteres.");

                }

            }

        }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Equipo() { }

        public Equipo(
            string equipo,
            string pais,
            string seleccionador)
        {

            NombreEquipo = equipo;
            Pais = pais;
            Seleccionador = seleccionador;

        }

        public Equipo(Equipo previousEquipo)
        {

            this._nombreEquipo = previousEquipo.NombreEquipo;
            this._pais = previousEquipo.Pais;
            this._seleccionador = previousEquipo.Seleccionador;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Equipo()
        {

            this._nombreEquipo = "";
            this._pais = null;
            this._seleccionador = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this._nombreEquipo }#{ this._pais }#{ this._seleccionador }";

        }

    }
}
