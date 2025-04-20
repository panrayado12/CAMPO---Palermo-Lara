using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORM
{
    public class orm_usuario941lp
    {
        dao941lp dao;
        DataTable dtUsuario;

        public orm_usuario941lp()
        {
            dao = new dao941lp();
            dtUsuario = dao.RetornarTabla("Usuario941lp");
        }

        public void AltaUsuario(Usuario941lp usuario)
        {   
            dtUsuario.Rows.Add(dtUsuario.NewRow().ItemArray = new object[] { usuario.dni, usuario.nombreUsuario, usuario.contraseñaUsuario,usuario.nombre,usuario.apellido, usuario.rolUsuario, usuario.emailUsuario, usuario.bloqueo, usuario.intentos, usuario.lenguaje, usuario.activo });
            dao.Update(dtUsuario);
        }

        public bool ValidarExistenciaUsuario(string dni, string nombreUsuario)
        {
            bool existe = true;
            DataRow fila = dtUsuario.Rows.Find($"dni941lp = '{dni}'");
            if (fila != null)
            {
                MessageBox.Show("DNI repetido");
            }
            else if(fila["nombreUsuario"] == nombreUsuario)
            {
                MessageBox.Show("Nombre de usuario repetido");
            }
            else
            {
                existe = false;
            }
                return existe;
        }

        public bool ValidarContraseñaActual(string dni, string contraseña)
        {
            bool existe = false;
            if(dtUsuario.Rows.Find(dni)["contraseña941lp"].ToString() == contraseña)
            {
                existe =true;
            }
            return existe;
        }

        public void Modificar(Usuario941lp usuario)
        {
            DataRow dr = dtUsuario.Rows.Find(usuario.dni);
            dr.ItemArray = new object[] { dr.Field<string>(0), dr.Field<string>(1), usuario.contraseñaUsuario, usuario.nombre, usuario.apellido, usuario.rolUsuario, usuario.emailUsuario, usuario.bloqueo, usuario.intentos, usuario.lenguaje, usuario.activo};
            dao.Update(dtUsuario);
        }

        public bool ValidarUsuario( string nombreUsuario, string contraseñaUsuario)
        {
            bool existe = false;
            string dni = null;
            DataRow fila = dtUsuario.Select($"nombreUsuario941lp = '{nombreUsuario}'").FirstOrDefault(); 
            if (fila!=null)
            {
                dni = fila["dni941lp"].ToString();
                if(dtUsuario.Rows.Find(dni)["contraseña941lp"].ToString() == contraseñaUsuario)
                {
                    existe = true;
                }
                else
                {
                    AumentarIntentos(dni);
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
            return existe;
        }

        private void AumentarIntentos(string dni)
        {
            DataRow usuario = dtUsuario.Rows.Find(dni);
            int intentos = (int)usuario["intentos941lp"];
            if (intentos < 3)
            {
                MessageBox.Show("Contraseña incorrecta");
                if (!(dtUsuario.Rows.Find(dni)["rol941lp"].ToString() == "Administrador"))
                {
                    usuario["intentos941lp"] = intentos + 1;
                    dao.Update(dtUsuario);
                }
            }
            else
            {
                MessageBox.Show("Usuario bloqueado");
            }
        }

        public List<Usuario941lp> RetornarUsuarios()
        {
            List<Usuario941lp> listaUsuarios = new List<Usuario941lp>();
            foreach (DataRow dr in dtUsuario.Rows)
            {
                listaUsuarios.Add(new Usuario941lp(dr.ItemArray));
            }
            return listaUsuarios;
        }
    }
}
