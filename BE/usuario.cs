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

        public Usuario(string pDni, string nombreUsuarioP,string nombreP, string apellidoP, string contraseñaUsuarioP, string rolP,string emailUsuarioP, bool estadoP, int intentosP, string pLenguaje)
        {
            dni = pDni;
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
            dni = datos[0].ToString();
            nombreUsuario = datos[1].ToString();
            contraseñaUsuario = datos[2].ToString();
            nombre = datos[3].ToString();
            apellido = datos[4].ToString();
            rolUsuario = datos[5].ToString();
            emailUsuario = datos[6].ToString();
            estado = Convert.ToBoolean(datos[7]);
            intentos = Convert.ToInt32(datos[8]);
            lenguaje = datos[9].ToString();
        }

        public string dni { get; set; }
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
