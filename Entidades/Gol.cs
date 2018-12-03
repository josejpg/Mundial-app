using System;

namespace Entidades
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    class Gol
    {

        /// <summary>
        /// Atributos
        /// </summary>
        private int _minuto;
        private string _jugadorGol;
        private string _equipoLGol;
        private string _equipoVGol;
        private DateTime _fechaGol;

        /// <summary>
        /// Variables
        /// </summary>
        public int Minuto
        {

            get => this._minuto;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.ToString().Trim()))
                {

                    if (value > 0 && value.ToString().Length <= 3)
                    {

                        this._minuto = value;

                    }
                    else
                    {

                        throw new Exception("El minuto no puede superar los 60 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El minuto no puede ser nulo ni vacío.");

                }

            }

        }

        public string JugadorGol
        {

            get => this._jugadorGol;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 60)
                    {

                        this._jugadorGol = value;

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

        public string EquipoLGol
        {

            get => this._equipoLGol;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equipoLGol = value;

                    }
                    else
                    {

                        throw new Exception("El equipoLGol no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipoLGol no puede ser nulo ni vacío.");

                }

            }

        }

        public string EquipoVGol
        {

            get => this._equipoVGol;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equipoVGol = value;

                    }
                    else
                    {

                        throw new Exception("El equipoVGol no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipoVGol no puede ser nulo ni vacío.");

                }

            }

        }

        public DateTime FechaGol
        {

            get => this._fechaGol;

            set
            {

                DateTime time;

                if (DateTime.TryParse(value.ToString(), out time))
                {

                    this._fechaGol = value;

                }
                else
                {

                    throw new Exception("La fechaGol no tiene un formato válido.");

                }

            }

        }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Gol() { }

        public Gol(
            int newMinuto,
            string newJugadorGol,
            string newEquipoLGol,
            string newEquipoVGol,
            DateTime newFechaGol
        )
        {

            Minuto = newMinuto;
            JugadorGol = newJugadorGol;
            EquipoLGol = newEquipoLGol;
            EquipoVGol = newEquipoVGol;
            FechaGol = newFechaGol;

        }

        public Gol(Gol previousGol)
        {

            Minuto = previousGol.Minuto;
            JugadorGol = previousGol.JugadorGol;
            EquipoLGol = previousGol.EquipoLGol;
            EquipoVGol = previousGol.EquipoVGol;
            FechaGol = previousGol.FechaGol;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Gol()
        {

            Minuto = 0;
            JugadorGol = "";
            EquipoLGol = "";
            EquipoVGol = "";
            FechaGol = DateTime.Now;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this._minuto }#{ this._jugadorGol }#{ this._equipoLGol }#{ this._equipoVGol }#{ this._fechaGol.ToString("dd/MM/yyyy") }";

        }

    }
}
