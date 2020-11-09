namespace UI.Desktop
{
    partial class AlumnosInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnosInscripciones));
            this.tscAlumnosInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlAlumnosInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnosInscripciones = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsAlumnosInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscAlumnosInscripciones.ContentPanel.SuspendLayout();
            this.tscAlumnosInscripciones.TopToolStripPanel.SuspendLayout();
            this.tscAlumnosInscripciones.SuspendLayout();
            this.tlAlumnosInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).BeginInit();
            this.tsAlumnosInscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscAlumnosInscripciones
            // 
            // 
            // tscAlumnosInscripciones.ContentPanel
            // 
            this.tscAlumnosInscripciones.ContentPanel.Controls.Add(this.tlAlumnosInscripciones);
            this.tscAlumnosInscripciones.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscAlumnosInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tscAlumnosInscripciones.Name = "tscAlumnosInscripciones";
            this.tscAlumnosInscripciones.Size = new System.Drawing.Size(800, 450);
            this.tscAlumnosInscripciones.TabIndex = 0;
            this.tscAlumnosInscripciones.Text = "toolStripContainer1";
            // 
            // tscAlumnosInscripciones.TopToolStripPanel
            // 
            this.tscAlumnosInscripciones.TopToolStripPanel.Controls.Add(this.tsAlumnosInscripciones);
            // 
            // tlAlumnosInscripciones
            // 
            this.tlAlumnosInscripciones.ColumnCount = 2;
            this.tlAlumnosInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnosInscripciones.Controls.Add(this.dgvAlumnosInscripciones, 0, 0);
            this.tlAlumnosInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlAlumnosInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnosInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnosInscripciones.Name = "tlAlumnosInscripciones";
            this.tlAlumnosInscripciones.RowCount = 2;
            this.tlAlumnosInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnosInscripciones.Size = new System.Drawing.Size(800, 425);
            this.tlAlumnosInscripciones.TabIndex = 0;
            // 
            // dgvAlumnosInscripciones
            // 
            this.dgvAlumnosInscripciones.AllowUserToAddRows = false;
            this.dgvAlumnosInscripciones.AllowUserToDeleteRows = false;
            this.dgvAlumnosInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlAlumnosInscripciones.SetColumnSpan(this.dgvAlumnosInscripciones, 2);
            this.dgvAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnosInscripciones.MultiSelect = false;
            this.dgvAlumnosInscripciones.Name = "dgvAlumnosInscripciones";
            this.dgvAlumnosInscripciones.ReadOnly = true;
            this.dgvAlumnosInscripciones.RowHeadersWidth = 62;
            this.dgvAlumnosInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnosInscripciones.Size = new System.Drawing.Size(794, 390);
            this.dgvAlumnosInscripciones.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tsAlumnosInscripciones
            // 
            this.tsAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAlumnosInscripciones.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsAlumnosInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsAlumnosInscripciones.Location = new System.Drawing.Point(4, 0);
            this.tsAlumnosInscripciones.Name = "tsAlumnosInscripciones";
            this.tsAlumnosInscripciones.Size = new System.Drawing.Size(81, 25);
            this.tsAlumnosInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.plus;
            this.tsbNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.pencil;
            this.tsbEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.cancel;
            this.tsbEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // AlumnosInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscAlumnosInscripciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlumnosInscripciones";
            this.Text = "Inscripciones de Alumno";
            this.Load += new System.EventHandler(this.AlumnosInscripciones_Load);
            this.Shown += new System.EventHandler(this.AlumnosInscripciones_Shown);
            this.tscAlumnosInscripciones.ContentPanel.ResumeLayout(false);
            this.tscAlumnosInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tscAlumnosInscripciones.TopToolStripPanel.PerformLayout();
            this.tscAlumnosInscripciones.ResumeLayout(false);
            this.tscAlumnosInscripciones.PerformLayout();
            this.tlAlumnosInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).EndInit();
            this.tsAlumnosInscripciones.ResumeLayout(false);
            this.tsAlumnosInscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscAlumnosInscripciones;
        private System.Windows.Forms.ToolStrip tsAlumnosInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlAlumnosInscripciones;
        private System.Windows.Forms.DataGridView dgvAlumnosInscripciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}

