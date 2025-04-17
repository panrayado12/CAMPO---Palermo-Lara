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
    public partial class FormAdministradorUsuario941lp : Form, IObservadorTraduccion941lp
    {
        bll_usuario941lp bllUsuario;
        bll_bitacora941lp bllBitacora;
        bll_permisos941lp bllPermisos;
        gestorPermisosControles941lp gestorPermisosControles;
        string modo = "Consulta";
        public FormAdministradorUsuario941lp()
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora941lp();
            bllUsuario = new bll_usuario941lp();
            bllPermisos = new bll_permisos941lp();
            gestorPermisosControles = new gestorPermisosControles941lp();
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
            CargarComboBoxRoles(bllPermisos.ObtenerTodosLosRolesLista());
            gestorPermisosControles.AplicarPermisosAControles(this, bllPermisos.ObtenerPermisosDeRolEspecificoLista(sessionManager941lp.Gestor.RetornarUsuarioRol()));
            EnableTxt(false);
            DefinirModoEnTxt();
        }

        private void EnableTxt(bool habilitar)
        {
            txtDni.Enabled = habilitar;
            txtApellidoUsuario.Enabled = habilitar;
            txtNombreUsuario.Enabled = habilitar;
            txtEmailUsuario.Enabled = habilitar;
            comboBoxRoles.Enabled = habilitar;
            txtLoginUsuario.Enabled = habilitar;
        }

        private void MostrarGrillaUsuarios(List<Usuario941lp> usuariosLista)
        {
            dataUsuarios.Rows.Clear();

            foreach (Usuario941lp u in usuariosLista)
            {
                if (checkBoxActivosConsulta.Checked)
                {
                    if (u.activo == true)
                    {
                        dataUsuarios.Rows.Add(u.dni, u.nombre, u.apellido, u.nombreUsuario, u.rolUsuario, u.emailUsuario, u.bloqueo);
                    }
                }
                else
                {
                    int rowIndex = dataUsuarios.Rows.Add(u.dni, u.nombre, u.apellido, u.nombreUsuario, u.rolUsuario, u.emailUsuario, u.bloqueo);
                    if (!u.activo)
                    {
                        dataUsuarios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void CargarComboBoxRoles(List<Permiso941lp> roles)
        {
            comboBoxRoles.Items.Clear();
            foreach(Permiso941lp rol in roles)
            {
                comboBoxRoles.Items.Add(rol.nombrePermiso);
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Alta";
                btnAltaUsuario.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnSalir.Enabled = false;
                btnDesbloquearUsuario.Enabled=false;
                btnActivarDesactivar.Enabled=false;
                btnCancelar.Enabled = true;
                btnAplicar.Enabled = true;
                EnableTxt(true);
                DefinirModoEnTxt();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error alta usuario", 2);
            }
        }

        private void DefinirModoEnTxt()
        {
            txtModo.Text = modo;
        }

        private void btnActDesactUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Act/Descat";
                btnAltaUsuario.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnSalir.Enabled = false;
                btnDesbloquearUsuario.Enabled = false;
                btnActivarDesactivar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAplicar.Enabled = true;
                EnableTxt(false);
                DefinirModoEnTxt();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Administrador de usuarios", "Error baja usuario", 2);
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Modificar";
                btnAltaUsuario.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnSalir.Enabled = false;
                btnDesbloquearUsuario.Enabled = false;
                btnActivarDesactivar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAplicar.Enabled = true;
                EnableTxt(true);
                DefinirModoEnTxt();
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
                txtNombreUsuario.Text = dataUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidoUsuario.Text = dataUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                txtLoginUsuario.Text = dataUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                comboBoxRoles.Text = dataUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                txtEmailUsuario.Text = dataUsuarios.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Desbloquear";
                btnAltaUsuario.Enabled = false;
                btnModificarUsuario.Enabled = false;
                btnSalir.Enabled = false;
                btnDesbloquearUsuario.Enabled = false;
                btnActivarDesactivar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAplicar.Enabled = true;
                EnableTxt(false);
                DefinirModoEnTxt();
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
                GestorDeTraducciones941lp.Gestor.TraducirControles(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancelar.Enabled = false;
                btnAltaUsuario.Enabled = true;
                btnModificarUsuario.Enabled = true;
                btnActivarDesactivar.Enabled = true;
                btnDesbloquearUsuario.Enabled = true;
                btnSalir.Enabled = true;
                string nombreUsuarioEnGrilla = "";
                Usuario941lp usuario = null;
                if (modo != "Consulta" && modo!= "Alta")
                {
                    if (dataUsuarios.SelectedRows == null) throw new Exception("Selecciones un usuario");
                    nombreUsuarioEnGrilla = dataUsuarios.SelectedRows[0].Cells["nombreUsuario"].Value.ToString();
                    usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == nombreUsuarioEnGrilla);
                }
                switch (modo)
                {
                    case "Consulta":
                        btnAplicar.Enabled = true;
                        MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
                        break;
                    case "Alta":
                        string dni = txtDni.Text;
                        string nombre = txtNombreUsuario.Text;
                        string apellido = txtApellidoUsuario.Text;
                        string nombreUsuario = txtLoginUsuario.Text;
                        string contraseña = txtApellidoUsuario.Text + txtDni.Text;
                        string email = txtEmailUsuario.Text;
                        int intentos = 0;
                        string rolUsuario = comboBoxRoles.Text;
                        bool bloqueo = false;
                        bool activo = true;
                        string lenguaje = "es";
                        Usuario941lp u = new Usuario941lp(dni, nombreUsuario, contraseña, nombre, apellido, rolUsuario, email, bloqueo, intentos, lenguaje, activo);
                        bllUsuario.Alta(u);
                        MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
                        break;
                    case "Modificar":
                        usuario.nombre = txtNombreUsuario.Text;
                        usuario.apellido = txtApellidoUsuario.Text;
                        usuario.emailUsuario = txtEmailUsuario.Text;
                        usuario.rolUsuario = comboBoxRoles.Text;
                        bllUsuario.Modificar(usuario);
                        MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
                        break;
                    case "Act/Descat":
                        if(usuario.activo == true)
                        {
                            usuario.activo = false;
                        }
                        else
                        {
                            usuario.activo = true;
                        }
                        bllUsuario.Baja(usuario);
                        MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
                        break;
                    case "Desbloquear":
                        btnAltaUsuario.Enabled = false;
                        btnModificarUsuario.Enabled = false;
                        btnActivarDesactivar.Enabled = false;
                        checkBoxActivosConsulta.Enabled = false;
                        checkBoxTodosConsulta.Enabled = false;
                        btnAplicar.Enabled = true;
                        btnCancelar.Enabled = true;
                        if (usuario.bloqueo == true)
                        {
                            usuario.bloqueo = false;
                        }
                        bllUsuario.Modificar(usuario);
                        MostrarGrillaUsuarios(bllUsuario.RetornarUsuarios());
                        break;
                    default:
                        Console.WriteLine("Color desconocido");
                        break;
                }
                modo = "Consulta";
                DefinirModoEnTxt();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Consulta";
                btnAplicar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAltaUsuario.Enabled = true;
                btnActivarDesactivar.Enabled = true;
                btnModificarUsuario.Enabled = true;
                btnDesbloquearUsuario.Enabled = true;
                btnSalir.Enabled = true;
                DefinirModoEnTxt();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBoxActivosConsulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkBoxTodosConsulta.Checked = false;
                modo = "Consulta";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBoxTodosConsulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkBoxActivosConsulta.Checked = false;
                modo = "Consulta";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
