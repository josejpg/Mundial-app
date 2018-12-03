using System;

namespace Entidades
{
    /// <author>
	/// Jose Javier Pardines Garcia
	/// </author>
    public class Partido
    {

        /// <summary>
        /// Atributos
        /// </summary>
        private string _equipoL;
        private string _equipoV;
        private DateTime _fecha;
        private string _hora;
        private string _sede;
        private int? _resultadoL;
        private int? _resultadoV;
        private int? _asistencia;

        /// <summary>
        /// Variables
        /// </summary>
        public string EquipoL
        {

            get => this._equipoL;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equipoL = value;

                    }
                    else
                    {

                        throw new Exception("El equipoL no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipoL no puede ser nulo ni vacío.");

                }

            }

        }
        public string EquipoV
        {

            get => this._equipoV;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equipoV = value;

                    }
                    else
                    {

                        throw new Exception("El equipoV no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipoV no puede ser nulo ni vacío.");

                }

            }

        }
        public DateTime Fecha
        {

            get => this._fecha;

            set
            {
                DateTime time;

                if (DateTime.TryParse(value.ToString(), out time))
                {

                    this._fecha = value;

                }
                else
                {

                    throw new Exception("La fecha no puede ser nula.");

                }

            }

        }
        public string Hora
        {

            get => this._hora;

            set
            {

                if (value.Length <= 8)
                {

                    DateTime time;

                    if (DateTime.TryParse(value, out time))
                    {

                        this._hora = value;

                    }
                    else
                    {

                        throw new Exception("La hora no tiene un formato correcto.");

                    }

                }
                else
                {

                    throw new Exception("La hora no puede superar los 8 caracteres.");

                }
            }

        }
        public string Sede
        {

            get => this._sede;

            set
            {

                if (value.Length <= 100)
                {

                    this._sede = value;

                }
                else
                {

                    throw new Exception("El equipoV no puede superar los 100 caracteres.");

                }

            }

        }
        public int? ResultadoL
        {

            get => this._resultadoL;

            set => this._resultadoL = value;

        }
        public int? ResultadoV
        {

            get => this._resultadoV;

            set => this._resultadoV = value;

        }
        public int? Asistencia
        {

            get => this._asistencia;

            set => this._asistencia = value;

        }

        public string FechaPartido
        {

            get => $"{ this._fecha.ToString("dd/MM/yyyy") } {  this._hora  }";

        }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Partido() { }

        public Partido(
            string newEquipoL,
            string newEquipoV,
            DateTime newfecha,
            string newhora,
            string newSede,
            int? newResultadoL,
            int? newResultadoV,
            int? newAsistencia
        )
        {

            EquipoL = newEquipoL;
            EquipoV = newEquipoV;
            Fecha = newfecha;
            Hora = newhora;
            Sede = newSede;
            ResultadoL = newResultadoL;
            ResultadoV = newResultadoV;
            Asistencia = newAsistencia;

        }

        public Partido(Partido previousPartidor)
        {

            EquipoL = previousPartidor.EquipoL;
            EquipoV = previousPartidor.EquipoV;
            Fecha = previousPartidor.Fecha;
            Hora = previousPartidor.Hora;
            Sede = previousPartidor.Sede;
            ResultadoL = previousPartidor.ResultadoL;
            ResultadoV = previousPartidor.ResultadoV;
            Asistencia = previousPartidor.Asistencia;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Partido()
        {

            EquipoL = "";
            EquipoV = "";
            Fecha = DateTime.Now;
            Hora = "00:00:00";
            Sede = "";
            ResultadoL = null;
            ResultadoV = null;
            Asistencia = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()
        {

            return $"{ this._equipoL }#{ this._equipoV }#{ this._fecha.ToString("dd/MM/yyyy") }#{ this._hora }#{ this._sede }#{ this._resultadoL }#{ this._resultadoV }#{ this._asistencia }";

        }

        /// <summary>
        /// Métodos
        /// </summary>
        public int ComparaFechaPartido(object obj)
        {

            Partido p = (Partido)obj;
            return string.Compare(this.FechaPartido, p.FechaPartido);

        }

    }
}
