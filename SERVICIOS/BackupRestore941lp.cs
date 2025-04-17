using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICIOS
{
    public class BackupRestore941lp
    {
        private string connectionString;

        public BackupRestore941lp()
        {
            this.connectionString = "Data Source=.;Initial Catalog=sistAdopcion941lp;Integrated Security=True";
        }

        public void BackUp(string rutaDestino)
        {
            try
            {
                string query = $@"
                BACKUP DATABASE [sistAdopcion941lp] 
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
            ALTER DATABASE sistAdopcion941lp SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE sistAdopcion941lp FROM DISK = '{rutaBackup}' WITH REPLACE, RECOVERY;
            ALTER DATABASE sistAdopcion941lp SET MULTI_USER;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

