namespace UI.Desktop
{
    partial class ComisionesReporte
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
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.repViewerComisiones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comisionesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.comisionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repViewerComisiones
            // 
            this.repViewerComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "comisionesDataSet";
            reportDataSource1.Value = this.comisionesBindingSource;
            this.repViewerComisiones.LocalReport.DataSources.Add(reportDataSource1);
            this.repViewerComisiones.LocalReport.ReportEmbeddedResource = "UI.Desktop.ComisionesReporte.rdlc";
            this.repViewerComisiones.Location = new System.Drawing.Point(12, 12);
            this.repViewerComisiones.Name = "repViewerComisiones";
            this.repViewerComisiones.ServerReport.BearerToken = null;
            this.repViewerComisiones.Size = new System.Drawing.Size(638, 496);
            this.repViewerComisiones.TabIndex = 0;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // ComisionesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 520);
            this.Controls.Add(this.repViewerComisiones);
            this.Name = "ComisionesReporte";
            this.Text = "Reporte de Comisiones";
            this.Load += new System.EventHandler(this.ComisionesReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repViewerComisiones;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private AcademiaDataSetTableAdapters.comisionesTableAdapter comisionesTableAdapter;
    }
}