using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace ORM
{
    public class orm_permiso
    {
        private dao dao;
        private DataTable dtPermisos;
        private DataTable dtIntermedia;

        private static orm_permiso instacia;

        public static orm_permiso Gestor
        {
            get
            {
                if(instacia == null)
                {
                    instacia = new orm_permiso();
                }
                return instacia;
            }
        }

        public orm_permiso()
        {
            dao = new dao();
            dtPermisos = dao.RetornarTabla("Permisos");
            dtIntermedia = dao.RetornarTabla("PermisosIntermedia");
        }

        // Construye la estructura del Composite en cada llamada
        public PermisoCompuesto ObtenerPermisoCompuesto(string nombrePermiso)
        {
            DataRow[] filas = dtPermisos.Select($"nombrePermiso = '{nombrePermiso}' AND compuesto = true");

            if (filas.Length == 0)
                return null;

            bool esRol = Convert.ToBoolean(filas[0]["esRol"]);
            PermisoCompuesto permisoCompuesto = new PermisoCompuesto(nombrePermiso, esRol);

            // Obtener y agregar sus hijos
            DataRow[] relaciones = dtIntermedia.Select($"nombrePermisoCompuesto = '{nombrePermiso}'");

            foreach (DataRow fila in relaciones)
            {
                string nombreHijo = fila["permisoAñadido"].ToString();
                Permiso hijo = ObtenerPermiso(nombreHijo);
                permisoCompuesto.AgregarPermiso(hijo);
            }
            return permisoCompuesto;
        }

        // Obtiene un permiso (ya sea compuesto o simple)
        public Permiso ObtenerPermiso(string nombrePermiso)
        {
            DataRow[] filas = dtPermisos.Select($"nombrePermiso = '{nombrePermiso}'");

            if (filas.Length == 0)
                return null;

            bool esRol = Convert.ToBoolean(filas[0]["esRol"]);
            bool esCompuesto = Convert.ToBoolean(filas[0]["compuesto"]);

            if (esCompuesto)
                return ObtenerPermisoCompuesto(nombrePermiso);
            else
                return new PermisoSimple(nombrePermiso, esRol);
        }

        // Insertar un nuevo permiso compuesto
        public void InsertarPermisoCompuesto(string nombrePermiso, bool esRol)
        {
            DataRow nuevaFila = dtPermisos.NewRow();
            nuevaFila["nombrePermiso"] = nombrePermiso;
            nuevaFila["compuesto"] = true;
            nuevaFila["esRol"] = esRol;
            dtPermisos.Rows.Add(nuevaFila);
            GuardarCambios();
        }

        public void InsertarRelacion(string nombreCompuesto, List<string> nombresPermisosHijos)
        {
            foreach (string permisoHijo in nombresPermisosHijos)
            {
                DataRow nuevaFila = dtIntermedia.NewRow();
                nuevaFila["nombrePermisoCompuesto"] = nombreCompuesto;
                nuevaFila["permisoAñadido"] = permisoHijo;
                dtIntermedia.Rows.Add(nuevaFila);
            }
            GuardarCambios();
        }

        // Eliminar una relación entre un permiso compuesto y un hijo
        public void EliminarRelacion(string nombreCompuesto, string nombrePermisoHijo)
        {
            foreach (DataRow fila in dtIntermedia.Select($"nombrePermisoCompuesto = '{nombreCompuesto}' AND permisoAñadido = '{nombrePermisoHijo}'"))
            {
                fila.Delete();
            }
            GuardarCambios();
        }

        // Eliminar un permiso compuesto y sus relaciones
        public void EliminarPermisoCompuesto(string nombrePermiso)
        {
            foreach (DataRow fila in dtIntermedia.Select($"nombrePermisoCompuesto = '{nombrePermiso}'"))
            {
                fila.Delete();
            }

            foreach (DataRow fila in dtPermisos.Select($"nombrePermiso = '{nombrePermiso}'"))
            {
                fila.Delete();
            }
            GuardarCambios();
        }

        public List<Permiso> ObtenerTodosLosPermisos()
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            DataRow[] filas = dtPermisos.Select("esRol = false");
            foreach (DataRow fila in filas)
            {
                string nombre = fila["nombrePermiso"].ToString();
                bool esCompuesto = Convert.ToBoolean(fila["compuesto"]);
                if (esCompuesto)
                {
                    listaPermisos.Add(ObtenerPermisoCompuesto(nombre));
                }
                else
                {
                    listaPermisos.Add(new PermisoSimple(nombre, false));
                }
            }
            return listaPermisos;
        }

        public List<Permiso> ObtenerTodosLosRoles()
        {
            List<Permiso> listaRoles = new List<Permiso>();
            DataRow[] filas = dtPermisos.Select("esRol = true AND compuesto = true");
            foreach (DataRow fila in filas)
            {
                string nombre = fila["nombrePermiso"].ToString();
                listaRoles.Add(ObtenerPermisoCompuesto(nombre));   
            }
            return listaRoles;
        }

        public void GuardarCambios()
        {
            dao.Update(dtPermisos);
            dao.Update(dtIntermedia);
        }
    }
}
