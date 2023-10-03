using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesDeRetiroApp.Diseño
{
    public partial class FrmReporteMateriales : Form
    {
        public FrmReporteMateriales()
        {
            InitializeComponent();
        }

        private void FrmReporteMateriales_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSMateriales.SP_CONSULTAR_MATERIALES' Puede moverla o quitarla según sea necesario.
            this.sP_CONSULTAR_MATERIALESTableAdapter.Fill(this.dSMateriales.SP_CONSULTAR_MATERIALES);

            this.reportViewer1.RefreshReport();
        }
    }
}
