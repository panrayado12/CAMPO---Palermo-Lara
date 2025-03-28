using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bll_permisos
    {

        public bll_permisos()
        {

        }

        public PermisoCompuesto ObtenerPermisoCompuesto(string nombrePermiso)
        {
            return orm_permiso.Gestor.ObtenerPermisoCompuesto(nombrePermiso);
        }

        public Permiso ObtenerPermiso(string nombrePermiso)
        {
            return orm_permiso.Gestor.ObtenerPermiso(nombrePermiso);
        }

        public void InsertarPermisoCompuesto(string nombrePermiso, bool esRol)
        {
            orm_permiso.Gestor.InsertarPermisoCompuesto(nombrePermiso, esRol);
        }

        public void InsertarRelacion(string nombreCompuesto, List<string> nombresPermisosHijos)
        {
            orm_permiso.Gestor.InsertarRelacion(nombreCompuesto, nombresPermisosHijos);
        }

        public void EliminarRoles(List<string> nombreRolesEliminados)
        {
            orm_permiso.Gestor.EliminarRoles(nombreRolesEliminados);
        }

        public void EliminarPermisoCompuesto(List<string> nombrePermisosEliminados)
        {
            orm_permiso.Gestor.EliminarPermisoCompuesto(nombrePermisosEliminados);
        }

        public List<Permiso> ObtenerTodosLosPermisosLista()
        {
            return orm_permiso.Gestor.ObtenerTodosLosPermisos();
        }

        public void ModificarNombrePermiso(string nombreNuevoPermiso, string nombreViejoPermiso)
        {
            orm_permiso.Gestor.ModificarNombrePermiso(nombreNuevoPermiso, nombreViejoPermiso);
        }

        public void EliminarPermisoEnIntermedia(List<string> nombrePermiso)
        {
            orm_permiso.Gestor.EliminarPermisosEnIntermedia(nombrePermiso);
        }

        public List<Permiso> ObtenerTodosLosRolesLista()
        {
            return orm_permiso.Gestor.ObtenerTodosLosRoles();
        }
    }
}
