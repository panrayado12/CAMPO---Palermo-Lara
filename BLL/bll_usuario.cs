using BE;
using Microsoft.VisualBasic;
using ORM;
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
        bll_irreversible bllIrreversible;
        bll_reversible bllReversible;
        public bll_usuario()
        {
            orm = new orm_usuario();
            bllIrreversible = new bll_irreversible();
            bllReversible = new bll_reversible();
        }

        public void Alta(string nombreUsuario, string contraseñaUsuario,string nombre, string apellido, string rol, string emailUsuario, bool estado, int intentos)
        {
            try
            {
                string nombreUsuarioCifrado = bllReversible.Encrypt(nombreUsuario);
                string contraseñaHasheada = bllIrreversible.GetSHA256(contraseñaUsuario);
                if (ValidarUsuario(nombreUsuarioCifrado, contraseñaHasheada) == true) throw new Exception("Usuario ya existente");
                orm.AltaUsuario(nombreUsuarioCifrado, contraseñaHasheada, nombre, apellido, rol, emailUsuario, estado, intentos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            string nombreUsuarioCifrado = bllReversible.Encrypt(nombreUsuario);
            string contraseñaHasheada = bllIrreversible.GetSHA256(contraseñaUsuario);
            return orm.ValidarUsuario(nombreUsuarioCifrado, contraseñaHasheada);
        }

        public void Baja(Usuario usuario)
        {
            orm.Baja(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            usuario. nombreUsuario = bllReversible.Encrypt(usuario.nombreUsuario);
            usuario.contraseñaUsuario = bllIrreversible.GetSHA256(Interaction.InputBox("Ingrese la nueva contraseña: ", "NUEVA CONTRASEÑA"));
            orm.Modificar(usuario);
        }

        public List<Usuario> RetornarUsuarios()
        {
            List<Usuario> usuarios = orm.RetornarUsuarios();
            // 🔹 Desencriptar el nombre de usuario antes de enviarlo a la GUI
            foreach (var usuario in usuarios)
            {
                usuario.nombreUsuario = bllReversible.Decrypt(usuario.nombreUsuario);
            }
            return usuarios;
        }

        public void BloquearDesbloquearUsuario(Usuario usuario)
        {
            orm.BloquearDesbloquearUsuario(usuario);
        }

        public bool RetornarEstadoDeUsuario(Usuario usuario)
        {
            return orm.EstadoDeUsuario(usuario);
        }
    }
}
