﻿namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbID = new System.Windows.Forms.Label();
            this.lbHSSemanales = new System.Windows.Forms.Label();
            this.lbHSTotales = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtHSSemanales = new System.Windows.Forms.TextBox();
            this.txtHSTotales = new System.Windows.Forms.TextBox();
            this.lbIDPlan = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cboxIDPlan = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.errorProviderMateria = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMateria)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.4571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.55991F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42307F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.55991F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbHSSemanales, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbHSTotales, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDescripcion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHSSemanales, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHSTotales, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbIDPlan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxIDPlan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(49, 10);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // lbHSSemanales
            // 
            this.lbHSSemanales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbHSSemanales.AutoSize = true;
            this.lbHSSemanales.Location = new System.Drawing.Point(367, 10);
            this.lbHSSemanales.Name = "lbHSSemanales";
            this.lbHSSemanales.Size = new System.Drawing.Size(90, 13);
            this.lbHSSemanales.TabIndex = 1;
            this.lbHSSemanales.Text = "Horas Semanales";
            // 
            // lbHSTotales
            // 
            this.lbHSTotales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbHSTotales.AutoSize = true;
            this.lbHSTotales.Location = new System.Drawing.Point(24, 44);
            this.lbHSTotales.Name = "lbHSTotales";
            this.lbHSTotales.Size = new System.Drawing.Size(68, 13);
            this.lbHSTotales.TabIndex = 2;
            this.lbHSTotales.Text = "Hora Totales";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(380, 44);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 3;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Location = new System.Drawing.Point(131, 7);
            this.txtID.Margin = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(215, 20);
            this.txtID.TabIndex = 4;
            // 
            // txtHSSemanales
            // 
            this.txtHSSemanales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHSSemanales.Location = new System.Drawing.Point(478, 7);
            this.txtHSSemanales.Margin = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.txtHSSemanales.Name = "txtHSSemanales";
            this.txtHSSemanales.Size = new System.Drawing.Size(217, 20);
            this.txtHSSemanales.TabIndex = 5;
            this.txtHSSemanales.Validating += new System.ComponentModel.CancelEventHandler(this.txtHSSemanales_Validating);
            // 
            // txtHSTotales
            // 
            this.txtHSTotales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHSTotales.Location = new System.Drawing.Point(131, 41);
            this.txtHSTotales.Margin = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.txtHSTotales.Name = "txtHSTotales";
            this.txtHSTotales.Size = new System.Drawing.Size(215, 20);
            this.txtHSTotales.TabIndex = 6;
            this.txtHSTotales.Validating += new System.ComponentModel.CancelEventHandler(this.txtHSTotales_Validating);
            // 
            // lbIDPlan
            // 
            this.lbIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIDPlan.AutoSize = true;
            this.lbIDPlan.Location = new System.Drawing.Point(44, 78);
            this.lbIDPlan.Name = "lbIDPlan";
            this.lbIDPlan.Size = new System.Drawing.Size(28, 13);
            this.lbIDPlan.TabIndex = 9;
            this.lbIDPlan.Text = "Plan";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(478, 41);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(217, 20);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // cboxIDPlan
            // 
            this.cboxIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxIDPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIDPlan.FormattingEnabled = true;
            this.cboxIDPlan.Location = new System.Drawing.Point(131, 74);
            this.cboxIDPlan.Margin = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.cboxIDPlan.Name = "cboxIDPlan";
            this.cboxIDPlan.Size = new System.Drawing.Size(215, 21);
            this.cboxIDPlan.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btAceptar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btCancelar, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(504, 105);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(164, 29);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAceptar.Location = new System.Drawing.Point(3, 3);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCancelar.Location = new System.Drawing.Point(85, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // errorProviderMateria
            // 
            this.errorProviderMateria.ContainerControl = this;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(734, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "Materia";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMateria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbHSSemanales;
        private System.Windows.Forms.Label lbHSTotales;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtHSTotales;
        private System.Windows.Forms.ComboBox cboxIDPlan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbIDPlan;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHSSemanales;
        private System.Windows.Forms.ErrorProvider errorProviderMateria;
    }
}