namespace GUI
{
    partial class FormularioPermisos
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
            this.checkedListBoxRoles = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxPermisos = new System.Windows.Forms.CheckedListBox();
            this.txtPermisosRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnCrearConjuntoDePermisos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxRoles
            // 
            this.checkedListBoxRoles.FormattingEnabled = true;
            this.checkedListBoxRoles.Items.AddRange(new object[] {
            "jajaj",
            "jajaj",
            "ajjaj",
            "ajaj"});
            this.checkedListBoxRoles.Location = new System.Drawing.Point(1114, 131);
            this.checkedListBoxRoles.Name = "checkedListBoxRoles";
            this.checkedListBoxRoles.Size = new System.Drawing.Size(377, 368);
            this.checkedListBoxRoles.TabIndex = 1;
            // 
            // checkedListBoxPermisos
            // 
            this.checkedListBoxPermisos.FormattingEnabled = true;
            this.checkedListBoxPermisos.Items.AddRange(new object[] {
            "jajaj",
            "jajaj",
            "ajjaj",
            "ajaj"});
            this.checkedListBoxPermisos.Location = new System.Drawing.Point(651, 131);
            this.checkedListBoxPermisos.Name = "checkedListBoxPermisos";
            this.checkedListBoxPermisos.Size = new System.Drawing.Size(377, 368);
            this.checkedListBoxPermisos.TabIndex = 2;
            // 
            // txtPermisosRol
            // 
            this.txtPermisosRol.Location = new System.Drawing.Point(70, 344);
            this.txtPermisosRol.Name = "txtPermisosRol";
            this.txtPermisosRol.Size = new System.Drawing.Size(400, 31);
            this.txtPermisosRol.TabIndex = 3;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(70, 438);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(320, 85);
            this.btnCrearRol.TabIndex = 4;
            this.btnCrearRol.Tag = "Crear roles";
            this.btnCrearRol.Text = "Crear rol";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            // 
            // btnCrearConjuntoDePermisos
            // 
            this.btnCrearConjuntoDePermisos.Location = new System.Drawing.Point(70, 546);
            this.btnCrearConjuntoDePermisos.Name = "btnCrearConjuntoDePermisos";
            this.btnCrearConjuntoDePermisos.Size = new System.Drawing.Size(320, 85);
            this.btnCrearConjuntoDePermisos.TabIndex = 5;
            this.btnCrearConjuntoDePermisos.Tag = "Crear permisos compuestos";
            this.btnCrearConjuntoDePermisos.Text = "Crear conjunto de permisos";
            this.btnCrearConjuntoDePermisos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(70, 654);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(320, 85);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormularioPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 805);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearConjuntoDePermisos);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.txtPermisosRol);
            this.Controls.Add(this.checkedListBoxPermisos);
            this.Controls.Add(this.checkedListBoxRoles);
            this.Name = "FormularioPermisos";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxRoles;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermisos;
        private System.Windows.Forms.TextBox txtPermisosRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnCrearConjuntoDePermisos;
        private System.Windows.Forms.Button btnSalir;
    }
}