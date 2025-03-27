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
            this.txtPermisosRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnCrearConjuntoDePermisos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.btnAsignarPermisos = new System.Windows.Forms.Button();
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.btnEliminarPermisos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPermisosRol
            // 
            this.txtPermisosRol.Location = new System.Drawing.Point(70, 382);
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
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
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
            this.btnCrearConjuntoDePermisos.Click += new System.EventHandler(this.btnCrearConjuntoDePermisos_Click);
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
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(70, 131);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(400, 31);
            this.txtNombreRol.TabIndex = 7;
            // 
            // btnAsignarPermisos
            // 
            this.btnAsignarPermisos.Location = new System.Drawing.Point(70, 189);
            this.btnAsignarPermisos.Name = "btnAsignarPermisos";
            this.btnAsignarPermisos.Size = new System.Drawing.Size(320, 85);
            this.btnAsignarPermisos.TabIndex = 8;
            this.btnAsignarPermisos.Tag = "Asignar permisos";
            this.btnAsignarPermisos.Text = "Asignar permisos";
            this.btnAsignarPermisos.UseVisualStyleBackColor = true;
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(672, 131);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(410, 617);
            this.treeViewPermisos.TabIndex = 9;
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Location = new System.Drawing.Point(1154, 131);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(410, 617);
            this.treeViewRoles.TabIndex = 10;
            // 
            // btnEliminarPermisos
            // 
            this.btnEliminarPermisos.Location = new System.Drawing.Point(70, 280);
            this.btnEliminarPermisos.Name = "btnEliminarPermisos";
            this.btnEliminarPermisos.Size = new System.Drawing.Size(320, 85);
            this.btnEliminarPermisos.TabIndex = 11;
            this.btnEliminarPermisos.Tag = "Eliminar permisos";
            this.btnEliminarPermisos.Text = "Eliminar permisos";
            this.btnEliminarPermisos.UseVisualStyleBackColor = true;
            this.btnEliminarPermisos.Click += new System.EventHandler(this.btnEliminarPermisos_Click);
            // 
            // FormularioPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 805);
            this.Controls.Add(this.btnEliminarPermisos);
            this.Controls.Add(this.treeViewRoles);
            this.Controls.Add(this.treeViewPermisos);
            this.Controls.Add(this.btnAsignarPermisos);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearConjuntoDePermisos);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.txtPermisosRol);
            this.Name = "FormularioPermisos";
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
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Button btnAsignarPermisos;
        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.Button btnEliminarPermisos;
    }
}