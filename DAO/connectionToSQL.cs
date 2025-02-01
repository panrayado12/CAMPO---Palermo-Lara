using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public abstract class connectionToSQL
    {
        private readonly string connection;

        public connectionToSQL()
        {
            connection = "Data Source=.;Initial Catalog=campo1;Integrated Security=True;Encrypt=False";
        }

        protected SqlConnection RetornarConexion()
        {
            return new SqlConnection(connection);
        }
    }
}
