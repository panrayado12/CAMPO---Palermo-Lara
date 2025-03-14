using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nombreUsuarioP,string nombreP, string apellidoP, string contraseñaUsuarioP, string rolP,string emailUsuarioP, bool estadoP, int intentosP, string pLenguaje)
        {
            nombreUsuario = nombreUsuarioP;
            contraseñaUsuario = contraseñaUsuarioP;
            nombre = nombreP;
            apellido = apellidoP;
            rolUsuario = rolP;
            emailUsuario = emailUsuarioP;
            estado = estadoP;
            intentos = intentosP;
            lenguaje = pLenguaje;
        }

        public Usuario(object[] datos)
        {
            nombreUsuario = datos[0].ToString();
            contraseñaUsuario = datos[1].ToString();
            nombre = datos[2].ToString();
            apellido = datos[3].ToString();
            rolUsuario = datos[4].ToString();
            emailUsuario = datos[5].ToString();
            estado = Convert.ToBoolean(datos[6]);
            intentos = Convert.ToInt32(datos[7]);
            lenguaje = datos[8].ToString();
        }

        public string nombreUsuario { get; set; }
        public string contraseñaUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string rolUsuario { get; set; }
        public string emailUsuario { get; set; }
        public bool estado  { get; set; }
        public int intentos { get; set; }
        public string lenguaje { get; set; }
    }
}
