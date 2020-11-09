namespace UI.Desktop
{
    partial class PlanesReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanesReporte));
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.repViewerPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.planesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.planesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repViewerPlanes
            // 
            this.repViewerPlanes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "PlanesDataSet";
            reportDataSource1.Value = this.planesBindingSource;
            this.repViewerPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.repViewerPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.PlanesReporte.rdlc";
            this.repViewerPlanes.Location = new System.Drawing.Point(12, 12);
            this.repViewerPlanes.Name = "repViewerPlanes";
            this.repViewerPlanes.ServerReport.BearerToken = null;
            this.repViewerPlanes.Size = new System.Drawing.Size(638, 535);
            this.repViewerPlanes.TabIndex = 0;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // PlanesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 559);
            this.Controls.Add(this.repViewerPlanes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlanesReporte";
            this.Text = "Reporte de Planes";
            this.Load += new System.EventHandler(this.PlanesReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repViewerPlanes;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private AcademiaDataSetTableAdapters.planesTableAdapter planesTableAdapter;
    }
}