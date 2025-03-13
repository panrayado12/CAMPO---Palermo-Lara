using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoLogIn : IEstado
    {
        FormularioLogIn login;
        private GestorDeTraducciones gestorDeTraducciones;

        public EstadoLogIn(GestorDeTraducciones gestor)
        {
            // Aquí inicializas el gestor de traducciones
            gestorDeTraducciones = gestor;
        }

        public void CerrarEstado()
        {
            login?.Dispose();
        }

        public void EjecutarEstado()
        {
            login = new FormularioLogIn(gestorDeTraducciones);
            login.ShowDialog();
        }
    }
}
