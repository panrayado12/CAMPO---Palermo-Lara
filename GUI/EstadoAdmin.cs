using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoAdmin : IEstado
    {
        FormAdministradorUsuario formAdmin;
        GestorDeTraducciones gestorDeTraducciones;

        public EstadoAdmin(GestorDeTraducciones gestor)
        {
            // Aquí inicializas el gestor de traducciones
            gestorDeTraducciones = gestor;
        }

        public void CerrarEstado()
        {
            formAdmin?.Dispose();
        }

        public void EjecutarEstado()
        {
            formAdmin = new FormAdministradorUsuario(gestorDeTraducciones);
            formAdmin.ShowDialog();
        }
    }
}
