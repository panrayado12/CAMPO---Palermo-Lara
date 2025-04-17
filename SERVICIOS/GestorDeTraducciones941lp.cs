using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICIOS
{
    public class GestorDeTraducciones941lp
    {
        private traductor941lp servicioTraduccion;
        private List<IObservadorTraduccion941lp> observadores;

        private static GestorDeTraducciones941lp instance;
        public static GestorDeTraducciones941lp Gestor
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestorDeTraducciones941lp();
                }
                return instance;
            }
        }

        public GestorDeTraducciones941lp()
        {
            servicioTraduccion = new traductor941lp();
            observadores = new List<IObservadorTraduccion941lp>();
        }

        public void RegistrarObservador(IObservadorTraduccion941lp observador)
        {
            if (!observadores.Contains(observador))
            {
                observadores.Add(observador);
            }
        }

        public void NotificarCambioIdioma()
        {
            foreach (var observador in observadores)
            {
                observador.ActualizarTraduccion();
            }
        }

        public void RegistrarControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (!string.IsNullOrEmpty(control.Name))
                {
                    servicioTraduccion.RegistrarControlSiNoExiste(control.Name, control.Text);
                }

                if (control.HasChildren)
                {
                    RegistrarControles(control);
                }
            }
        }

        public void TraducirControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (!string.IsNullOrEmpty(control.Name))
                {
                    control.Text = servicioTraduccion.Traducir(control.Name);
                }

                if (control.HasChildren)
                {
                    TraducirControles(control);
                }
            }
        }

        public string TraducirTexto(string control, string texto)
        {
            if (!string.IsNullOrEmpty(texto) || !string.IsNullOrEmpty(texto))
            {
                servicioTraduccion.RegistrarControlSiNoExiste(control, texto);
            }
            return servicioTraduccion.Traducir(control);
        }

        public void CambiarIdioma(string nuevoIdioma)
        {
            servicioTraduccion.CambiarIdioma(nuevoIdioma);
            NotificarCambioIdioma(); // Notifica a los formularios que deben actualizarse
        }
    }
}
