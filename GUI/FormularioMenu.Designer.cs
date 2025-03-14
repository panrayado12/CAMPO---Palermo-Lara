namespace GUI
{
    partial class FormularioMenu
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
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnAdministrarUsuarios = new System.Windows.Forms.Button();
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnCambiarIdioma = new System.Windows.Forms.Button();
            this.comboBoxIdiomas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(663, 314);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(275, 47);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnAdministrarUsuarios
            // 
            this.btnAdministrarUsuarios.Location = new System.Drawing.Point(663, 385);
            this.btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            this.btnAdministrarUsuarios.Size = new System.Drawing.Size(275, 47);
            this.btnAdministrarUsuarios.TabIndex = 1;
            this.btnAdministrarUsuarios.Text = "Administrar usuarios";
            this.btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            this.btnAdministrarUsuarios.Click += new System.EventHandler(this.btnAñadirUsuario_Click);
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.Location = new System.Drawing.Point(663, 458);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(275, 47);
            this.btnCambiarContraseña.TabIndex = 2;
            this.btnCambiarContraseña.Text = "Cambiar contraseña";
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(964, 385);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(275, 47);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(964, 314);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(275, 47);
            this.btnBackUp.TabIndex = 4;
            this.btnBackUp.Text = "Back up";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.Location = new System.Drawing.Point(964, 458);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(275, 47);
            this.btnBitacora.TabIndex = 5;
            this.btnBitacora.Text = "Bitacora";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnCambiarIdioma
            // 
            this.btnCambiarIdioma.Location = new System.Drawing.Point(964, 524);
            this.btnCambiarIdioma.Name = "btnCambiarIdioma";
            this.btnCambiarIdioma.Size = new System.Drawing.Size(275, 47);
            this.btnCambiarIdioma.TabIndex = 6;
            this.btnCambiarIdioma.Text = "Cambiar idioma ";
            this.btnCambiarIdioma.UseVisualStyleBackColor = true;
            this.btnCambiarIdioma.Click += new System.EventHandler(this.btnCambiarIdioma_Click);
            // 
            // comboBoxIdiomas
            // 
            this.comboBoxIdiomas.FormattingEnabled = true;
            this.comboBoxIdiomas.Items.AddRange(new object[] {
            "en",
            "es"});
            this.comboBoxIdiomas.Location = new System.Drawing.Point(965, 588);
            this.comboBoxIdiomas.Name = "comboBoxIdiomas";
            this.comboBoxIdiomas.Size = new System.Drawing.Size(274, 33);
            this.comboBoxIdiomas.TabIndex = 7;
            // 
            // FormularioMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 905);
            this.Controls.Add(this.comboBoxIdiomas);
            this.Controls.Add(this.btnCambiarIdioma);
            this.Controls.Add(this.btnBitacora);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnCambiarContraseña);
            this.Controls.Add(this.btnAdministrarUsuarios);
            this.Controls.Add(this.btnCerrarSesion);
            this.Name = "FormularioMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormularioMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAdministrarUsuarios;
        private System.Windows.Forms.Button btnCambiarContraseña;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnCambiarIdioma;
        private System.Windows.Forms.ComboBox comboBoxIdiomas;
    }
}