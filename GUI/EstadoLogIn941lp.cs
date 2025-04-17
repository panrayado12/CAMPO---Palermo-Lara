using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoLogIn941lp : IEstado941lp
    {
        FormularioLogIn941lp login;

        public void CerrarEstado()
        {
            login?.Dispose();
        }

        public void EjecutarEstado()
        {
            login = new FormularioLogIn941lp();
            login.ShowDialog();
        }
    }
}
