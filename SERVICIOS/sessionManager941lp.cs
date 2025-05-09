﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class sessionManager941lp
    {
        public string usuarioSession;
        public string usuarioIdioma = "es";
        public string usuarioRol;
        private static sessionManager941lp instance;

        public static sessionManager941lp Gestor
        {
            get 
            { 
                if (instance == null)
                { 
                    instance = new sessionManager941lp(); 
                } 
                return instance;
            }
        }

        public string RetornarUsuarioSession()
        {
            return usuarioSession;
        }

        public string RetornarUsuarioRol()
        {
            return usuarioRol;
        }

        public string RetornarIdiomaDeUsuario()
        {
            return usuarioIdioma;
        }

        public void LogIn(Usuario941lp usuario)
        {
            if(Gestor.usuarioSession == null)
            {
                usuarioSession = usuario.nombreUsuario;
                usuarioIdioma = usuario.lenguaje;
                usuarioRol = usuario.rolUsuario;
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
