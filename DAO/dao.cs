using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dao : connectionToSQL
    {
        DataSet dataSet;
        DataTable dt;
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;

        public dao()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=campo1;Integrated Security=True;Encrypt=False");
            dataSet = new DataSet("Sistema");
        }

        // Diccionario para almacenar adaptadores por tabla
        private Dictionary<string, SqlDataAdapter> adapters = new Dictionary<string, SqlDataAdapter>();

        public DataTable RetornarTabla(string tabla)
        {
            adapter = new SqlDataAdapter($"select * from {tabla}", connection);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            adapter.Fill(dataSet, tabla);
            dt = dataSet.Tables[$"{tabla}"];
            if (tabla == "PermisosIntermedia")
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[0], dt.Columns[1] };
            }
            else
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            }
            adapters[tabla] = adapter;
            return dt;
        }

        public void Update(DataTable dt)
        {
            if (!adapters.ContainsKey(dt.TableName))
            {
                throw new Exception($"No se encontró el SqlDataAdapter para la tabla {dt.TableName}");
            }

            SqlDataAdapter adapter = adapters[dt.TableName]; // Usamos el adapter guardado
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();

            adapter.Update(dt);
        }
    }
}
