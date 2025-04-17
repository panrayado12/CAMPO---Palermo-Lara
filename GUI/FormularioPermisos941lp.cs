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
    public partial class FormularioPermisos941lp : Form, IObservadorTraduccion941lp
    {
        bll_permisos941lp bllPermisos;
        List<Permiso941lp> listaPermisos;
        List<Permiso941lp> listaRoles;
        gestorPermisosControles941lp gestorPermisosControles;
        public FormularioPermisos941lp()
        {
            InitializeComponent();
            bllPermisos = new bll_permisos941lp();
            listaPermisos = new List<Permiso941lp>();
            listaRoles = new List<Permiso941lp>();
            gestorPermisosControles = new gestorPermisosControles941lp();
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            treeViewPermisos.CheckBoxes = true;
            treeViewRoles.CheckBoxes = true;
            listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
            listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
            LlenarTreeViews(treeViewPermisos, listaPermisos);
            LlenarTreeViews(treeViewRoles, listaRoles);
            gestorPermisosControles.AplicarPermisosAControles(this, bllPermisos.ObtenerPermisosDeRolEspecificoLista(sessionManager941lp.Gestor.usuarioRol));
        }

        private void LlenarTreeViews(System.Windows.Forms.TreeView treeView, List<Permiso941lp> listaPermisosRoles)
        {
            treeView.Nodes.Clear();
            if(treeView.Name == "treeViewPermisos")
            {
                comboBoxPermisosCompuestos.Items.Clear();
            }
            foreach (Permiso941lp permiso in listaPermisosRoles)
            {
                if (permiso is PermisoCompuesto941lp compuesto)
                {
                    TreeNode nodoPadre = new TreeNode(compuesto.nombrePermiso);
                    PermisoCompuesto941lp permisoCargado = bllPermisos.ObtenerPermisoCompuesto(compuesto.nombrePermiso);
                    if (permisoCargado != null)
                    {
                        foreach (Permiso941lp hijo in permisoCargado.ObtenerPermisos())
                        {
                            AgregarNodoRecursivo(nodoPadre, hijo);
                        }
                    }
                    treeView.Nodes.Add(nodoPadre);
                    comboBoxPermisosCompuestos.Items.Add(nodoPadre.Text);
                }
                else
                {
                    treeView.Nodes.Add(new TreeNode(permiso.nombrePermiso));
                }
            }
        }

        private void AgregarNodoRecursivo(TreeNode nodoPadre, Permiso941lp permiso)
        {
            TreeNode nodoHijo = new TreeNode(permiso.nombrePermiso);
            nodoPadre.Nodes.Add(nodoHijo);

            if (permiso is PermisoCompuesto941lp permisoCompuesto)
            {
                PermisoCompuesto941lp permisoCargado = bllPermisos.ObtenerPermisoCompuesto(permisoCompuesto.nombrePermiso);
                if (permisoCargado != null)
                {
                    foreach (Permiso941lp hijo in permisoCargado.ObtenerPermisos())
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
                GestorDeTraducciones941lp.Gestor.TraducirControles(this);
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
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ObtenerPermisosSeleccionados(TreeNode nodo, List<string> permisosAñadidos)
        {
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                List<string> permisosEliminarSoloEnIntermedia = new List<string>();
                foreach(TreeNode treeNode in treeViewPermisos.Nodes)
                {
                    if(treeNode.Checked)
                    {
                        permisosEliminados.Add(treeNode.Text);
                    }
                    foreach (TreeNode hijo in treeNode.Nodes)
                    {
                        if (hijo.Checked)
                        {
                            permisosEliminarSoloEnIntermedia.Add(hijo.Text);
                        }
                    }
                }
                foreach (TreeNode treeNode in treeViewRoles.Nodes)
                {
                    if (treeNode.Checked)
                    {
                        permisosEliminados.Add(treeNode.Text);
                    }
                    foreach (TreeNode hijo in treeNode.Nodes)
                    {
                        if (hijo.Checked)
                        {
                            permisosEliminarSoloEnIntermedia.Add(hijo.Text);
                        }
                    }
                }
                bllPermisos.EliminarPermisoCompuesto(permisosEliminados);
                bllPermisos.EliminarPermisoEnIntermedia(permisosEliminarSoloEnIntermedia);
                listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
                listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
                LlenarTreeViews(treeViewRoles, listaRoles);
                LlenarTreeViews(treeViewPermisos, listaPermisos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminarRoles_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> rolesEliminados = new List<string>();
                foreach (TreeNode treeNode in treeViewRoles.Nodes)
                {
                    if (treeNode.Checked)
                    {
                        rolesEliminados.Add(treeNode.Text);
                    }
                }
                bllPermisos.EliminarRoles(rolesEliminados);
                listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
                LlenarTreeViews (treeViewRoles, listaRoles);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAsignarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> permisos = new List<string>();
                string permisoContenedor = comboBoxPermisosCompuestos.Text;
                foreach (TreeNode node in treeViewPermisos.Nodes)
                {
                    if(node.Checked)
                    {
                        permisos.Add(node.Text);
                    }
                }
                foreach(TreeNode rol in treeViewRoles.Nodes)
                {
                    if(rol.Checked)
                    {
                        bllPermisos.InsertarRelacion(rol.Text, permisos);
                    }
                }
                if(permisoContenedor != null)
                {
                    bllPermisos.InsertarRelacion(permisoContenedor, permisos);
                }
                listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
                listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
                LlenarTreeViews(treeViewPermisos, listaPermisos);
                LlenarTreeViews(treeViewRoles, listaRoles);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarPermisosCompuestos_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreNuevoPermisoCompuesto = txtPermisosRol.Text;
                string nombreAntiguoPermisoCompuesto = null;
                foreach(TreeNode permiso in treeViewPermisos.Nodes)
                {
                    if(permiso.Checked)
                    {
                        nombreAntiguoPermisoCompuesto = permiso.Text;
                    }
                }
                bllPermisos.ModificarNombrePermiso(nombreNuevoPermisoCompuesto, nombreAntiguoPermisoCompuesto);
                listaPermisos = bllPermisos.ObtenerTodosLosPermisosLista();
                listaRoles = bllPermisos.ObtenerTodosLosRolesLista();
                LlenarTreeViews(treeViewPermisos, listaPermisos);
                LlenarTreeViews(treeViewRoles, listaRoles);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
