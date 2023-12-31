﻿using OrdenesDeRetiroApp.Diseño;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesDeRetiroApp
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void registrarNuevaOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarOrden registrar = new FrmRegistrarOrden();
            registrar.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro de que desea salir?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void listadoDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteMateriales reporte = new FrmReporteMateriales();
            reporte.ShowDialog();
        }
    }
}
