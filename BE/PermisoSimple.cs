﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string pNombrePermiso, bool pEsRol) : base(pNombrePermiso, pEsRol)
        {
        }
    }
}
