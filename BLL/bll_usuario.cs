using BE;
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

        public void Alta(string nombreUsuario, string contraseñaUsuario,string nombre, string apellido, string rol, string emailUsuario, bool estado, int intentos)
        {
            orm.AltaUsuario(nombreUsuario, contraseñaUsuario, nombre, apellido, rol, emailUsuario, estado, intentos);
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            return orm.ValidarUsuario(nombreUsuario, contraseñaUsuario);
        }

        public void Baja(Usuario usuario)
        {
            orm.Baja(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            orm.Modificar(usuario);
        }

        public List<Usuario> RetornarUsuarios()
        {
            return orm.RetornarUsuarios();
        }

        public void BloquearDesbloquearUsuario(Usuario usuario)
        {
            orm.BloquearDesbloquearUsuario(usuario);
        }
    }
}
