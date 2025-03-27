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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormularioPermisos : Form, IObservadorTraduccion
    {
        bll_permisos bllPermisos;
        List<Permiso> listaPermisos;
        List<Permiso> listaRoles;
        public FormularioPermisos()
        {
            InitializeComponent();
            bllPermisos = new bll_permisos();
            listaPermisos = new List<Permiso>();
            listaRoles = new List<Permiso>();
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            treeViewPermisos.CheckBoxes = true;
            treeViewRoles.CheckBoxes = true;
            listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
            listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
            LlenarTreeViews(treeViewPermisos, listaPermisos);
            LlenarTreeViews(treeViewRoles, listaRoles);
        }

        private void LlenarTreeViews(System.Windows.Forms.TreeView treeView, List<Permiso> listaPermisosRoles)
        {
            treeView.Nodes.Clear(); // Limpiar antes de agregar

            foreach (Permiso permiso in listaPermisosRoles)
            {
                if (permiso is PermisoCompuesto compuesto)
                {
                    TreeNode nodoPadre = new TreeNode(compuesto.nombrePermiso);
                    PermisoCompuesto permisoCargado = bllPermisos.ObtenerPermisoCompuesto(compuesto.nombrePermiso);
                    if (permisoCargado != null)
                    {
                        foreach (Permiso hijo in permisoCargado.ObtenerPermisos())
                        {
                            AgregarNodoRecursivo(nodoPadre, hijo);
                        }
                    }
                    treeView.Nodes.Add(nodoPadre);
                }
                else
                {
                    treeView.Nodes.Add(new TreeNode(permiso.nombrePermiso));
                }
            }
        }

        private void AgregarNodoRecursivo(TreeNode nodoPadre, Permiso permiso)
        {
            TreeNode nodoHijo = new TreeNode(permiso.nombrePermiso);
            nodoPadre.Nodes.Add(nodoHijo);

            if (permiso is PermisoCompuesto permisoCompuesto)
            {
                PermisoCompuesto permisoCargado = bllPermisos.ObtenerPermisoCompuesto(permisoCompuesto.nombrePermiso);
                if (permisoCargado != null)
                {
                    foreach (Permiso hijo in permisoCargado.ObtenerPermisos())
                    {
                        AgregarNodoRecursivo(nodoHijo, hijo);
                    }
                }
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
                RealizarPermisosCompuestos(false);
                listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
                LlenarTreeViews(treeViewPermisos,listaPermisos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RealizarPermisosCompuestos(bool esRol)
        {
            List<string> permisosAñadidos = new List<string>();
            string nombrePermisoCompuesto = txtPermisosRol.Text;

            // Recorremos todos los nodos del TreeView y obtenemos los seleccionados
            foreach (TreeNode nodo in treeViewPermisos.Nodes)
            {
                ObtenerPermisosSeleccionados(nodo, permisosAñadidos);
            }

            // Insertamos el permiso compuesto en la tabla de permisos
            bllPermisos.InsertarPermisoCompuesto(nombrePermisoCompuesto, esRol);

            // Insertamos la relación en la tabla intermedia
            bllPermisos.InsertarRelacion(nombrePermisoCompuesto, permisosAñadidos);
        }

        private void ObtenerPermisosSeleccionados(TreeNode nodo, List<string> permisosAñadidos)
        {
            if (nodo.Checked) // Si el nodo está seleccionado
            {
                permisosAñadidos.Add(nodo.Text); // Agregamos su nombre a la lista
            }

            // Recorremos los hijos del nodo actual
            foreach (TreeNode nodoHijo in nodo.Nodes)
            {
                ObtenerPermisosSeleccionados(nodoHijo, permisosAñadidos);
            }
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                RealizarPermisosCompuestos(true);
                listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
                LlenarTreeViews(treeViewRoles, listaRoles);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> permisosEliminados = new List<string>();
                foreach(TreeNode treeNode in treeViewPermisos.Nodes)
                {
                    if(treeNode.Checked)
                    {
                        permisosEliminados.Add(treeNode.Text);
                    }
                }
                bllPermisos.EliminarPermisoCompuesto(permisosEliminados);
                listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
                LlenarTreeViews(treeViewPermisos, listaPermisos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
