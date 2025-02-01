using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bll_usuario
    {
        orm_usuario orm;
        public bll_usuario()
        {
            orm = new orm_usuario();
        }

        public void Alta(string nombreUsuario, string contraseñaUsuario, string posicionLaboral, string emailUsuario)
        {
            orm.AltaUsuario(nombreUsuario, contraseñaUsuario, posicionLaboral, emailUsuario);
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            return orm.ValidarUsuario(nombreUsuario, contraseñaUsuario);
        }
    }
}
