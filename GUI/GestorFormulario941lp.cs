using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class GestorFormulario941lp
    {
        private static GestorFormulario941lp instance;
        private IEstado941lp estadoActual;
        public static GestorFormulario941lp gestorFormSG
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestorFormulario941lp();
                }
                return instance;
            }
        }

        public void DefinirEstado(IEstado941lp estadoNuevo)
        {
            estadoActual?.CerrarEstado();
            estadoActual = estadoNuevo;
            estadoActual.EjecutarEstado();
        }
    }
}
