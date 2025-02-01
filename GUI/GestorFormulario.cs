using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class GestorFormulario
    {
        private static GestorFormulario instance;
        private IEstado estadoActual;
        public static GestorFormulario gestorFormSG
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestorFormulario();
                }
                return instance;
            }
        }

        public void DefinirEstado(IEstado estadoNuevo)
        {
            estadoActual?.CerrarEstado();
            estadoActual = estadoNuevo;
            estadoActual.EjecutarEstado();
        }
    }
}
