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
    public partial class FormAdministradorUsuario : Form
    {
        bll_usuario bll;
        public FormAdministradorUsuario()
        {
            InitializeComponent();
            bll = new bll_usuario();
        }

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarGrillaUsuario(bll.RetornarUsuarios());
        }

        public void CargarGrillaUsuario(List<Usuario> usuariosLista)
        {
            dataUsuarios.Rows.Clear();
            foreach(Usuario u in usuariosLista)
            {
                dataUsuarios.Rows.Add(u.nombreUsuario, u.nombre, u.apellido, u.contraseñaUsuario, u.rolUsuario, u.emailUsuario, u.estado, u.intentos);
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = txtNombreUsuario.Text;
                string apellidoUsuario = txtApellidoUsuario.Text;   
                string usuario = Interaction.InputBox("Nombre de usuario: ");
                string contraseña = txtContraseña.Text;
                string email = txtEmailUsuario.Text;
                string rolUsuario = txtRolUsuario.Text;
                Usuario u = new Usuario(usuario, contraseña, nombreUsuario, apellidoUsuario, rolUsuario,email, true, 0);
                bll.Alta(usuario, contraseña,nombreUsuario, apellidoUsuario, rolUsuario, email, true,0);
                CargarGrillaUsuario(bll.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
