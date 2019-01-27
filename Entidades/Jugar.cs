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
		public string nombreJug { get; set; }
        public string equpipoLPart { get; set; }
        public string equpipoVPart { get; set; }
        public DateTime fechaPart { get; set; }
        public int? minJugar { get; set; }
        public string puestoJugar { get; set; }
        public int? dorsal { get; set; }

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

            this.nombreJug = newNombreJug;
            this.equpipoLPart = newEquipoLPart;
            this.equpipoVPart = newEquipoVPart;
            this.fechaPart = newFechaPart;
            this.minJugar = newMinJugar;
            this.puestoJugar = newPuestoJugar;
            this.dorsal = newDorsal;

        }

        public Jugar(Jugar previousJugar)
        {

            this.nombreJug = previousJugar.nombreJug;
            this.equpipoLPart = previousJugar.equpipoLPart;
            this.equpipoVPart = previousJugar.equpipoVPart;
            this.fechaPart = previousJugar.fechaPart;
            this.minJugar = previousJugar.minJugar;
            this.puestoJugar = previousJugar.puestoJugar;
            this.dorsal = previousJugar.dorsal;

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Jugar()
        {

            this.nombreJug = "";
            this.equpipoLPart = "";
            this.equpipoVPart = "";
            this.fechaPart = DateTime.Now;
            this.minJugar = null;
            this.puestoJugar = "";
            this.dorsal = null;

        }

        /// <summary>
        /// toString
        /// </summary>
        public override string ToString()

        {

            return $"{ this.nombreJug }#{ this.equpipoLPart }#{ this.equpipoVPart }#{ this.fechaPart.ToString("dd/MM/yyyy") }#{ this.minJugar }#{ this.puestoJugar }#{ this.dorsal }";

        }

    }
}
