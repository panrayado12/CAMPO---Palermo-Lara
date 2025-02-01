using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class usuario
    {
        public usuario() { }

        public usuario(string nombreUsuarioP, string contraseñaUsuarioP, string posicionLaboralP,string emailUsuarioP)
        {
            nombreUsuario = nombreUsuarioP;
            contraseñaUsuario = contraseñaUsuarioP;
            rolUsuario = posicionLaboralP;
            emailUsuario = emailUsuarioP;
        }

        public usuario(object[] datos)
        {
            nombreUsuario = datos[0].ToString();
            contraseñaUsuario = datos[1].ToString();
            rolUsuario = datos[2].ToString();
            emailUsuario = datos[3].ToString();
        }

        public string nombreUsuario { get; set; }
        public string contraseñaUsuario { get; set; }
        public string rolUsuario { get; set; }
        public string emailUsuario { get; set; }
        public bool estado  { get; set; }
        public int intentos { get; set; }
    }
}
