namespace UI.Desktop
{
    partial class ModulosUsuarios
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
            this.tscModulosUsuarios = new System.Windows.Forms.ToolStripContainer();
            this.tlModulosUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsModulosUsuarios = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscModulosUsuarios.ContentPanel.SuspendLayout();
            this.tscModulosUsuarios.TopToolStripPanel.SuspendLayout();
            this.tscModulosUsuarios.SuspendLayout();
            this.tlModulosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsModulosUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscModulosUsuarios
            // 
            // 
            // tscModulosUsuarios.ContentPanel
            // 
            this.tscModulosUsuarios.ContentPanel.Controls.Add(this.tlModulosUsuarios);
            this.tscModulosUsuarios.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tscModulosUsuarios.Name = "tscModulosUsuarios";
            this.tscModulosUsuarios.Size = new System.Drawing.Size(800, 450);
            this.tscModulosUsuarios.TabIndex = 0;
            this.tscModulosUsuarios.Text = "toolStripContainer1";
            // 
            // tscModulosUsuarios.TopToolStripPanel
            // 
            this.tscModulosUsuarios.TopToolStripPanel.Controls.Add(this.tsModulosUsuarios);
            // 
            // tlModulosUsuarios
            // 
            this.tlModulosUsuarios.ColumnCount = 2;
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModulosUsuarios.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlModulosUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlModulosUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlModulosUsuarios.Name = "tlModulosUsuarios";
            this.tlModulosUsuarios.RowCount = 2;
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModulosUsuarios.Size = new System.Drawing.Size(800, 425);
            this.tlModulosUsuarios.TabIndex = 0;
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlModulosUsuarios.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.MultiSelect = false;
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.RowHeadersWidth = 62;
            this.dgvModulosUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(794, 390);
            this.dgvModulosUsuarios.TabIndex = 0;
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
            // tsModulosUsuarios
            // 
            this.tsModulosUsuarios.Dock = System.Windows.Forms.DockStyle.None;
            this.tsModulosUsuarios.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsModulosUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsModulosUsuarios.Location = new System.Drawing.Point(4, 0);
            this.tsModulosUsuarios.Name = "tsModulosUsuarios";
            this.tsModulosUsuarios.Size = new System.Drawing.Size(81, 25);
            this.tsModulosUsuarios.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.tsbEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscModulosUsuarios);
            this.Name = "ModulosUsuarios";
            this.Text = "ModulosUsuarios";
            this.Load += new System.EventHandler(this.ModulosUsuarios_Load);
            this.tscModulosUsuarios.ContentPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.PerformLayout();
            this.tscModulosUsuarios.ResumeLayout(false);
            this.tscModulosUsuarios.PerformLayout();
            this.tlModulosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsModulosUsuarios.ResumeLayout(false);
            this.tsModulosUsuarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscModulosUsuarios;
        private System.Windows.Forms.ToolStrip tsModulosUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlModulosUsuarios;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}

