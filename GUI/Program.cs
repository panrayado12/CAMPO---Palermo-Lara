using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GestorDeTraducciones gestorDeTraducciones = new GestorDeTraducciones();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GestorFormulario.gestorFormSG.DefinirEstado(new EstadoLogIn(gestorDeTraducciones));
        }
    }
}
