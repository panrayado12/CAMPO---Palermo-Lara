using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bll_BackupRestore
    {
        BackupRestore backupRestore;

        public bll_BackupRestore()
        {
            backupRestore = new BackupRestore();
        }

        public void BackUp(string rutaDestino)
        {
            backupRestore.BackUp(rutaDestino);
        }

        public void Restore(string rutaDestino)
        {
            backupRestore.Restore(rutaDestino);
        }
    }
}
