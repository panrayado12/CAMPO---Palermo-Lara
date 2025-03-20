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
        dao dao;
        DataTable dtPermisos;
        DataTable dtIntermedia;
        private Dictionary<string, PermisoCompuesto> _cacheCompuestos; // Solo almacena compuestos

        public orm_permiso()
        {
            _cacheCompuestos = new Dictionary<string, PermisoCompuesto>();
            dtPermisos = dao.RetornarTabla("Permisos");
            ConstruirEstructuraComposite();
        }

        // Construye la estructura en memoria
        private void ConstruirEstructuraComposite()
        {
            // Crear solo permisos compuestos en memoria
            foreach (DataRow fila in dtPermisos.Rows)
            {
                string nombre = fila["nombrePermiso"].ToString();
                bool esRol = Convert.ToBoolean(fila["esRol"]);
                bool esCompuesto = Convert.ToBoolean(fila["compuesto"]);

                if (esCompuesto)
                    _cacheCompuestos[nombre] = new PermisoCompuesto(nombre, esRol);
            }

            // Agregar relaciones (hijos) a los compuestos
            foreach (DataRow fila in dtIntermedia.Rows)
            {
                string nombreCompuesto = fila["nombrePermisoCompuesto"].ToString();
                string nombrePermisoHijo = fila["permisoAñadido"].ToString();

                if (_cacheCompuestos.ContainsKey(nombreCompuesto))
                {
                    PermisoCompuesto compuesto = _cacheCompuestos[nombreCompuesto];

                    // Buscar el permiso hijo en caché o crear un PermisoSimple
                    Permiso permisoHijo;
                    if (_cacheCompuestos.ContainsKey(nombrePermisoHijo))
                    {
                        permisoHijo = _cacheCompuestos[nombrePermisoHijo]; // Es un PermisoCompuesto
                    }
                    else
                    {
                        permisoHijo = new PermisoSimple(nombrePermisoHijo, false); // Asumimos que no es rol
                    }

                    compuesto.AgregarPermiso(permisoHijo); // Ahora sí recibe un Permiso válido
                }
            }
        }

        // Insertar un nuevo Permiso Compuesto
        public void InsertarPermisoCompuesto(string nombrePermiso, bool esRol)
        {
            DataTable tabla = _dataSet.Tables["Permisos"];
            DataRow nuevaFila = tabla.NewRow();
            nuevaFila["nombrePermiso"] = nombrePermiso;
            nuevaFila["esRol"] = esRol;
            nuevaFila["esCompuesto"] = true;
            tabla.Rows.Add(nuevaFila);

            // Agregarlo en la estructura en memoria
            _cacheCompuestos[nombrePermiso] = new PermisoCompuesto(nombrePermiso, esRol);
        }

        // Agregar un permiso a un compuesto (Composite)
        public void InsertarRelacion(string nombreCompuesto, string permisoHijo)
        {
            DataTable tabla = _dataSet.Tables["PermisosIntermedios"];
            DataRow nuevaFila = tabla.NewRow();
            nuevaFila["nombrePermisoCompuesto"] = nombreCompuesto;
            nuevaFila["permisoAñadido"] = permisoHijo;
            tabla.Rows.Add(nuevaFila);

            // Agregarlo en memoria
            if (_cacheCompuestos.ContainsKey(nombreCompuesto))
            {
                _cacheCompuestos[nombreCompuesto].Agregar(permisoHijo);
            }
        }

        // Eliminar una relación de un permiso compuesto (Composite)
        public void EliminarRelacion(string nombreCompuesto, string permisoHijo)
        {
            DataTable tablaIntermedia = _dataSet.Tables["PermisosIntermedios"];
            foreach (DataRow fila in tablaIntermedia.Select($"nombrePermisoCompuesto = '{nombreCompuesto}' AND permisoAñadido = '{permisoHijo}'"))
            {
                fila.Delete();
            }

            // Eliminar en memoria
            if (_cacheCompuestos.ContainsKey(nombreCompuesto))
            {
                _cacheCompuestos[nombreCompuesto].Eliminar(permisoHijo);
            }
        }

        // Eliminar un Permiso Compuesto y sus relaciones
        public void EliminarPermisoCompuesto(string nombrePermiso)
        {
            DataTable tablaIntermedia = _dataSet.Tables["PermisosIntermedios"];
            DataTable tablaPermisos = _dataSet.Tables["Permisos"];

            // Eliminar relaciones
            foreach (DataRow fila in tablaIntermedia.Select($"nombrePermisoCompuesto = '{nombrePermiso}'"))
            {
                fila.Delete();
            }

            // Eliminar el permiso compuesto
            foreach (DataRow fila in tablaPermisos.Select($"nombrePermiso = '{nombrePermiso}'"))
            {
                fila.Delete();
            }

            // Eliminar de la estructura en memoria
            _cacheCompuestos.Remove(nombrePermiso);
        }

        // Obtener un Permiso Compuesto con sus componentes
        public PermisoCompuesto ObtenerPermisoCompuesto(string nombrePermiso)
        {
            return _cacheCompuestos.ContainsKey(nombrePermiso) ? _cacheCompuestos[nombrePermiso] : null;
        }

        // Guardar cambios en la base de datos
        public void GuardarCambios()
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                _adapterPermisos.Update(_dataSet, "Permisos");
                _adapterIntermedios.Update(_dataSet, "PermisosIntermedios");
            }
        }
    }
}
