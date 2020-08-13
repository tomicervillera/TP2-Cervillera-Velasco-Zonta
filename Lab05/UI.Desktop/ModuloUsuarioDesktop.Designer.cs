namespace UI.Desktop
{
    partial class ModuloUsuarioDesktop
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbModulo = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.cboxUsuario = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxBaja = new System.Windows.Forms.CheckBox();
            this.checkBoxAlta = new System.Windows.Forms.CheckBox();
            this.checkBoxModificacion = new System.Windows.Forms.CheckBox();
            this.checkBoxConsulta = new System.Windows.Forms.CheckBox();
            this.cboxModulo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.cboxModulo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxConsulta, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxModificacion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAlta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxBaja, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbModulo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxUsuario, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 104);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbNombre
            // 
            this.lbNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(57, 10);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(18, 13);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(139, 7);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(188, 20);
            this.txtID.TabIndex = 5;
            // 
            // lbModulo
            // 
            this.lbModulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbModulo.AutoSize = true;
            this.lbModulo.Location = new System.Drawing.Point(378, 10);
            this.lbModulo.Name = "lbModulo";
            this.lbModulo.Size = new System.Drawing.Size(42, 13);
            this.lbModulo.TabIndex = 8;
            this.lbModulo.Text = "Módulo";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(45, 44);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 18;
            this.lbUsuario.Text = "Usuario";
            // 
            // cboxUsuario
            // 
            this.cboxUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxUsuario.FormattingEnabled = true;
            this.cboxUsuario.Location = new System.Drawing.Point(139, 40);
            this.cboxUsuario.Name = "cboxUsuario";
            this.cboxUsuario.Size = new System.Drawing.Size(188, 21);
            this.cboxUsuario.TabIndex = 19;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(11, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 20);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(110, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 20);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(469, 71);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(197, 30);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // checkBoxBaja
            // 
            this.checkBoxBaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxBaja.AutoSize = true;
            this.checkBoxBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxBaja.Location = new System.Drawing.Point(544, 42);
            this.checkBoxBaja.Name = "checkBoxBaja";
            this.checkBoxBaja.Size = new System.Drawing.Size(47, 17);
            this.checkBoxBaja.TabIndex = 24;
            this.checkBoxBaja.Text = "Baja";
            this.checkBoxBaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBaja.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlta
            // 
            this.checkBoxAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxAlta.AutoSize = true;
            this.checkBoxAlta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAlta.Location = new System.Drawing.Point(377, 42);
            this.checkBoxAlta.Name = "checkBoxAlta";
            this.checkBoxAlta.Size = new System.Drawing.Size(44, 17);
            this.checkBoxAlta.TabIndex = 25;
            this.checkBoxAlta.Text = "Alta";
            this.checkBoxAlta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAlta.UseVisualStyleBackColor = true;
            // 
            // checkBoxModificacion
            // 
            this.checkBoxModificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxModificacion.AutoSize = true;
            this.checkBoxModificacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxModificacion.Location = new System.Drawing.Point(23, 77);
            this.checkBoxModificacion.Name = "checkBoxModificacion";
            this.checkBoxModificacion.Size = new System.Drawing.Size(86, 17);
            this.checkBoxModificacion.TabIndex = 27;
            this.checkBoxModificacion.Text = "Modificacion";
            this.checkBoxModificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxModificacion.UseVisualStyleBackColor = true;
            // 
            // checkBoxConsulta
            // 
            this.checkBoxConsulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxConsulta.AutoSize = true;
            this.checkBoxConsulta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxConsulta.Location = new System.Drawing.Point(199, 77);
            this.checkBoxConsulta.Name = "checkBoxConsulta";
            this.checkBoxConsulta.Size = new System.Drawing.Size(67, 17);
            this.checkBoxConsulta.TabIndex = 28;
            this.checkBoxConsulta.Text = "Consulta";
            this.checkBoxConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxConsulta.UseVisualStyleBackColor = true;
            // 
            // cboxModulo
            // 
            this.cboxModulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxModulo.FormattingEnabled = true;
            this.cboxModulo.Location = new System.Drawing.Point(473, 6);
            this.cboxModulo.Name = "cboxModulo";
            this.cboxModulo.Size = new System.Drawing.Size(188, 21);
            this.cboxModulo.TabIndex = 29;
            // 
            // ModuloUsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 128);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModuloUsuarioDesktop";
            this.Text = "ModuloUsuario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbModulo;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.ComboBox cboxUsuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox checkBoxConsulta;
        private System.Windows.Forms.CheckBox checkBoxModificacion;
        private System.Windows.Forms.CheckBox checkBoxAlta;
        private System.Windows.Forms.CheckBox checkBoxBaja;
        private System.Windows.Forms.ComboBox cboxModulo;
    }
}