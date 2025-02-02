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
using System.Security.Cryptography;

namespace GUI
{
    public partial class FormAdministradorUsuario : Form
    {
        bll_usuario bllUsuario;
        bll_seguridad bllSeguridad;
        public FormAdministradorUsuario()
        {
            InitializeComponent();
            bllUsuario = new bll_usuario();
            bllSeguridad = new bll_seguridad();
        }

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
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
                string nombre = txtNombreUsuario.Text;
                string apellido = txtApellidoUsuario.Text;   
                string nombreUsuario = Interaction.InputBox("Nombre de usuario: ");
                string contraseña = txtContraseña.Text;
                string email = txtEmailUsuario.Text;
                string rolUsuario = txtRolUsuario.Text;
                string contraseñaHasheada = bllSeguridad.GetSHA256(contraseña);
                Usuario u = new Usuario(nombreUsuario, contraseñaHasheada, nombre, apellido, rolUsuario,email, true, 0);
                if (bllUsuario.ValidarUsuario(nombreUsuario, contraseñaHasheada) == true) throw new Exception("Usuario ya existente");
                bllUsuario.Alta(nombreUsuario, contraseñaHasheada,nombre, apellido, rolUsuario, email, true,0);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                bllUsuario.Baja(usuario);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                usuario.nombre = txtNombreUsuario.Text;
                usuario.apellido = txtApellidoUsuario.Text;
                usuario.contraseñaUsuario = txtContraseña.Text;
                usuario.emailUsuario = txtEmailUsuario.Text;
                usuario.rolUsuario = txtRolUsuario.Text;
                bllUsuario.Modificar(usuario);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombreUsuario.Text = dataUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                txtApellidoUsuario.Text = dataUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                txtContraseña.Text = dataUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                txtRolUsuario.Text = dataUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                txtEmailUsuario.Text = dataUsuarios.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                bllUsuario.BloquearDesbloquearUsuario(usuario);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
