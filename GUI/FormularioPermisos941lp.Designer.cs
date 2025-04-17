namespace GUI
{
    partial class FormularioPermisos941lp
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
            this.txtPermisosRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnCrearConjuntoDePermisos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAsignarPermisos = new System.Windows.Forms.Button();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.btnEliminarPermisos = new System.Windows.Forms.Button();
            this.btnEliminarRoles = new System.Windows.Forms.Button();
            this.btnModificarPermisosCompuestos = new System.Windows.Forms.Button();
            this.comboBoxPermisosCompuestos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtPermisosRol
            // 
            this.txtPermisosRol.Location = new System.Drawing.Point(70, 367);
            this.txtPermisosRol.Name = "txtPermisosRol";
            this.txtPermisosRol.Size = new System.Drawing.Size(400, 31);
            this.txtPermisosRol.TabIndex = 3;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(70, 419);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(320, 85);
            this.btnCrearRol.TabIndex = 4;
            this.btnCrearRol.Tag = "Crear roles";
            this.btnCrearRol.Text = "Crear rol";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // btnCrearConjuntoDePermisos
            // 
            this.btnCrearConjuntoDePermisos.Location = new System.Drawing.Point(70, 510);
            this.btnCrearConjuntoDePermisos.Name = "btnCrearConjuntoDePermisos";
            this.btnCrearConjuntoDePermisos.Size = new System.Drawing.Size(320, 85);
            this.btnCrearConjuntoDePermisos.TabIndex = 5;
            this.btnCrearConjuntoDePermisos.Tag = "Crear permisos compuestos";
            this.btnCrearConjuntoDePermisos.Text = "Crear conjunto de permisos";
            this.btnCrearConjuntoDePermisos.UseVisualStyleBackColor = true;
            this.btnCrearConjuntoDePermisos.Click += new System.EventHandler(this.btnCrearConjuntoDePermisos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(70, 692);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(320, 85);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAsignarPermisos
            // 
            this.btnAsignarPermisos.Location = new System.Drawing.Point(70, 83);
            this.btnAsignarPermisos.Name = "btnAsignarPermisos";
            this.btnAsignarPermisos.Size = new System.Drawing.Size(320, 85);
            this.btnAsignarPermisos.TabIndex = 8;
            this.btnAsignarPermisos.Tag = "";
            this.btnAsignarPermisos.Text = "Asignar permisos";
            this.btnAsignarPermisos.UseVisualStyleBackColor = true;
            this.btnAsignarPermisos.Click += new System.EventHandler(this.btnAsignarPermisos_Click);
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(566, 83);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(410, 694);
            this.treeViewPermisos.TabIndex = 9;
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(1095, 83);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(410, 694);
            this.treeViewRoles.TabIndex = 10;
            // 
            // btnEliminarPermisos
            // 
            this.btnEliminarPermisos.Location = new System.Drawing.Point(70, 174);
            this.btnEliminarPermisos.Name = "btnEliminarPermisos";
            this.btnEliminarPermisos.Size = new System.Drawing.Size(320, 85);
            this.btnEliminarPermisos.TabIndex = 11;
            this.btnEliminarPermisos.Tag = "Eliminar permisos";
            this.btnEliminarPermisos.Text = "Eliminar permisos";
            this.btnEliminarPermisos.UseVisualStyleBackColor = true;
            this.btnEliminarPermisos.Click += new System.EventHandler(this.btnEliminarPermisos_Click);
            // 
            // btnEliminarRoles
            // 
            this.btnEliminarRoles.Location = new System.Drawing.Point(70, 265);
            this.btnEliminarRoles.Name = "btnEliminarRoles";
            this.btnEliminarRoles.Size = new System.Drawing.Size(320, 85);
            this.btnEliminarRoles.TabIndex = 12;
            this.btnEliminarRoles.Tag = "Eliminar roles";
            this.btnEliminarRoles.Text = "Eliminar rol/es";
            this.btnEliminarRoles.UseVisualStyleBackColor = true;
            this.btnEliminarRoles.Click += new System.EventHandler(this.btnEliminarRoles_Click);
            // 
            // btnModificarPermisosCompuestos
            // 
            this.btnModificarPermisosCompuestos.Location = new System.Drawing.Point(70, 601);
            this.btnModificarPermisosCompuestos.Name = "btnModificarPermisosCompuestos";
            this.btnModificarPermisosCompuestos.Size = new System.Drawing.Size(320, 85);
            this.btnModificarPermisosCompuestos.TabIndex = 13;
            this.btnModificarPermisosCompuestos.Tag = "Modificar nombre permisos compuestos";
            this.btnModificarPermisosCompuestos.Text = "Modificar nombre de permisos compuestos";
            this.btnModificarPermisosCompuestos.UseVisualStyleBackColor = true;
            this.btnModificarPermisosCompuestos.Click += new System.EventHandler(this.btnModificarPermisosCompuestos_Click);
            // 
            // comboBoxPermisosCompuestos
            // 
            this.comboBoxPermisosCompuestos.FormattingEnabled = true;
            this.comboBoxPermisosCompuestos.Location = new System.Drawing.Point(566, 21);
            this.comboBoxPermisosCompuestos.Name = "comboBoxPermisosCompuestos";
            this.comboBoxPermisosCompuestos.Size = new System.Drawing.Size(410, 33);
            this.comboBoxPermisosCompuestos.TabIndex = 14;
            // 
            // FormularioPermisos941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 805);
            this.Controls.Add(this.comboBoxPermisosCompuestos);
            this.Controls.Add(this.btnModificarPermisosCompuestos);
            this.Controls.Add(this.btnEliminarRoles);
            this.Controls.Add(this.btnEliminarPermisos);
            this.Controls.Add(this.treeViewRoles);
            this.Controls.Add(this.treeViewPermisos);
            this.Controls.Add(this.btnAsignarPermisos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearConjuntoDePermisos);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.txtPermisosRol);
            this.Name = "FormularioPermisos941lp";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPermisosRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnCrearConjuntoDePermisos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAsignarPermisos;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.Button btnEliminarPermisos;
        private System.Windows.Forms.Button btnEliminarRoles;
        private System.Windows.Forms.Button btnModificarPermisosCompuestos;
        private System.Windows.Forms.ComboBox comboBoxPermisosCompuestos;
    }
}