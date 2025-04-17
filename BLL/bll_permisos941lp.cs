using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bll_permisos941lp
    {

        public bll_permisos941lp()
        {

        }

        public PermisoCompuesto941lp ObtenerPermisoCompuesto(string nombrePermiso)
        {
            return orm_permiso941lp.Gestor.ObtenerPermisoCompuesto(nombrePermiso);
        }

        public Permiso941lp ObtenerPermiso(string nombrePermiso)
        {
            return orm_permiso941lp.Gestor.ObtenerPermiso(nombrePermiso);
        }

        public void InsertarPermisoCompuesto(string nombrePermiso, bool esRol)
        {
            orm_permiso941lp.Gestor.InsertarPermisoCompuesto(nombrePermiso, esRol);
        }

        public void InsertarRelacion(string nombreCompuesto, List<string> nombresPermisosHijos)
        {
            orm_permiso941lp.Gestor.InsertarRelacion(nombreCompuesto, nombresPermisosHijos);
        }

        public void EliminarRoles(List<string> nombreRolesEliminados)
        {
            orm_permiso941lp.Gestor.EliminarRoles(nombreRolesEliminados);
        }

        public void EliminarPermisoCompuesto(List<string> nombrePermisosEliminados)
        {
            orm_permiso941lp.Gestor.EliminarPermisoCompuesto(nombrePermisosEliminados);
        }

        public List<Permiso941lp> ObtenerTodosLosPermisosLista()
        {
            return orm_permiso941lp.Gestor.ObtenerTodosLosPermisos();
        }

        public List<string> ObtenerPermisosDeRolEspecificoLista(string rol)
        {
            return orm_permiso941lp.Gestor.ObtenerPermisosDeRolEspecifico(rol);
        }

        public void ModificarNombrePermiso(string nombreNuevoPermiso, string nombreViejoPermiso)
        {
            orm_permiso941lp.Gestor.ModificarNombrePermiso(nombreNuevoPermiso, nombreViejoPermiso);
        }

        public void EliminarPermisoEnIntermedia(List<string> nombrePermiso)
        {
            orm_permiso941lp.Gestor.EliminarPermisosEnIntermedia(nombrePermiso);
        }

        public List<Permiso941lp> ObtenerTodosLosRolesLista()
        {
            return orm_permiso941lp.Gestor.ObtenerTodosLosRoles();
        }
    }
}
