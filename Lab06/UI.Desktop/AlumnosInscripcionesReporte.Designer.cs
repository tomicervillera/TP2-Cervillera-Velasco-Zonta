namespace UI.Desktop
{
    partial class AlumnosInscripcionesReporte
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
            this.alumnos_inscripcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.repViewInscripciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.alumnos_inscripcionesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // alumnos_inscripcionesBindingSource
            // 
            this.alumnos_inscripcionesBindingSource.DataMember = "alumnos_inscripciones";
            this.alumnos_inscripcionesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repViewInscripciones
            // 
            this.repViewInscripciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repViewInscripciones.DocumentMapWidth = 39;
            reportDataSource1.Name = "DataSetInscripciones";
            reportDataSource1.Value = this.alumnos_inscripcionesBindingSource;
            this.repViewInscripciones.LocalReport.DataSources.Add(reportDataSource1);
            this.repViewInscripciones.LocalReport.ReportEmbeddedResource = "UI.Desktop.AlumnosInscripcionesReporte.rdlc";
            this.repViewInscripciones.Location = new System.Drawing.Point(12, 12);
            this.repViewInscripciones.Name = "repViewInscripciones";
            this.repViewInscripciones.ServerReport.BearerToken = null;
            this.repViewInscripciones.Size = new System.Drawing.Size(634, 494);
            this.repViewInscripciones.TabIndex = 0;
            // 
            // alumnos_inscripcionesTableAdapter
            // 
            this.alumnos_inscripcionesTableAdapter.ClearBeforeFill = true;
            // 
            // AlumnosInscripcionesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 518);
            this.Controls.Add(this.repViewInscripciones);
            this.Name = "AlumnosInscripcionesReporte";
            this.Text = "Reporte de Inscripciones";
            this.Load += new System.EventHandler(this.AlumnosInscripcionesReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repViewInscripciones;
        private System.Windows.Forms.BindingSource alumnos_inscripcionesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private AcademiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter alumnos_inscripcionesTableAdapter;
    }
}