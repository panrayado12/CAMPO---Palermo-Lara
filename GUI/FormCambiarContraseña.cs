using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormCambiarContraseña : Form, IObservadorTraduccion941lp
    {
        bll_usuario941lp bllUsuario941lp;
        public FormCambiarContraseña()
        {
            InitializeComponent();
            bllUsuario941lp = new bll_usuario941lp();
        }

        public void ActualizarTraduccion()
        {
            try
            {
                GestorDeTraducciones941lp.Gestor.TraducirControles(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAceptarCambioContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseñaActual = txtContraseñaActual.Text;
                string contraseñaNueva = txtContraseñaNueva.Text;
                string contraseñaConfirmacion = txtContraseñaConfirmacion.Text;
                Usuario941lp usuario = bllUsuario941lp.RetornarUsuarios().Find(x => x.nombreUsuario == sessionManager941lp.Gestor.RetornarUsuarioSession());
                if (bllUsuario941lp.ValidarContraseñaUsuario(usuario.dni, contraseñaActual) == false) throw new Exception("Contraseña actual incorrecta");
                if (contraseñaNueva != contraseñaConfirmacion) throw new Exception("La contraseña nueva y la confirmación no coinciden");
                usuario.contraseñaUsuario = contraseñaNueva;
                bllUsuario941lp.ModificarContraseña(usuario);
                MessageBox.Show("Su contraseña a sido modificada con exito");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
