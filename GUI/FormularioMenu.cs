﻿using BE;
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
    public partial class FormularioMenu : Form
    {
        bll_usuario bllUsuario;
        bll_bitacora bllBitacora;
        BackupRestore backupRestore;
        public FormularioMenu()
        {
            InitializeComponent();
            bllUsuario = new bll_usuario();
            backupRestore = new BackupRestore();
            bllBitacora = new bll_bitacora();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bllBitacora.Alta("Formulario Menú", "Cerrar sesión", 1);
                sessionManager.Gestor.LogOut();
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
                bllBitacora.Alta("Formulario Menú", "Cambio de contraseña", 2);
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

        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            try
            {
           
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoBitacora());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
