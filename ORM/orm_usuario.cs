using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AltaUsuario(string nombreUsuario, string contraseñaUsuario, string posicionLaboral, string emailUsuario)
        {
            dtUsuario.Rows.Add(dtUsuario.NewRow().ItemArray = new object[] { nombreUsuario, contraseñaUsuario, posicionLaboral, emailUsuario });   
        }

        public bool ValidarUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            bool existe = false;
            if(dtUsuario.Rows.Find(nombreUsuario)!=null  && dtUsuario.Rows.Find(nombreUsuario)[1].ToString() == contraseñaUsuario)
            {
                existe = true;
            }
            return existe;
        }

        public List<usuario> RetornarUsuarios(string tipoConsulta=" ",string campo = " ",string valor1 = " ", string valor2 = " " )
        {
            
        }
    }
}
