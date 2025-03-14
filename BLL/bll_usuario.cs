using BE;
using Microsoft.VisualBasic;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bll_usuario
    {
        orm_usuario orm;
        seguridad seguridad;
        public bll_usuario()
        {
            orm = new orm_usuario();
            seguridad = new seguridad();
        }

        public void Alta(string nombreUsuario, string contraseñaUsuario,string nombre, string apellido, string rol, string emailUsuario, bool estado, int intentos, string lenguaje)
        {
            try
            {
                string nombreUsuarioCifrado = seguridad.Encrypt(nombreUsuario);
                string contraseñaHasheada = seguridad.GetSHA256(contraseñaUsuario);
                if (ValidarUsuario(nombreUsuarioCifrado, contraseñaHasheada) == true) throw new Exception("Usuario ya existente");
                orm.AltaUsuario(nombreUsuarioCifrado, contraseñaHasheada, nombre, apellido, rol, emailUsuario, estado, intentos, lenguaje);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            string nombreUsuarioCifrado = seguridad.Encrypt(nombreUsuario);
            string contraseñaHasheada = seguridad.GetSHA256(contraseñaUsuario);
            return orm.ValidarUsuario(nombreUsuarioCifrado, contraseñaHasheada);
        }

        public void Baja(Usuario usuario)
        {
            usuario.nombreUsuario = seguridad.Encrypt(usuario.nombreUsuario);
            orm.Baja(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            usuario. nombreUsuario = seguridad.Encrypt(usuario.nombreUsuario);
            usuario.contraseñaUsuario = seguridad.GetSHA256(Interaction.InputBox("Ingrese la nueva contraseña: ", "NUEVA CONTRASEÑA"));
            orm.Modificar(usuario);
        }

        public List<Usuario> RetornarUsuarios()
        {
            List<Usuario> usuarios = orm.RetornarUsuarios();
            // 🔹 Desencriptar el nombre de usuario antes de enviarlo a la GUI
            foreach (var usuario in usuarios)
            {
                usuario.nombreUsuario = seguridad.Decrypt(usuario.nombreUsuario);
            }
            return usuarios;
        }

        public void BloquearDesbloquearUsuario(Usuario usuario)
        {
            usuario.nombreUsuario = seguridad.Encrypt(usuario.nombreUsuario);
            orm.BloquearDesbloquearUsuario(usuario);
        }

        public bool RetornarEstadoDeUsuario(Usuario usuario)
        {
            return orm.EstadoDeUsuario(usuario);
        }
    }
}
