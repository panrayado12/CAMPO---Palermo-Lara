using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                string query = $@"
                BACKUP DATABASE [campo1] 
                TO DISK = '{rutaDestino}' 
                WITH FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Backup realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Restore(string rutaBackup)
        {
            string query = $@"
            USE master;
            ALTER DATABASE campo1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE campo1 FROM DISK = '{rutaBackup}' WITH REPLACE, RECOVERY;
            ALTER DATABASE campo1 SET MULTI_USER;";

            using (SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

