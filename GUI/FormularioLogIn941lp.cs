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
    public partial class FormularioLogIn941lp : Form
    {
        bll_usuario941lp bllUsuario;
        bll_bitacora941lp bllBitacora;
        public FormularioLogIn941lp()
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora941lp();
            bllUsuario = new bll_usuario941lp();
            GestorDeTraducciones941lp.Gestor.NotificarCambioIdioma();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreUsuario.Text == "" || txtContraseñaUsuario.Text == "") throw new Exception("Falta ingresar datos");
                if (bllUsuario.ValidarUsuario(txtNombreUsuario.Text, txtContraseñaUsuario.Text )==true)
                {
                    Usuario941lp usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == txtNombreUsuario.Text);
                    if (usuario.activo == true && usuario.bloqueo == false)
                    {
                        sessionManager941lp.Gestor.LogIn(txtNombreUsuario.Text, usuario.lenguaje, usuario.rolUsuario);
                        bllBitacora.Alta("Formulario de Inicio de Sesión", "Inicio de sesión", 1);
                        GestorFormulario941lp.gestorFormSG.DefinirEstado(new EstadoMenu941lp());
                    }
                    else
                    {
                        MessageBox.Show("Usuario bloqueado");
                        bllBitacora.Alta("Formulario de Inicio de Sesión", "Error de inicio de sesión", 2);
                    }
                }
                else
                {
                    bllBitacora.Alta("Formulario de Inicio de Sesión", "Error de inicio de sesión", 2);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioLogIn941lp_Load(object sender, EventArgs e)
        {

        }
    }
}
