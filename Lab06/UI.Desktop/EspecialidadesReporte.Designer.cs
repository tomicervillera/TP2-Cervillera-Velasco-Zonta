namespace UI.Desktop
{
    partial class EspecialidadesReporte
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
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.repViewerEspecialidades = new Microsoft.Reporting.WinForms.ReportViewer();
            this.especialidadesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.especialidadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            this.especialidadesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repViewerEspecialidades
            // 
            this.repViewerEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "EspecialidadesDataSet";
            reportDataSource1.Value = this.especialidadesBindingSource;
            this.repViewerEspecialidades.LocalReport.DataSources.Add(reportDataSource1);
            this.repViewerEspecialidades.LocalReport.ReportEmbeddedResource = "UI.Desktop.EspecialidadesReporte.rdlc";
            this.repViewerEspecialidades.Location = new System.Drawing.Point(12, 12);
            this.repViewerEspecialidades.Name = "repViewerEspecialidades";
            this.repViewerEspecialidades.ServerReport.BearerToken = null;
            this.repViewerEspecialidades.Size = new System.Drawing.Size(635, 527);
            this.repViewerEspecialidades.TabIndex = 0;
            // 
            // especialidadesTableAdapter
            // 
            this.especialidadesTableAdapter.ClearBeforeFill = true;
            // 
            // EspecialidadesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 551);
            this.Controls.Add(this.repViewerEspecialidades);
            this.Name = "EspecialidadesReporte";
            this.Text = "Reporte de Especialidades";
            this.Load += new System.EventHandler(this.EspecialidadesReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repViewerEspecialidades;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private AcademiaDataSetTableAdapters.especialidadesTableAdapter especialidadesTableAdapter;
    }
}