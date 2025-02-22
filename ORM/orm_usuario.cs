using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORM
{
    public class orm_usuario
    {
        dao dao;
        DataTable dtUsuario;

        public orm_usuario()
        {
            dao = new dao();
            dtUsuario = dao.RetornarTabla("Usuario");
        }

        public void AltaUsuario(string nombreUsuario, string contraseñaUsuario,string nombre, string apellido, string rol, string emailUsuario,bool estado, int intentos)
        {
            dtUsuario.Rows.Add(dtUsuario.NewRow().ItemArray = new object[] { nombreUsuario, contraseñaUsuario,nombre,apellido, rol, emailUsuario, estado, intentos });
            dao.Update(dtUsuario);
        }

        public void Baja(Usuario usuario)
        {
            dtUsuario.Rows.Find(usuario.nombreUsuario).Delete();
            dao.Update(dtUsuario);
        }

        public void Modificar(Usuario usuario)
        {
            DataRow dr = dtUsuario.Rows.Find(usuario.nombreUsuario);
            dr.ItemArray = new object[] { dr.Field<string>(0), usuario.contraseñaUsuario, usuario.nombre, usuario.apellido, usuario.rolUsuario, usuario.emailUsuario, usuario.estado, usuario.intentos};
            dao.Update(dtUsuario);
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            bool existe = false;
            if (dtUsuario.Rows.Find(nombreUsuario)!=null)
            {
                if(dtUsuario.Rows.Find(nombreUsuario)["contraseña"].ToString() == contraseñaUsuario)
                {
                    existe = true;
                }
                else
                {
                    DataRow usuario = dtUsuario.Rows.Find(nombreUsuario);
                    int intentos = (int)usuario[7];
                    if(intentos < 3)
                    {
                        usuario[7] = intentos + 1;
                        dao.Update(dtUsuario);
                    }
                    else
                    {
                        MessageBox.Show("Usuario bloqueado");
                    }
                }
            }
            return existe;
        }


        public List<Usuario> RetornarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            foreach (DataRow dr in dtUsuario.Rows)
            {
                listaUsuarios.Add(new Usuario(dr.ItemArray));
            }
            return listaUsuarios;
        }

        public void BloquearDesbloquearUsuario(Usuario usuario)
        {
            DataRow usuarioModificable = dtUsuario.Rows.Find(usuario.nombreUsuario);
            if(usuario.estado == true)
            {
                usuarioModificable[6] = false;
            }
            else
            {
                usuarioModificable[6] = true;
                usuarioModificable[7] = 0;
            }
            dao.Update(dtUsuario);
        }

        public bool EstadoDeUsuario(Usuario usuario)
        {
            bool activo = false;
            if(usuario.intentos>3)
            {
                activo = true;
            }
            return activo;
        }
    }
}
