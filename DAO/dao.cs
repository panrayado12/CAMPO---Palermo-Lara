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
            return dt;
        }

        public void Update(DataTable dt)
        {
            adapter = new SqlDataAdapter($"select * from {dt.TableName}", connection);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            adapter.Fill(dataSet, dt.TableName);
            adapter.Update(dt);
        }
    }
}
