using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class EstadoBitacora : IEstado
    {
        FormularioBitacoraEventos formAdmin;
        GestorDeTraducciones gestorDeTraducciones;

        public EstadoBitacora(GestorDeTraducciones gestor)
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
            formAdmin = new FormularioBitacoraEventos(gestorDeTraducciones);
            formAdmin.ShowDialog();
        }
    }
}
