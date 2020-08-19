namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbAnioEspecialidad = new System.Windows.Forms.Label();
            this.txtAñoEspecialidad = new System.Windows.Forms.TextBox();
            this.lbIDPlan = new System.Windows.Forms.Label();
            this.cmbIDPlan = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.16374F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.83626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDescripcion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAnioEspecialidad, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAñoEspecialidad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbIDPlan, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbIDPlan, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.71901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.28099F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(37, 17);
            this.lbID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(97, 14);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(188, 20);
            this.txtID.TabIndex = 1;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(302, 17);
            this.lbDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 2;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(385, 14);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(188, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lbAnioEspecialidad
            // 
            this.lbAnioEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbAnioEspecialidad.AutoSize = true;
            this.lbAnioEspecialidad.Location = new System.Drawing.Point(2, 62);
            this.lbAnioEspecialidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAnioEspecialidad.Name = "lbAnioEspecialidad";
            this.lbAnioEspecialidad.Size = new System.Drawing.Size(89, 13);
            this.lbAnioEspecialidad.TabIndex = 4;
            this.lbAnioEspecialidad.Text = "Año Especialidad";
            // 
            // txtAñoEspecialidad
            // 
            this.txtAñoEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAñoEspecialidad.Location = new System.Drawing.Point(95, 59);
            this.txtAñoEspecialidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAñoEspecialidad.Name = "txtAñoEspecialidad";
            this.txtAñoEspecialidad.Size = new System.Drawing.Size(192, 20);
            this.txtAñoEspecialidad.TabIndex = 5;
            // 
            // lbIDPlan
            // 
            this.lbIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIDPlan.AutoSize = true;
            this.lbIDPlan.Location = new System.Drawing.Point(319, 62);
            this.lbIDPlan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIDPlan.Name = "lbIDPlan";
            this.lbIDPlan.Size = new System.Drawing.Size(28, 13);
            this.lbIDPlan.TabIndex = 7;
            this.lbIDPlan.Text = "Plan";
            // 
            // cmbIDPlan
            // 
            this.cmbIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDPlan.FormattingEnabled = true;
            this.cmbIDPlan.Location = new System.Drawing.Point(386, 58);
            this.cmbIDPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbIDPlan.Name = "cmbIDPlan";
            this.cmbIDPlan.Size = new System.Drawing.Size(186, 21);
            this.cmbIDPlan.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(379, 92);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(196, 39);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(21, 10);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(56, 19);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(119, 10);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 19);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 162);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ComisionDesktop";
            this.Text = "Comision";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lbAnioEspecialidad;
        private System.Windows.Forms.TextBox txtAñoEspecialidad;
        private System.Windows.Forms.Label lbIDPlan;
        private System.Windows.Forms.ComboBox cmbIDPlan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}