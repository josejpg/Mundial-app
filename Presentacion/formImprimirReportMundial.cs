using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Presentacion
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public partial class formImprimirReportMundial : Form
    {
        /// <summary>
        /// Variables
        /// </summary>
        public List<Entidades.Partido> listPartidos = new List<Entidades.Partido>();
        public string Year { get; set; }

        public formImprimirReportMundial()
        {
            InitializeComponent();
        }

        private void formImprimirReportMundial_Load(object sender, EventArgs e)
        {

            // Se limpia el DataSource del informe
            reportViewer1.LocalReport.DataSources.Clear();

            // Se agrega el parametro
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("year", Year);

            // Se agrega el list de partidos
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", listPartidos));

            // Se envía la lista de parametros
            reportViewer1.LocalReport.SetParameters(parameters);

            // Se realiza un refresh al reportViewer
            reportViewer1.RefreshReport();
        }
    }
}
