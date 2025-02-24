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
    public partial class FormularioLogIn : Form
    {
        bll_usuario bllUsuario;
        bll_bitacora bllBitacora;
        public FormularioLogIn()
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora();
            bllUsuario = new bll_usuario();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                sessionManager.Gestor.LogIn(txtNombreUsuario.Text);
                if (bllUsuario.ValidarUsuario(txtNombreUsuario.Text, txtContraseñaUsuario.Text )==true)
                {
                    Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == txtNombreUsuario.Text);
                    if (bllUsuario.RetornarEstadoDeUsuario(usuario)==true)
                    {
                        bllBitacora.Alta("Formulario de Inicio de Sesión", "Inicio de sesión", 1);
                        GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu());
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

        private void FormularioLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
