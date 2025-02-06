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
        public FormularioLogIn()
        {
            InitializeComponent();
            bllUsuario = new bll_usuario();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.ValidarUsuario(txtNombreUsuario.Text, txtContraseñaUsuario.Text )==true)
                {
                    Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == txtNombreUsuario.Text);
                    if(bllUsuario.RetornarEstadoDeUsuario(usuario)==true)
                    {
                        GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FormularioLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
