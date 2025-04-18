namespace GUI
{
    partial class FormularioLogIn941lp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioLogIn941lp));
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtContraseñaUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNombreUsuarioLogIn = new System.Windows.Forms.Label();
            this.labelContraseñaLogIN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.Location = new System.Drawing.Point(179, 504);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(289, 61);
            this.btnIniciarSesion.TabIndex = 0;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(359, 188);
            this.txtNombreUsuario.Multiline = true;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(289, 55);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtContraseñaUsuario
            // 
            this.txtContraseñaUsuario.Location = new System.Drawing.Point(359, 306);
            this.txtContraseñaUsuario.Multiline = true;
            this.txtContraseñaUsuario.Name = "txtContraseñaUsuario";
            this.txtContraseñaUsuario.Size = new System.Drawing.Size(289, 55);
            this.txtContraseñaUsuario.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(735, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelNombreUsuarioLogIn
            // 
            this.labelNombreUsuarioLogIn.AutoSize = true;
            this.labelNombreUsuarioLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreUsuarioLogIn.Location = new System.Drawing.Point(12, 188);
            this.labelNombreUsuarioLogIn.Name = "labelNombreUsuarioLogIn";
            this.labelNombreUsuarioLogIn.Size = new System.Drawing.Size(201, 44);
            this.labelNombreUsuarioLogIn.TabIndex = 5;
            this.labelNombreUsuarioLogIn.Text = "USUARIO:";
            this.labelNombreUsuarioLogIn.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelContraseñaLogIN
            // 
            this.labelContraseñaLogIN.AutoSize = true;
            this.labelContraseñaLogIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseñaLogIN.Location = new System.Drawing.Point(12, 317);
            this.labelContraseñaLogIN.Name = "labelContraseñaLogIN";
            this.labelContraseñaLogIN.Size = new System.Drawing.Size(291, 44);
            this.labelContraseñaLogIN.TabIndex = 6;
            this.labelContraseñaLogIN.Text = "CONTRASEÑA:";
            // 
            // FormularioLogIn941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(1279, 736);
            this.Controls.Add(this.labelContraseñaLogIN);
            this.Controls.Add(this.labelNombreUsuarioLogIn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtContraseñaUsuario);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Name = "FormularioLogIn941lp";
            this.Text = "log in ";
            this.Load += new System.EventHandler(this.FormularioLogIn941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtContraseñaUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNombreUsuarioLogIn;
        private System.Windows.Forms.Label labelContraseñaLogIN;
    }
}

