using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoMenu941lp : IEstado941lp
    {
        FormularioMenu941lp menu;

        public void CerrarEstado()
        {
            menu?.Dispose();
        }

        public void EjecutarEstado()
        {
            menu = new FormularioMenu941lp();
            menu.ShowDialog();
        }
    }
}
