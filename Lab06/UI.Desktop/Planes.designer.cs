﻿namespace UI.Desktop
{
    partial class Planes
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
            this.tscPlanes = new System.Windows.Forms.ToolStripContainer();
            this.tlPlanes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsPlanes = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscPlanes.ContentPanel.SuspendLayout();
            this.tscPlanes.TopToolStripPanel.SuspendLayout();
            this.tscPlanes.SuspendLayout();
            this.tlPlanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.tsPlanes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscPlanes
            // 
            // 
            // tscPlanes.ContentPanel
            // 
            this.tscPlanes.ContentPanel.Controls.Add(this.tlPlanes);
            this.tscPlanes.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tscPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscPlanes.Location = new System.Drawing.Point(0, 0);
            this.tscPlanes.Name = "tscPlanes";
            this.tscPlanes.Size = new System.Drawing.Size(800, 450);
            this.tscPlanes.TabIndex = 0;
            this.tscPlanes.Text = "toolStripContainer1";
            // 
            // tscPlanes.TopToolStripPanel
            // 
            this.tscPlanes.TopToolStripPanel.Controls.Add(this.tsPlanes);
            // 
            // tlPlanes
            // 
            this.tlPlanes.ColumnCount = 2;
            this.tlPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanes.Controls.Add(this.dgvPlanes, 0, 0);
            this.tlPlanes.Controls.Add(this.btnSalir, 1, 1);
            this.tlPlanes.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPlanes.Location = new System.Drawing.Point(0, 0);
            this.tlPlanes.Name = "tlPlanes";
            this.tlPlanes.RowCount = 2;
            this.tlPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanes.Size = new System.Drawing.Size(800, 425);
            this.tlPlanes.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlPlanes.SetColumnSpan(this.dgvPlanes, 2);
            this.dgvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanes.Location = new System.Drawing.Point(3, 3);
            this.dgvPlanes.MultiSelect = false;
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.RowHeadersWidth = 62;
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(794, 390);
            this.dgvPlanes.TabIndex = 0;
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
            // tsPlanes
            // 
            this.tsPlanes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPlanes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPlanes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsPlanes.Location = new System.Drawing.Point(4, 0);
            this.tsPlanes.Name = "tsPlanes";
            this.tsPlanes.Size = new System.Drawing.Size(112, 25);
            this.tsPlanes.TabIndex = 0;
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
            // Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscPlanes);
            this.Name = "Planes";
            this.Text = "Planes";
            this.Load += new System.EventHandler(this.Planes_Load);
            this.tscPlanes.ContentPanel.ResumeLayout(false);
            this.tscPlanes.TopToolStripPanel.ResumeLayout(false);
            this.tscPlanes.TopToolStripPanel.PerformLayout();
            this.tscPlanes.ResumeLayout(false);
            this.tscPlanes.PerformLayout();
            this.tlPlanes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.tsPlanes.ResumeLayout(false);
            this.tsPlanes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscPlanes;
        private System.Windows.Forms.ToolStrip tsPlanes;
        private System.Windows.Forms.TableLayoutPanel tlPlanes;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}

