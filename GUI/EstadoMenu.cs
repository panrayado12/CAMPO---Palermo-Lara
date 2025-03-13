using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoMenu : IEstado
    {
        FormularioMenu menu;
        GestorDeTraducciones gestorDeTraducciones;

        public EstadoMenu(GestorDeTraducciones gestor)
        {
            // Aquí inicializas el gestor de traducciones
            gestorDeTraducciones = gestor;
        }

        public void CerrarEstado()
        {
            menu?.Dispose();
        }

        public void EjecutarEstado()
        {
            menu = new FormularioMenu(gestorDeTraducciones);
            menu.ShowDialog();
        }
    }
}
