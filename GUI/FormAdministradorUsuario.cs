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
using SERVICIOS;

namespace GUI
{
    public partial class FormAdministradorUsuario : Form, IObservadorTraduccion
    {
        bll_usuario bllUsuario;
        bll_bitacora bllBitacora;
        private GestorDeTraducciones gestorTraducciones;
        public FormAdministradorUsuario(GestorDeTraducciones gestor)
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
                dataUsuarios.Rows.Add(u.nombreUsuario, u.contraseñaUsuario, u.nombre, u.apellido, u.rolUsuario, u.emailUsuario, u.estado, u.intentos);
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
                bllUsuario.Alta(nombreUsuario, contraseña,nombre, apellido, rolUsuario, email, true,0);
                bllBitacora.Alta("Formulario Administrador de usuarios", "Alta usuario", 2);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error alta usuario", 2);
            }
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                bllUsuario.Baja(usuario);
                bllBitacora.Alta("Formulario Administrador de usuarios", "Baja usuario", 2);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error baja usuario", 2);
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                usuario.nombre = txtNombreUsuario.Text;
                usuario.apellido = txtApellidoUsuario.Text;
                usuario.emailUsuario = txtEmailUsuario.Text;
                usuario.rolUsuario = txtRolUsuario.Text;
                bllUsuario.Modificar(usuario);
                bllBitacora.Alta("Formulario Administrador de usuarios", "Modificar usuario", 2);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error modificar usuario", 2);
            }
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
                bllBitacora.Alta("Formulario Administrador de usuarios", "Desbloquear/Bloquear usuario", 2);
                CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error desbloqueo/bloqueo usuario", 2);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu(gestorTraducciones));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
