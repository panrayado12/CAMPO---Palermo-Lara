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
    public partial class FormularioLogIn : Form, IObservadorTraduccion
    {
        bll_usuario bllUsuario;
        bll_bitacora bllBitacora;
        private GestorDeTraducciones gestorTraducciones;
        public FormularioLogIn(GestorDeTraducciones gestor)
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora();
            bllUsuario = new bll_usuario();
            gestorTraducciones = gestor; // Asignamos el gestor recibido
            // Registra los controles en el JSON
            gestorTraducciones.RegistrarControles(this);
            // Se registra como observador
            gestorTraducciones.RegistrarObservador(this);
            // Aplica la traducción actual
            Load += (s, e) => ActualizarTraduccion();
        }

        public void ActualizarTraduccion()
        {
            gestorTraducciones.TraducirControles(this);
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
                        GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu(gestorTraducciones));
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

        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                gestorTraducciones.CambiarIdioma(comboBoxIdioma.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
