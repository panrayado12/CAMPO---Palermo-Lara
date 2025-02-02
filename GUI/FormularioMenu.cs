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
        public FormularioMenu()
        {
            InitializeComponent();
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
    }
}
