using BE;
using BLL;
using Microsoft.VisualBasic;
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
    public partial class FormularioMenu : Form
    {
        bll_usuario bllUsuario;
        bll_irreversible bllSeguridad;
        public FormularioMenu()
        {
            InitializeComponent();
            bllUsuario = new bll_usuario();
            bllSeguridad = new bll_irreversible();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoLogIn());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoAdmin());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = Interaction.InputBox("Ingrese su nombre de usuario: ", "USUARIO");
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                if(usuario==null)
                {
                    MessageBox.Show("USUARIO NO ENCONTRADO");
                    throw new Exception();
                }
                bllUsuario.Modificar(usuario);
                MessageBox.Show("Su contraseña a sido modificada con exito");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
