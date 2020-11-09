namespace UI.Desktop
{
    partial class DocentesCursosReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocentesCursosReporte));
            this.docentes_cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.repViewerDocentesCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.docentes_cursosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.docentes_cursosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.docentes_cursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // docentes_cursosBindingSource
            // 
            this.docentes_cursosBindingSource.DataMember = "docentes_cursos";
            this.docentes_cursosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repViewerDocentesCursos
            // 
            this.repViewerDocentesCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DocentesCursosDataSet";
            reportDataSource1.Value = this.docentes_cursosBindingSource;
            this.repViewerDocentesCursos.LocalReport.DataSources.Add(reportDataSource1);
            this.repViewerDocentesCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.DocentesCursosReporte.rdlc";
            this.repViewerDocentesCursos.Location = new System.Drawing.Point(12, 12);
            this.repViewerDocentesCursos.Name = "repViewerDocentesCursos";
            this.repViewerDocentesCursos.ServerReport.BearerToken = null;
            this.repViewerDocentesCursos.Size = new System.Drawing.Size(649, 542);
            this.repViewerDocentesCursos.TabIndex = 0;
            // 
            // docentes_cursosTableAdapter
            // 
            this.docentes_cursosTableAdapter.ClearBeforeFill = true;
            // 
            // DocentesCursosReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 566);
            this.Controls.Add(this.repViewerDocentesCursos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocentesCursosReporte";
            this.Text = "Reporte de Docentes-Cursos";
            this.Load += new System.EventHandler(this.DocentesCursosReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docentes_cursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repViewerDocentesCursos;
        private System.Windows.Forms.BindingSource docentes_cursosBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private AcademiaDataSetTableAdapters.docentes_cursosTableAdapter docentes_cursosTableAdapter;
    }
}