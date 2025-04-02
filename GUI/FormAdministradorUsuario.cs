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
        bll_permisos bllPermisos;
        gestorPermisosControles gestorPermisosControles;
        public FormAdministradorUsuario()
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora();
            bllUsuario = new bll_usuario();
            bllPermisos = new bll_permisos();
            gestorPermisosControles = new gestorPermisosControles();
        }

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarGrillaUsuario(bllUsuario.RetornarUsuarios());
            CargarComboBoxRoles(bllPermisos.ObtenerTodosLosRolesLista());
            gestorPermisosControles.AplicarPermisosAControles(this, bllPermisos.ObtenerPermisosDeRolEspecificoLista(sessionManager.Gestor.RetornarUsuarioRol()));
        }

        private void CargarGrillaUsuario(List<Usuario> usuariosLista)
        {
            dataUsuarios.Rows.Clear();
            foreach(Usuario u in usuariosLista)
            {
                dataUsuarios.Rows.Add(u.dni,u.nombreUsuario, u.contraseñaUsuario, u.nombre, u.apellido, u.rolUsuario, u.emailUsuario, u.estado, u.intentos);
            }
        }

        private void CargarComboBoxRoles(List<Permiso> roles)
        {
            comboBoxRoles.Items.Clear();
            foreach(Permiso rol in roles)
            {
                comboBoxRoles.Items.Add(rol.nombrePermiso);
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text;
                string nombre = txtNombreUsuario.Text;
                string apellido = txtApellidoUsuario.Text;   
                string nombreUsuario = Interaction.InputBox("Nombre de usuario: ");
                string contraseña = txtContraseña.Text;
                string email = txtEmailUsuario.Text;
                string rolUsuario = comboBoxRoles.Text;
                string lenguaje = "es";
                bllUsuario.Alta(dni,nombreUsuario, contraseña,nombre, apellido, rolUsuario, email, true,0, lenguaje);
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
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells["nombreUsuario"].Value.ToString();
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
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells["nombreUsuario"].Value.ToString();
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuario);
                usuario.nombre = txtNombreUsuario.Text;
                usuario.apellido = txtApellidoUsuario.Text;
                usuario.emailUsuario = txtEmailUsuario.Text;
                usuario.rolUsuario = comboBoxRoles.Text;
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
                txtDni.Text = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                //nombre real
                txtNombreUsuario.Text = dataUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                txtApellidoUsuario.Text = dataUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                txtContraseña.Text = dataUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                comboBoxRoles.Text = dataUsuarios.SelectedRows[0].Cells[5].Value.ToString();
                txtEmailUsuario.Text = dataUsuarios.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = dataUsuarios.SelectedRows[0].Cells["nombreUsuario"].Value.ToString();
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
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion()
        {
            try
            {
                GestorDeTraducciones.Gestor.TraducirControles(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
