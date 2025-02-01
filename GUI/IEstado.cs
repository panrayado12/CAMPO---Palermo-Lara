﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal interface IEstado
    {
        void CerrarEstado();

        void EjecutarEstado();
    }
}
