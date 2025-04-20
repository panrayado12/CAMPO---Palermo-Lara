using BE;
using BLL;
using Microsoft.VisualBasic;
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
    public partial class FormularioMenuPrincipal941lp : Form, IObservadorTraduccion941lp
    {
        bll_usuario941lp bllUsuario;
        bll_bitacora941lp bllBitacora;
        BackupRestore941lp backupRestore;
        bll_permisos941lp bllPermisos;
        gestorPermisosControles941lp gestorPermisosControles;
        private FormularioBitacoraEventos941lp formularioBitacoraEventos;
        private FormAdministradorUsuario941lp formularioAdministradorUsuario;
        private FormularioPermisos941lp formularioPermisos;
        private FormCambiarContraseña formularioCambiarContraseña;

        public FormularioMenuPrincipal941lp()
        {
            InitializeComponent();
            bllUsuario = new bll_usuario941lp();
            backupRestore = new BackupRestore941lp();
            bllBitacora = new bll_bitacora941lp();
            formularioBitacoraEventos = new FormularioBitacoraEventos941lp();
            formularioAdministradorUsuario = new FormAdministradorUsuario941lp();
            formularioPermisos = new FormularioPermisos941lp();
            gestorPermisosControles = new gestorPermisosControles941lp();
            formularioCambiarContraseña = new FormCambiarContraseña();
            bllPermisos = new bll_permisos941lp();
            RegistrarControlesDeFormularios();
            RegistrarObservarDeFormularios();
            GestorDeTraducciones941lp.Gestor.NotificarCambioIdioma();
        }

        private void RegistrarControlesDeFormularios()
        {
            GestorDeTraducciones941lp.Gestor.RegistrarControles(this);
            GestorDeTraducciones941lp.Gestor.RegistrarControles(formularioAdministradorUsuario);
            GestorDeTraducciones941lp.Gestor.RegistrarControles(formularioBitacoraEventos);
            GestorDeTraducciones941lp.Gestor.RegistrarControles(formularioPermisos);
            GestorDeTraducciones941lp.Gestor.RegistrarControles(formularioCambiarContraseña);
        }

        private void RegistrarObservarDeFormularios()
        {
            GestorDeTraducciones941lp.Gestor.RegistrarObservador(this);
            GestorDeTraducciones941lp.Gestor.RegistrarObservador(formularioAdministradorUsuario);
            GestorDeTraducciones941lp.Gestor.RegistrarObservador(formularioBitacoraEventos);
            GestorDeTraducciones941lp.Gestor.RegistrarObservador(formularioPermisos);
            GestorDeTraducciones941lp.Gestor.RegistrarObservador(formularioCambiarContraseña);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea cerrar la sesión?", "CERRAR SESIÓN...", MessageBoxButtons.OKCancel);
                if(dr == DialogResult.OK)
                {
                    sessionManager941lp.Gestor.LogOut();
                    GestorFormulario941lp.gestorFormSG.DefinirEstado(new EstadoLogIn941lp());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnGestionDeUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                formularioAdministradorUsuario.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                formularioCambiarContraseña.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo de Backup (*.bak)|*.bak";
                saveFileDialog.Title = "Guardar Backup";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaDestino = saveFileDialog.FileName;
                    backupRestore.BackUp(rutaDestino);
                    MessageBox.Show("Backup realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bllBitacora.Alta("Formulario Menú", "BackUp", 2);
                }
            }
            catch (Exception ex) 
            {
                bllBitacora.Alta("Formulario Menú", "Error BackUp", 2);
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivo de Backup (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar Backup";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaBackup = openFileDialog.FileName;
                    backupRestore.Restore(rutaBackup);
                    MessageBox.Show("Base de datos restaurada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bllBitacora.Alta("Formulario Menú", "Restore", 2);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); bllBitacora.Alta("Formulario Menú", "Error Restore", 2); }
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {
            gestorPermisosControles.AplicarPermisosAControles(this, bllPermisos.ObtenerPermisosDeRolEspecificoLista(sessionManager941lp.Gestor.usuarioRol));
            panelSubMenuAdministrador.Visible = false;
            panelSubMenuMaestro.Visible = false;
            panelSubMenuUsuario.Visible = false;
            panelSubMenuAdopcion.Visible = false;
            panelSubMenuReportes.Visible = false;
        }

        private void OcultarSubmenus()
        {
            if (panelSubMenuUsuario.Visible == true)
            {
                panelSubMenuUsuario.Visible = false;
            }
            if (panelSubMenuAdministrador.Visible == true)
            {
                panelSubMenuAdministrador.Visible = false;
            }
            if (panelSubMenuMaestro.Visible == true)
            {
                panelSubMenuMaestro.Visible = false;
            }
        }

        private void MostrarSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                OcultarSubmenus();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                formularioBitacoraEventos.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion()
        {
            try
            {
                GestorDeTraducciones941lp.Gestor.TraducirControles(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxIdiomas.Text == "") throw new Exception(GestorDeTraducciones941lp.Gestor.TraducirTexto("ExcepcionComboBoxIdiomaVacio", "Se debe seleccionar un idioma"));
                GestorDeTraducciones941lp.Gestor.CambiarIdioma(comboBoxIdiomas.Text);
                string nombreusuario = sessionManager941lp.Gestor.RetornarUsuarioSession();
                Usuario941lp usuario = bllUsuario.RetornarUsuarios().Find(X => X.nombreUsuario == nombreusuario);
                usuario.lenguaje = comboBoxIdiomas.SelectedItem.ToString();
                bllUsuario.Modificar(usuario);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdministrarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                formularioPermisos.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUsuarioMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu(panelSubMenuUsuario);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdministradorMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu(panelSubMenuAdministrador);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnMaestroMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu(panelSubMenuMaestro);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu(panelSubMenuReportes);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu(panelSubMenuAdopcion);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarSubmenus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
