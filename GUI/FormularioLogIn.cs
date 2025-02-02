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
        bll_usuario bll;
        public FormularioLogIn()
        {
            InitializeComponent();
            bll = new bll_usuario();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
               if(bll.ValidarUsuario(txtNombreUsuario.Text, txtContraseñaUsuario.Text)==true)
               {
                    GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu());
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
