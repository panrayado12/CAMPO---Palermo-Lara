namespace GUI
{
    partial class FormularioBitacoraEventos941lp
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
            this.dataBitacora = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.labelEstadoBitacora = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxFechaConsulta = new System.Windows.Forms.CheckBox();
            this.labelDescripcionBitacora = new System.Windows.Forms.Label();
            this.labelModuloBitacora = new System.Windows.Forms.Label();
            this.comboboxUsuario = new System.Windows.Forms.ComboBox();
            this.comboBoxDescripcion = new System.Windows.Forms.ComboBox();
            this.comboboxModulo = new System.Windows.Forms.ComboBox();
            this.btnQuitarFiltros = new System.Windows.Forms.Button();
            this.comboBoxCriticidad = new System.Windows.Forms.ComboBox();
            this.labelCrititcidadBitacora = new System.Windows.Forms.Label();
            this.labelUsuarioBitacora2 = new System.Windows.Forms.Label();
            this.labelUsuarioBitacora1 = new System.Windows.Forms.Label();
            this.labelApellidoBitacora = new System.Windows.Forms.Label();
            this.labelNombreBitacora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBitacora
            // 
            this.dataBitacora.AllowUserToAddRows = false;
            this.dataBitacora.AllowUserToDeleteRows = false;
            this.dataBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataBitacora.Location = new System.Drawing.Point(48, 26);
            this.dataBitacora.Name = "dataBitacora";
            this.dataBitacora.ReadOnly = true;
            this.dataBitacora.RowHeadersWidth = 82;
            this.dataBitacora.RowTemplate.Height = 33;
            this.dataBitacora.Size = new System.Drawing.Size(1738, 387);
            this.dataBitacora.TabIndex = 0;
            this.dataBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBitacora_CellClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Código";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Usuario";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hora";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Modulo";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Descripción";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Criticidad";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(48, 818);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(275, 47);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(48, 433);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 260);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(477, 544);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(359, 40);
            this.txtUsuario.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(477, 653);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(359, 40);
            this.txtApellido.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(477, 602);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(359, 40);
            this.txtNombre.TabIndex = 7;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(477, 488);
            this.txtEstado.Multiline = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(359, 40);
            this.txtEstado.TabIndex = 8;
            // 
            // labelEstadoBitacora
            // 
            this.labelEstadoBitacora.AutoSize = true;
            this.labelEstadoBitacora.Location = new System.Drawing.Point(336, 488);
            this.labelEstadoBitacora.Name = "labelEstadoBitacora";
            this.labelEstadoBitacora.Size = new System.Drawing.Size(98, 25);
            this.labelEstadoBitacora.TabIndex = 11;
            this.labelEstadoBitacora.Text = "ESTADO";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(990, 668);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(519, 31);
            this.dateTimePickerDesde.TabIndex = 15;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(990, 729);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(519, 31);
            this.dateTimePickerHasta.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 769);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 31);
            this.label6.TabIndex = 17;
            this.label6.Text = "¿Aplicar fecha?:";
            // 
            // checkBoxFechaConsulta
            // 
            this.checkBoxFechaConsulta.AutoSize = true;
            this.checkBoxFechaConsulta.Location = new System.Drawing.Point(286, 769);
            this.checkBoxFechaConsulta.Name = "checkBoxFechaConsulta";
            this.checkBoxFechaConsulta.Size = new System.Drawing.Size(28, 27);
            this.checkBoxFechaConsulta.TabIndex = 18;
            this.checkBoxFechaConsulta.UseVisualStyleBackColor = true;
            this.checkBoxFechaConsulta.CheckedChanged += new System.EventHandler(this.checkBoxFechaConsulta_CheckedChanged);
            // 
            // labelDescripcionBitacora
            // 
            this.labelDescripcionBitacora.AutoSize = true;
            this.labelDescripcionBitacora.Location = new System.Drawing.Point(985, 559);
            this.labelDescripcionBitacora.Name = "labelDescripcionBitacora";
            this.labelDescripcionBitacora.Size = new System.Drawing.Size(155, 25);
            this.labelDescripcionBitacora.TabIndex = 20;
            this.labelDescripcionBitacora.Text = "DESCRIPCIÓN";
            // 
            // labelModuloBitacora
            // 
            this.labelModuloBitacora.AutoSize = true;
            this.labelModuloBitacora.Location = new System.Drawing.Point(985, 498);
            this.labelModuloBitacora.Name = "labelModuloBitacora";
            this.labelModuloBitacora.Size = new System.Drawing.Size(104, 25);
            this.labelModuloBitacora.TabIndex = 21;
            this.labelModuloBitacora.Text = "MODULO";
            // 
            // comboboxUsuario
            // 
            this.comboboxUsuario.FormattingEnabled = true;
            this.comboboxUsuario.Location = new System.Drawing.Point(1184, 430);
            this.comboboxUsuario.Name = "comboboxUsuario";
            this.comboboxUsuario.Size = new System.Drawing.Size(325, 33);
            this.comboboxUsuario.TabIndex = 22;
            this.comboboxUsuario.SelectedValueChanged += new System.EventHandler(this.comboboxUsuario_SelectedValueChanged);
            // 
            // comboBoxDescripcion
            // 
            this.comboBoxDescripcion.FormattingEnabled = true;
            this.comboBoxDescripcion.Location = new System.Drawing.Point(1184, 556);
            this.comboBoxDescripcion.Name = "comboBoxDescripcion";
            this.comboBoxDescripcion.Size = new System.Drawing.Size(325, 33);
            this.comboBoxDescripcion.TabIndex = 23;
            this.comboBoxDescripcion.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescripcion_SelectedIndexChanged);
            // 
            // comboboxModulo
            // 
            this.comboboxModulo.FormattingEnabled = true;
            this.comboboxModulo.Location = new System.Drawing.Point(1184, 495);
            this.comboboxModulo.Name = "comboboxModulo";
            this.comboboxModulo.Size = new System.Drawing.Size(325, 33);
            this.comboboxModulo.TabIndex = 24;
            this.comboboxModulo.SelectedIndexChanged += new System.EventHandler(this.comboboxModulo_SelectedIndexChanged);
            // 
            // btnQuitarFiltros
            // 
            this.btnQuitarFiltros.Location = new System.Drawing.Point(361, 818);
            this.btnQuitarFiltros.Name = "btnQuitarFiltros";
            this.btnQuitarFiltros.Size = new System.Drawing.Size(275, 47);
            this.btnQuitarFiltros.TabIndex = 26;
            this.btnQuitarFiltros.Text = "Quitar filtros";
            this.btnQuitarFiltros.UseVisualStyleBackColor = true;
            this.btnQuitarFiltros.Click += new System.EventHandler(this.btnQuitarFiltros_Click);
            // 
            // comboBoxCriticidad
            // 
            this.comboBoxCriticidad.FormattingEnabled = true;
            this.comboBoxCriticidad.Location = new System.Drawing.Point(1184, 614);
            this.comboBoxCriticidad.Name = "comboBoxCriticidad";
            this.comboBoxCriticidad.Size = new System.Drawing.Size(325, 33);
            this.comboBoxCriticidad.TabIndex = 28;
            this.comboBoxCriticidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxCriticidad_SelectedIndexChanged);
            // 
            // labelCrititcidadBitacora
            // 
            this.labelCrititcidadBitacora.AutoSize = true;
            this.labelCrititcidadBitacora.Location = new System.Drawing.Point(985, 617);
            this.labelCrititcidadBitacora.Name = "labelCrititcidadBitacora";
            this.labelCrititcidadBitacora.Size = new System.Drawing.Size(129, 25);
            this.labelCrititcidadBitacora.TabIndex = 27;
            this.labelCrititcidadBitacora.Text = "CRITICIDAD";
            // 
            // labelUsuarioBitacora2
            // 
            this.labelUsuarioBitacora2.AutoSize = true;
            this.labelUsuarioBitacora2.Location = new System.Drawing.Point(985, 433);
            this.labelUsuarioBitacora2.Name = "labelUsuarioBitacora2";
            this.labelUsuarioBitacora2.Size = new System.Drawing.Size(106, 25);
            this.labelUsuarioBitacora2.TabIndex = 19;
            this.labelUsuarioBitacora2.Text = "USUARIO";
            // 
            // labelUsuarioBitacora1
            // 
            this.labelUsuarioBitacora1.AutoSize = true;
            this.labelUsuarioBitacora1.Location = new System.Drawing.Point(336, 544);
            this.labelUsuarioBitacora1.Name = "labelUsuarioBitacora1";
            this.labelUsuarioBitacora1.Size = new System.Drawing.Size(106, 25);
            this.labelUsuarioBitacora1.TabIndex = 10;
            this.labelUsuarioBitacora1.Text = "USUARIO";
            // 
            // labelApellidoBitacora
            // 
            this.labelApellidoBitacora.AutoSize = true;
            this.labelApellidoBitacora.Location = new System.Drawing.Point(336, 668);
            this.labelApellidoBitacora.Name = "labelApellidoBitacora";
            this.labelApellidoBitacora.Size = new System.Drawing.Size(114, 25);
            this.labelApellidoBitacora.TabIndex = 13;
            this.labelApellidoBitacora.Text = "APELLIDO";
            // 
            // labelNombreBitacora
            // 
            this.labelNombreBitacora.AutoSize = true;
            this.labelNombreBitacora.Location = new System.Drawing.Point(336, 605);
            this.labelNombreBitacora.Name = "labelNombreBitacora";
            this.labelNombreBitacora.Size = new System.Drawing.Size(104, 25);
            this.labelNombreBitacora.TabIndex = 14;
            this.labelNombreBitacora.Text = "NOMBRE";
            // 
            // FormularioBitacoraEventos941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1897, 877);
            this.Controls.Add(this.comboBoxCriticidad);
            this.Controls.Add(this.labelCrititcidadBitacora);
            this.Controls.Add(this.btnQuitarFiltros);
            this.Controls.Add(this.comboboxModulo);
            this.Controls.Add(this.comboBoxDescripcion);
            this.Controls.Add(this.comboboxUsuario);
            this.Controls.Add(this.labelModuloBitacora);
            this.Controls.Add(this.labelDescripcionBitacora);
            this.Controls.Add(this.labelUsuarioBitacora2);
            this.Controls.Add(this.checkBoxFechaConsulta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerHasta);
            this.Controls.Add(this.dateTimePickerDesde);
            this.Controls.Add(this.labelNombreBitacora);
            this.Controls.Add(this.labelApellidoBitacora);
            this.Controls.Add(this.labelEstadoBitacora);
            this.Controls.Add(this.labelUsuarioBitacora1);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataBitacora);
            this.Name = "FormularioBitacoraEventos941lp";
            this.Text = "FormularioBitacoraEventos";
            this.Load += new System.EventHandler(this.FormularioBitacoraEventos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataBitacora;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label labelEstadoBitacora;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxFechaConsulta;
        private System.Windows.Forms.Label labelDescripcionBitacora;
        private System.Windows.Forms.Label labelModuloBitacora;
        private System.Windows.Forms.ComboBox comboboxUsuario;
        private System.Windows.Forms.ComboBox comboBoxDescripcion;
        private System.Windows.Forms.ComboBox comboboxModulo;
        private System.Windows.Forms.Button btnQuitarFiltros;
        private System.Windows.Forms.ComboBox comboBoxCriticidad;
        private System.Windows.Forms.Label labelCrititcidadBitacora;
        private System.Windows.Forms.Label labelUsuarioBitacora2;
        private System.Windows.Forms.Label labelUsuarioBitacora1;
        private System.Windows.Forms.Label labelApellidoBitacora;
        private System.Windows.Forms.Label labelNombreBitacora;
    }
}