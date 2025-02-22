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
        public void CerrarEstado()
        {
            formAdmin?.Dispose();
        }

        public void EjecutarEstado()
        {
            formAdmin = new FormularioBitacoraEventos();
            formAdmin.ShowDialog();
        }
    }
}
