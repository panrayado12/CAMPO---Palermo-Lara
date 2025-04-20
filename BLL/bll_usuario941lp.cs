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
    public class bll_usuario941lp
    {
        orm_usuario941lp orm;
        seguridad941lp seguridad;
        public bll_usuario941lp()
        {
            orm = new orm_usuario941lp();
            seguridad = new seguridad941lp();
        }

        public void Alta(Usuario941lp usuario)
        {
            try
            {
                if (!(orm.ValidarExistenciaUsuario(usuario.dni, usuario.nombreUsuario)))
                { 
                    usuario.contraseñaUsuario = seguridad.GetSHA256(usuario.contraseñaUsuario);
                    orm.AltaUsuario(usuario);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            string contraseñaHasheada = seguridad.GetSHA256(contraseñaUsuario);
            return orm.ValidarUsuario(nombreUsuario, contraseñaHasheada);
        }

        public bool ValidarContraseñaUsuario(string dni, string contraseña)
        {
            string contraseñaHasheada = seguridad.GetSHA256(contraseña);
            return orm.ValidarContraseñaActual(dni, contraseñaHasheada);
        }

        public void Baja(Usuario941lp usuario)
        {
            usuario.nombreUsuario = seguridad.Encrypt(usuario.nombreUsuario);
            orm.Modificar(usuario);
        }

        public void Modificar(Usuario941lp usuario)
        {
            orm.Modificar(usuario);
        }

        public void ModificarContraseña(Usuario941lp usuario)
        {
            usuario.contraseñaUsuario = seguridad.GetSHA256(usuario.contraseñaUsuario);
            orm.Modificar(usuario);
        }

        public List<Usuario941lp> RetornarUsuarios()
        {
            List<Usuario941lp> usuarios = orm.RetornarUsuarios();
            return usuarios;
        }
    }
}
