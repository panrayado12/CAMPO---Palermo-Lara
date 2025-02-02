using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class sessionManager
    {
        public Usuario usuarioSession;
        private static sessionManager instance;

        public static sessionManager Gestor
        {
            get 
            { 
                if (instance == null)
                { 
                    instance = new sessionManager(); 
                } 
                return instance;
            }
        }

        public void LogIn(Usuario usuarioLogIn)
        {
            if(Gestor.usuarioSession == null)
            {
                Gestor.usuarioSession = usuarioLogIn;
            }
        }

        public void LogOut()
        {
            if(Gestor.usuarioSession!=null)
            {
                Gestor.usuarioSession = null;
            }
        }
    }
}
