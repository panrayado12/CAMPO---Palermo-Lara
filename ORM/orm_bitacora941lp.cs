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
    public class orm_bitacora941lp
    {
        dao941lp dao;
        DataTable dtBitacora;

        public orm_bitacora941lp()
        {
            dao = new dao941lp();
            dtBitacora = dao.RetornarTabla("Bitacora941lp");
        }

        public void Alta(string usuario, string fecha, string hora, string modulo, string descripcion, int criticidad)
        {
            dtBitacora.Columns["numBitacora941lp"].AutoIncrement = true;
            dtBitacora.Columns["numBitacora941lp"].AutoIncrementSeed = dtBitacora.Rows.Count + 1; 
            dtBitacora.Columns["numBitacora941lp"].AutoIncrementStep = 1;
            DataRow nuevaFila = dtBitacora.NewRow();
            nuevaFila["Usuario941lp"] = usuario;
            nuevaFila["Fecha941lp"] = fecha;
            nuevaFila["Hora941lp"] = hora;
            nuevaFila["Modulo941lp"] = modulo;
            nuevaFila["Descripcion941lp"] = descripcion;
            nuevaFila["Criticidad941lp"] = criticidad;
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
                query.Append($" AND usuario941lp = '{usuario}'");
            }
            if (!string.IsNullOrEmpty(descripcion))
            {
                query.Append($" AND descripcion941lp LIKE '{descripcion}%'");
            }
            if (!string.IsNullOrEmpty(modulo))
            {
                query.Append($" AND modulo941lp = '{modulo}'");
            }
            if (!string.IsNullOrEmpty(criticidad))
            {
                query.Append($" AND criticidad941lp = {criticidad}");
            }
            if (!string.IsNullOrEmpty(desde) & !string.IsNullOrEmpty(hasta) )
            {
                query.Append($" AND fech941lpa >= '{desde}' and fecha941lp <= '{hasta}'");
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
