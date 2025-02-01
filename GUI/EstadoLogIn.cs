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
        public void CerrarEstado()
        {
            login?.Dispose();
        }

        public void EjecutarEstado()
        {
            login = new FormularioLogIn();
            login.ShowDialog();
        }
    }
}
