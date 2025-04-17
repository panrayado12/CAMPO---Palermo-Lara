using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoCompuesto941lp : Permiso941lp
    {
        private List<Permiso941lp> listaPermisos;

        public PermisoCompuesto941lp(string pNombrePermiso, bool pEsRol) : base(pNombrePermiso, pEsRol)
        {
            listaPermisos = new List<Permiso941lp>();
        }

        public List<Permiso941lp> ObtenerPermisos()
        {
            return listaPermisos;
        }
        

        //composite en memoria, no maneja la persistencia
        public void AgregarPermiso(Permiso941lp permiso)
        {
            listaPermisos.Add(permiso);
        }

        public void EliminarPermiso(Permiso941lp permiso)
        {
            listaPermisos.Remove(permiso);
        }
    }
}
