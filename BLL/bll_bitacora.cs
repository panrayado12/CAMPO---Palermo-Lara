using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bll_bitacora
    {
        orm_bitacora orm;

        public bll_bitacora()
        {
            orm = new orm_bitacora();
        }

        public void Alta(string modulo, string descripcion, int criticidad)
        {
            string usuario = sessionManager.Gestor.RetornarUsuarioSession();
            string fecha = DateTime.Now.ToString("yyyy-dd-MM");
            string hora = DateTime.Now.ToString("hh:mm:ss");
            orm.Alta(usuario, fecha, hora, modulo, descripcion, criticidad);
        }

        public List<object[]> RetornarBitacora()
        {
            return orm.RetornarBitacora();
        }

        public List<object[]> RetornarConsulta(string usuario, string descripcion, string modulo, string criticidad, string desde, string hasta)
        {
            return orm.Consulta(usuario,descripcion,modulo,criticidad, desde, hasta);
        }
    }
}
