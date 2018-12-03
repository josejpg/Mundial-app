using System;

namespace Entidades
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    class Jugar
    {

        /// <summary>
        /// Atributos
        /// </summary>
		private string _nombreJug;
        private string _equpipoLPart;
        private string _equpipoVPart;
        private DateTime _fechaPart;
        private int? _minJugar;
        private string _puestoJugar;
        private int? _dorsal;

        /// <summary>
        /// Variables
        /// </summary>
        public string NombreJug
        {

            get => this._nombreJug;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 60)
                    {

                        this._nombreJug = value;

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

        public string EquipoLPart
        {

            get => this._equpipoLPart;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equpipoLPart = value;

                    }
                    else
                    {

                        throw new Exception("El equipo L part no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipo L part no puede ser nulo ni vacío.");

                }

            }

        }

        public string EquipoVPart
        {

            get => this._equpipoVPart;

            set
            {

                if (!string.IsNullOrWhiteSpace(value.Trim()))
                {

                    if (value.Length <= 50)
                    {

                        this._equpipoVPart = value;

                    }
                    else
                    {

                        throw new Exception("El equipo V part no puede superar los 50 caracteres.");

                    }


                }
                else
                {

                    throw new Exception("El equipo V part no puede ser nulo ni vacío.");

                }

            }

        }

        public DateTime FechaPart
        {

            get => this._fechaPart;

            set
            {
                DateTime time;

                if (DateTime.TryParse(value.ToString(), out time))
                {

                    this._fechaPart = value;

                }
                else
                {

                    throw new Exception("La fecha part no tiene un formato válido.");

                }

            }

        }

        public int? MinJugar
        {

            get => this._minJugar;

            set
            {

                if (value >= 0 && value.ToString().Length <= 3)
                {

                    this._minJugar = value;

                }
                else
                {

                    throw new Exception("Los minJugar no pueden ser menores a 0 ni superar los 3 caracteres.");

                }

            }

        }

        public string PuestoJugar
        {

            get => this._puestoJugar;

            set
            {

                if (value.Length <= 2)
                {

                    this._puestoJugar = value;

                }
                else
                {

                    throw new Exception("El puestoJugar no puede superar los 2 caracteres.");

                }

            }

        }

        public int? Dorsal
        {

            get => this._dorsal;

            set => this._dorsal = value;

        }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Jugar() { }

        public Jugar(
            string newNombreJug,
            string newEquipoLPart,
            string newEquipoVPart,
            DateTime newFechaPart,
            int newMinJugar,
            string newPuestoJugar,
            int newDorsal
        )
        {

            NombreJug = newNombreJug;
            EquipoLPart = newEquipoLPart;
            EquipoVPart = newEquipoVPart;
            FechaPart = newFechaPart;
            MinJugar = newMinJugar;
            PuestoJugar = newPuestoJugar;
            Dorsal = newDorsal;

        }

        public Jugar(Jugar previousJugar)
        {

            NombreJug = previousJugar.NombreJug;
            EquipoLPart = previousJugar.EquipoLPart;
            EquipoVPart = previousJugar.EquipoVPart;
            FechaPart = previousJugar.FechaPart;
            MinJugar = previousJugar.MinJugar;
            PuestoJugar = previousJugar.PuestoJugar;
            Dorsal = previousJugar.Dorsal;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Jugar()
        {

            NombreJug = "";
            EquipoLPart = "";
            EquipoVPart = "";
            FechaPart = DateTime.Now;
            MinJugar = null;
            PuestoJugar = "";
            Dorsal = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this._nombreJug }#{ this._equpipoLPart }#{ this._equpipoVPart }#{ this._fechaPart.ToString("dd/MM/yyyy") }#{ this._minJugar }#{ this._puestoJugar }#{ this._dorsal }";

        }

    }
}
