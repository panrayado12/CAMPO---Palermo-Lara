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
using BE;
using BLL;

namespace GUI
{
    public partial class FormularioPermisos : Form, IObservadorTraduccion
    {
        bll_permisos bllPermisos;
        public FormularioPermisos()
        {
            InitializeComponent();
            bllPermisos = new bll_permisos();
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            LlenarCheckListBoxs();
        }

        private void LlenarCheckListBoxs()
        {
            checkedListBoxPermisos.Items.Clear();

            List<Permiso> permisos = bllPermisos.ObtenerTodosLosPermisosLista();
            List<Permiso> roles = bllPermisos.ObtenerTodosLosRolesLista();

            foreach (Permiso permiso in permisos)
            {
                checkedListBoxPermisos.Items.Add(permiso.nombrePermiso); 
            }
            foreach (Permiso r in roles)
            {
                checkedListBoxRoles.Items.Add(r.nombrePermiso);
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCrearConjuntoDePermisos_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> permisosAñadidos = new List<string>();
                string nombrePermisoCompuesto = txtPermisosRol.Text;
                foreach(string x in checkedListBoxPermisos.CheckedItems)
                {
                    permisosAñadidos.Add(x);
                }
                bllPermisos.InsertarPermisoCompuesto(nombrePermisoCompuesto, false);
                bllPermisos.InsertarRelacion(nombrePermisoCompuesto, permisosAñadidos);
                LlenarCheckListBoxs();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreRol = txtNombreRol.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
