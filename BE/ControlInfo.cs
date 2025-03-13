using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ControlInfo
    {
        public ControlInfo(string nombre, string texto)
        {
            Nombre = nombre;
            Texto = texto;
        }

        public string Nombre { get; set; }
        public string Texto { get; set; }
    }
}
