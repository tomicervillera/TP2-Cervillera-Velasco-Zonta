namespace UI.Desktop
{
    partial class DocenteCursoDesktop
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
            this.cboxCurso = new System.Windows.Forms.ComboBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbCurso = new System.Windows.Forms.Label();
            this.lbDocente = new System.Windows.Forms.Label();
            this.cboxDocente = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cboxCargo = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.cboxCurso, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbCurso, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDocente, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxDocente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCargo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxCargo, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 87);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cboxCurso
            // 
            this.cboxCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCurso.FormattingEnabled = true;
            this.cboxCurso.Location = new System.Drawing.Point(507, 3);
            this.cboxCurso.Name = "cboxCurso";
            this.cboxCurso.Size = new System.Drawing.Size(188, 21);
            this.cboxCurso.TabIndex = 29;
            // 
            // lbNombre
            // 
            this.lbNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(61, 6);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(18, 13);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(153, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(188, 20);
            this.txtID.TabIndex = 5;
            // 
            // lbCurso
            // 
            this.lbCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCurso.AutoSize = true;
            this.lbCurso.Location = new System.Drawing.Point(406, 6);
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(34, 13);
            this.lbCurso.TabIndex = 8;
            this.lbCurso.Text = "Curso";
            // 
            // lbDocente
            // 
            this.lbDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDocente.AutoSize = true;
            this.lbDocente.Location = new System.Drawing.Point(29, 32);
            this.lbDocente.Name = "lbDocente";
            this.lbDocente.Size = new System.Drawing.Size(83, 13);
            this.lbDocente.TabIndex = 18;
            this.lbDocente.Text = "Legajo Docente";
            // 
            // cboxDocente
            // 
            this.cboxDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDocente.FormattingEnabled = true;
            this.cboxDocente.Location = new System.Drawing.Point(153, 29);
            this.cboxDocente.Name = "cboxDocente";
            this.cboxDocente.Size = new System.Drawing.Size(188, 21);
            this.cboxDocente.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(497, 55);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 29);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(118, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 20);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(14, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 20);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblCargo
            // 
            this.lblCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(406, 32);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(35, 13);
            this.lblCargo.TabIndex = 30;
            this.lblCargo.Text = "Cargo";
            // 
            // cboxCargo
            // 
            this.cboxCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCargo.FormattingEnabled = true;
            this.cboxCargo.Location = new System.Drawing.Point(507, 29);
            this.cboxCargo.Name = "cboxCargo";
            this.cboxCargo.Size = new System.Drawing.Size(188, 21);
            this.cboxCargo.TabIndex = 31;
            // 
            // DocenteCursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 111);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DocenteCursoDesktop";
            this.Text = "DocenteCurso";
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
        private System.Windows.Forms.Label lbCurso;
        private System.Windows.Forms.Label lbDocente;
        private System.Windows.Forms.ComboBox cboxDocente;
        private System.Windows.Forms.ComboBox cboxCurso;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboxCargo;
    }
}