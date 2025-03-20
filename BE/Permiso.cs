using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso 
    {
        private string pNombrePermiso;

        public Permiso(string pNombrePermiso, bool pEsRol)
        {
            nombrePermiso = pNombrePermiso;
            esRol = pEsRol;
        }

        public string nombrePermiso { get; set; }
        public  bool esRol { get; set; }
    }
}
