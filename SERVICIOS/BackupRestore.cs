using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class BackupRestore
    {
        private string connectionString;

        public BackupRestore()
        {
            this.connectionString = "Data Source=.;Initial Catalog=campo1;Integrated Security=True";
        }

        public void BackUp(string rutaDestino)
        {
            string query = $"BACKUP DATABASE [campo1] TO DISK = '{rutaDestino}' WITH FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Restore(string rutaBackup)
        {
            string query = $"RESTORE DATABASE [NombreBaseDatos] FROM DISK = '{rutaBackup}' WITH REPLACE";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

