using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace ORM
{
    public class orm_permiso941lp
    {
        private dao941lp dao;
        private DataTable dtPermisos;
        private DataTable dtIntermedia;

        private static orm_permiso941lp instacia;

        public static orm_permiso941lp Gestor
        {
            get
            {
                if(instacia == null)
                {
                    instacia = new orm_permiso941lp();
                }
                return instacia;
            }
        }

        public orm_permiso941lp()
        {
            dao = new dao941lp();
            dtPermisos = dao.RetornarTabla("Permisos941lp");
            dtIntermedia = dao.RetornarTabla("PermisosIntermedia941lp");
        }

        // Construye la estructura del Composite en cada llamada
        public PermisoCompuesto941lp ObtenerPermisoCompuesto(string nombrePermiso)
        {
            DataRow[] filas = dtPermisos.Select($"nombrePermiso941lp = '{nombrePermiso}' AND compuesto941lp = true");

            if (filas.Length == 0)
                return null;

            bool esRol = Convert.ToBoolean(filas[0]["esRol941lp"]);
            PermisoCompuesto941lp permisoCompuesto = new PermisoCompuesto941lp(nombrePermiso, esRol);

            // Obtener y agregar sus hijos
            DataRow[] relaciones = dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{nombrePermiso}'");

            foreach (DataRow fila in relaciones)
            {
                string nombreHijo = fila["permisoAñadido941lp"].ToString();
                Permiso941lp hijo = ObtenerPermiso(nombreHijo);
                permisoCompuesto.AgregarPermiso(hijo);
            }
            return permisoCompuesto;
        }

        // Obtiene un permiso (ya sea compuesto o simple)
        public Permiso941lp ObtenerPermiso(string nombrePermiso)
        {
            DataRow[] filas = dtPermisos.Select($"nombrePermiso941lp = '{nombrePermiso}'");

            if (filas.Length == 0)
                return null;

            bool esRol = Convert.ToBoolean(filas[0]["esRol941lp"]);
            bool esCompuesto = Convert.ToBoolean(filas[0]["compuesto941lp"]);

            if (esCompuesto)
                return ObtenerPermisoCompuesto(nombrePermiso);
            else
                return new PermisoSimple941lp(nombrePermiso, esRol);
        }

        // Insertar un nuevo permiso compuesto
        public void InsertarPermisoCompuesto(string nombrePermiso, bool esRol)
        {
            DataRow nuevaFila = dtPermisos.NewRow();
            nuevaFila["nombrePermiso941lp"] = nombrePermiso;
            nuevaFila["compuesto941lp"] = true;
            nuevaFila["esRol941lp"] = esRol;
            dtPermisos.Rows.Add(nuevaFila);
            GuardarCambios();
        }

        public void InsertarRelacion(string nombreCompuesto, List<string> nombresPermisosHijos)
        {
            foreach (string permisoHijo in nombresPermisosHijos)
            {
                DataRow nuevaFila = dtIntermedia.NewRow();
                nuevaFila["nombrePermisoCompuesto941lp"] = nombreCompuesto;
                nuevaFila["permisoAñadido941lp"] = permisoHijo;
                dtIntermedia.Rows.Add(nuevaFila);
            }
            GuardarCambios();
        }

        // Eliminar un permiso compuesto y sus relaciones
        public void EliminarPermisoCompuesto(List<string> nombrePermisosEliminados)
        {
            foreach(string permiso in nombrePermisosEliminados)
            {
                DataRow[] fila = dtIntermedia.Select($"permisoAñadido941lp = '{permiso}'");
                foreach(DataRow dtrow in fila)
                {
                    DataRow[] rol = dtPermisos.Select($"nombrePermiso941lp = '{dtrow["nombrePermisoCompuesto941lp"]}'");
                    foreach(DataRow dtrow2 in rol)
                    {
                        string esrol = dtrow2["esRol941lp"].ToString();
                        if (dtrow2["esRol941lp"].ToString() == "False")
                        {
                            foreach (DataRow row in dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{permiso}' OR permisoAñadido941lp = '{permiso}'"))
                            {
                                row.Delete();
                            }

                            foreach (DataRow row in dtPermisos.Select($"nombrePermiso941lp = '{permiso}'"))
                            {
                                row.Delete();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar el permiso porque esta asignado a un rol");
                        }
                    }
                }
                //si el permiso no es añadido, si es solo permisoCompuesto en la tabla intermedia
                if(fila.Length==0)
                {
                    foreach (DataRow row in dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{permiso}'"))
                    {
                        row.Delete();
                    }

                    foreach (DataRow row in dtPermisos.Select($"nombrePermiso941lp = '{permiso}'"))
                    {
                        row.Delete();
                    }
                }
            }
            GuardarCambios();
        }

        public void EliminarPermisosEnIntermedia(List<string> nombrePermisos)
        {
            foreach (string permiso in nombrePermisos)
            {
                foreach (DataRow row in dtIntermedia.Select($"permisoAñadido941lp = '{permiso}'"))
                {
                    row.Delete();
                }
            }
            GuardarCambios();
        }

        public void EliminarRoles(List<string> nombreRolesEliminados)
        {
            foreach(string rol in nombreRolesEliminados)
            {
                foreach (DataRow row in dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{rol}'"))
                {
                    row.Delete();
                }

                foreach (DataRow row in dtPermisos.Select($"nombrePermiso941lp = '{rol}'"))
                {
                    row.Delete();
                }
            }
            GuardarCambios();
        }

        public void ModificarNombrePermiso(string nombreNuevoPermiso, string nombreViejoPermiso)
        {
            foreach (DataRow row in dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{nombreViejoPermiso}'"))
            {
                row.ItemArray = new object[] { nombreNuevoPermiso, row.Field<string>(1) };
            }

            foreach (DataRow row in dtIntermedia.Select($"permisoAñadido941lp = '{nombreViejoPermiso}'"))
            {
                row.ItemArray = new object[] { row.Field<string>(0), nombreNuevoPermiso };
            }

            foreach (DataRow row in dtPermisos.Select($"nombrePermiso941lp = '{nombreViejoPermiso}'"))
            {
                row.ItemArray = new object[] { nombreNuevoPermiso, row.Field<bool>(1), row.Field<bool>(2) };
            }
            GuardarCambios();
        }

        public List<Permiso941lp> ObtenerTodosLosPermisos()
        {
            List<Permiso941lp> listaPermisos = new List<Permiso941lp>();
            DataRow[] filas = dtPermisos.Select("esRol941lp = false");
            foreach (DataRow fila in filas)
            {
                string nombre = fila["nombrePermiso941lp"].ToString();
                bool esCompuesto = Convert.ToBoolean(fila["compuesto941lp"]);
                if (esCompuesto)
                {
                    listaPermisos.Add(ObtenerPermisoCompuesto(nombre));
                }
                else
                {
                    listaPermisos.Add(new PermisoSimple941lp(nombre, false));
                }
            }
            return listaPermisos;
        }

        public List<Permiso941lp> ObtenerTodosLosRoles()
        {
            List<Permiso941lp> listaRoles = new List<Permiso941lp>();
            DataRow[] filas = dtPermisos.Select("esRol941lp = true AND compuesto941lp = true");
            foreach (DataRow fila in filas)
            {
                string nombre = fila["nombrePermiso941lp"].ToString();
                listaRoles.Add(ObtenerPermisoCompuesto(nombre));   
            }
            return listaRoles;
        }

        public List<string> ObtenerPermisosDeRolEspecifico(string rol)
        {
            List<Permiso941lp> permisos = new List<Permiso941lp>();
            DataRow[] filas = dtIntermedia.Select($"nombrePermisoCompuesto941lp = '{rol}'");
            foreach (DataRow fila in filas)
            {
                string nombre = fila["permisoAñadido941lp"].ToString();
                permisos.Add(ObtenerPermiso(nombre));
            }
            return ExtraerPermisosSimples(permisos);
        }

        private List<string> ExtraerPermisosSimples(List<Permiso941lp> permisos)
        {
            List<string> permisosSimples = new List<string>();

            foreach (Permiso941lp permiso in permisos)
            {
                if (permiso is PermisoSimple941lp permisoSimple)
                {
                    permisosSimples.Add(permisoSimple.nombrePermiso);
                }
                else if (permiso is PermisoCompuesto941lp permisoCompuesto)
                {
                    // Llamada recursiva para procesar permisos compuestos anidados
                    permisosSimples.AddRange(ExtraerPermisosSimples(permisoCompuesto.ObtenerPermisos()));
                }
            }
            return permisosSimples;
        }

        public void GuardarCambios()
        {
            dao.Update(dtPermisos);
            dao.Update(dtIntermedia);
        }
    }
}
