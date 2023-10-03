namespace OrdenesDeRetiroApp.Diseño
{
    partial class FrmReporteMateriales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSMateriales = new OrdenesDeRetiroApp.Diseño.Reportes.DSMateriales();
            this.sPCONSULTARMATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_CONSULTAR_MATERIALESTableAdapter = new OrdenesDeRetiroApp.Diseño.Reportes.DSMaterialesTableAdapters.SP_CONSULTAR_MATERIALESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARMATERIALESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPCONSULTARMATERIALESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OrdenesDeRetiroApp.Diseño.Reportes.RptMateriales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(633, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSMateriales
            // 
            this.dSMateriales.DataSetName = "DSMateriales";
            this.dSMateriales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPCONSULTARMATERIALESBindingSource
            // 
            this.sPCONSULTARMATERIALESBindingSource.DataMember = "SP_CONSULTAR_MATERIALES";
            this.sPCONSULTARMATERIALESBindingSource.DataSource = this.dSMateriales;
            // 
            // sP_CONSULTAR_MATERIALESTableAdapter
            // 
            this.sP_CONSULTAR_MATERIALESTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 351);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteMateriales";
            this.Text = "FrmReporteMateriales";
            this.Load += new System.EventHandler(this.FrmReporteMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARMATERIALESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSMateriales dSMateriales;
        private System.Windows.Forms.BindingSource sPCONSULTARMATERIALESBindingSource;
        private Reportes.DSMaterialesTableAdapters.SP_CONSULTAR_MATERIALESTableAdapter sP_CONSULTAR_MATERIALESTableAdapter;
    }
}