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
            dtBitacora.Columns["Codigo"].AutoIncrementSeed = 1; 
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
    }
}
