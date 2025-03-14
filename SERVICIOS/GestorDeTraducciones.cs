using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICIOS
{
    public class GestorDeTraducciones
    {
        private traductor servicioTraduccion;
        private List<IObservadorTraduccion> observadores;

        private static GestorDeTraducciones instance;
        public static GestorDeTraducciones Gestor
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestorDeTraducciones();
                }
                return instance;
            }
        }

        public GestorDeTraducciones()
        {
            servicioTraduccion = new traductor();
            observadores = new List<IObservadorTraduccion>();
        }

        public void RegistrarObservador(IObservadorTraduccion observador)
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

        public void CambiarIdioma(string nuevoIdioma)
        {
            servicioTraduccion.CambiarIdioma(nuevoIdioma);
            NotificarCambioIdioma(); // Notifica a los formularios que deben actualizarse
        }
    }
}
