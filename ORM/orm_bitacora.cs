using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class orm_bitacora
    {
        dao dao;
        DataTable dtBitacora;

        public orm_bitacora()
        {
            dao = new dao();
            dtBitacora = dao.RetornarTabla("Bitacora");
        }

        public void Alta(string usuario, string fecha, string hora, string modulo, string descripcion, int criticidad)
        {
            dtBitacora.Columns["Codigo"].AutoIncrement = true;
            dtBitacora.Columns["Codigo"].AutoIncrementSeed = dtBitacora.Rows.Count + 1; 
            dtBitacora.Columns["Codigo"].AutoIncrementStep = 1;
            DataRow nuevaFila = dtBitacora.NewRow();
            nuevaFila["Usuario"] = usuario;
            nuevaFila["Fecha"] = fecha;
            nuevaFila["Hora"] = hora;
            nuevaFila["Modulo"] = modulo;
            nuevaFila["Descripcion"] = descripcion;
            nuevaFila["Criticidad"] = criticidad;
            dtBitacora.Rows.Add(nuevaFila);
            dao.Update(dtBitacora);
        }

        public List<object[]> RetornarBitacora()
        {
            List<object[]> bitacora = new List<object[]>();
            foreach (DataRow dt in dtBitacora.Rows)
            {
                bitacora.Add(dt.ItemArray);
            }
            return bitacora;
        }

        public List<object[]> Consulta(string usuario, string descripcion, string modulo, string criticidad, string desde, string hasta)
        {
            List<object[]> filtros = new List<object[]>();
            StringBuilder query = new StringBuilder("1=1");
            if (!string.IsNullOrEmpty(usuario))
            {
                query.Append($" AND usuario = '{usuario}'");
            }
            if (!string.IsNullOrEmpty(descripcion))
            {
                query.Append($" AND descripcion LIKE '{descripcion}%'");
            }
            if (!string.IsNullOrEmpty(modulo))
            {
                query.Append($" AND modulo = '{modulo}'");
            }
            if (!string.IsNullOrEmpty(criticidad))
            {
                query.Append($" AND criticidad = {criticidad}");
            }
            if (!string.IsNullOrEmpty(desde) & !string.IsNullOrEmpty(hasta) )
            {
                query.Append($" AND fecha >= '{desde}' and fecha <= '{hasta}'");
            }
            DataRow[] dr = dtBitacora.Select(query.ToString());
            foreach (DataRow dr2 in dr)
            {
                filtros.Add(dr2.ItemArray);
            }
            return filtros;
        }
    }
}
