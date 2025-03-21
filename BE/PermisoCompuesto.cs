using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoCompuesto : Permiso
    {
        private List<Permiso> listaPermisos;

        public PermisoCompuesto(string pNombrePermiso, bool pEsRol) : base(pNombrePermiso, pEsRol)
        {
            listaPermisos = new List<Permiso>();
        }

        public List<Permiso> ObtenerPermisos()
        {
            return listaPermisos;
        }
        

        //composite en memoria, no maneja la persistencia
        public void AgregarPermiso(Permiso permiso)
        {
            listaPermisos.Add(permiso);
        }

        public void EliminarPermiso(Permiso permiso)
        {
            listaPermisos.Remove(permiso);
        }
    }
}
