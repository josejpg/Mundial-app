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
        public string equipoL { get; set; }
        public string equipoV { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string sede { get; set; }
        public int? resultadoL { get; set; }
        public int? resultadoV { get; set; }
        public int? asistencia { get; set; }

        public string FechaPartido
        {

            get => $"{ this.fecha.ToString("dd/MM/yyyy") } {  this.hora  }";

        }

        /// <summary>
        /// Constructores
        /// 1 - Sin argumentos
        /// 2 - Con argumentos
        /// 3 - Copia
        /// </summary>
        public Partido() { }

        public Partido(
            string equipoL,
            string equipoV,
            DateTime fecha,
            string hora,
            string sede,
            int? resultadoL,
            int? resultadoV,
            int? asistencia
        )
        {

            this.equipoL = equipoL;
            this.equipoV = equipoV;
            this.fecha = fecha;
            this.hora = hora;
            this.sede = sede;
            this.resultadoL = resultadoL;
            this.resultadoV = resultadoV;
            this.asistencia = asistencia;

        }

        public Partido(Partido previousPartidor)
        {

            this.equipoL = previousPartidor.equipoL;
            this.equipoV = previousPartidor.equipoV;
            this.fecha = previousPartidor.fecha;
            this.hora = previousPartidor.hora;
            this.sede = previousPartidor.sede;
            this.resultadoL = previousPartidor.resultadoL;
            this.resultadoV = previousPartidor.resultadoV;
            this.asistencia = previousPartidor.asistencia;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Partido()
        {

            this.equipoL = "";
            this.equipoV = "";
            this.fecha = DateTime.Now;
            this.hora = "00:00:00";
            this.sede = "";
            this.resultadoL = null;
            this.resultadoV = null;
            this.asistencia = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()
        {

            return $"{ this.equipoL }#{ this.equipoV }#{ this.fecha.ToString("dd/MM/yyyy") }#{ this.hora }#{ this.sede }#{ this.resultadoL }#{ this.resultadoV }#{ this.asistencia }";

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
