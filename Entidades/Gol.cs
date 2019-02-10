using System;

namespace Entidades
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Gol
    {

        /// <summary>
        /// Atributos
        /// </summary>
        public int minuto { get; set; }
        public string jugadorGol { get; set; }
        public string equipoLGol { get; set; }
        public string equipoVGol { get; set; }
        public DateTime fechaGol { get; set; }

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

            this.minuto = newMinuto;
            this.jugadorGol = newJugadorGol;
            this.equipoLGol = newEquipoLGol;
            this.equipoVGol = newEquipoVGol;
            this.fechaGol = newFechaGol;

        }

        public Gol(Gol previousGol)
        {

            this.minuto = previousGol.minuto;
            this.jugadorGol = previousGol.jugadorGol;
            this.equipoLGol = previousGol.equipoLGol;
            this.equipoVGol = previousGol.equipoVGol;
            this.fechaGol = previousGol.fechaGol;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Gol()
        {

            this.minuto = 0;
            this.jugadorGol = "";
            this.equipoLGol = "";
            this.equipoVGol = "";
            this.fechaGol = DateTime.Now;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this.minuto }#{ this.jugadorGol }#{ this.equipoLGol }#{ this.equipoVGol }#{ this.fechaGol.ToString("dd/MM/yyyy") }";

        }

    }
}
