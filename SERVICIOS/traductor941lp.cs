using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SERVICIOS
{
    public class traductor941lp
    {
        private Dictionary<string, Dictionary<string, string>> traducciones;
        private string archivoTraduccion = "traducciones.json";
        

        public traductor941lp()
        {
            CargarTraducciones();
        }

        private void CargarTraducciones()
        {
            if (File.Exists(archivoTraduccion))
            {
                string json = File.ReadAllText(archivoTraduccion);
                traducciones = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            else
            {
                // Si no existe el archivo, lo inicializamos con los idiomas base
                traducciones = new Dictionary<string, Dictionary<string, string>>
                {
                    { "es", new Dictionary<string, string>() },
                    { "en", new Dictionary<string, string>() }
                };
                GuardarTraducciones();
            }
        }

        private void GuardarTraducciones()
        {
            string json = JsonConvert.SerializeObject(traducciones, Formatting.Indented);
            File.WriteAllText(archivoTraduccion, json);
        }

        public void RegistrarControlSiNoExiste(string controlName, string textoDefault)
        {
            if (string.IsNullOrEmpty(controlName)) return;

            bool actualizado = false;

            foreach (var idioma in traducciones.Keys)
            {
                if (!traducciones[idioma].ContainsKey(controlName))
                {
                    traducciones[idioma][controlName] = textoDefault; // Usa el texto original como base
                    actualizado = true;
                }
            }

            if (actualizado)
            {
                GuardarTraducciones();
            }
        }

        public void CambiarIdioma(string nuevoIdioma)
        {
            if (traducciones.ContainsKey(nuevoIdioma))
            {
                sessionManager941lp.Gestor.usuarioIdioma = nuevoIdioma;
            }
        }

        public string Traducir(string clave)
        {
            if (traducciones.ContainsKey(sessionManager941lp.Gestor.usuarioIdioma) && traducciones[sessionManager941lp.Gestor.usuarioIdioma].ContainsKey(clave))
            {
                return traducciones[sessionManager941lp.Gestor.usuarioIdioma][clave];
            }
            return clave; // Si no hay traducción, retorna la clave original
        }

        public string ObtenerIdiomaActual()
        {
            return sessionManager941lp.Gestor.usuarioIdioma;
        }
    }
}
