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
    class traductor
    {
        private string rutaJSON = "traducciones.json";
        private Dictionary<string, Dictionary<string, string>> textos;
        private string idiomaActual;

        public traductor()
        {
            if (File.Exists(rutaJSON))
            {
                string json = File.ReadAllText(rutaJSON);
                var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(json);

                idiomaActual = ((JsonElement)data["Configuracion"]).GetProperty("IdiomaPredeterminado").GetString();
                textos = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(data["Textos"].ToString());
            }
            else
            {
                foreach (Control control in form.Controls)
                {
                    if (control is Label || control is Button || control is MenuStrip || control is DataGridView)
                    {
                        if (!textos.ContainsKey(control.Name))
                        {
                            textos[control.Name] = new Dictionary<string, string> { { idiomaActual, control.Text } };
                        }
                    }
                }

                // Guardamos en JSON
                var datosActualizados = new Dictionary<string, object>
                {
                    { "Configuracion", new Dictionary<string, string> { { "IdiomaPredeterminado", idiomaActual } } },
                    { "Textos", textos }
                };

                string jsonNuevo = System.Text.Json.JsonSerializer.Serialize(datosActualizados, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(rutaJSON, jsonNuevo);
            }
        }

        public string Traducir(string clave)
        {
            if (textos.ContainsKey(clave) && textos[clave].ContainsKey(idiomaActual))
            {
                return textos[clave][idiomaActual];
            }
            return clave; // Si no encuentra traducción, devuelve la clave original
        }

        public void TraducirFormulario(Control control)
        {
            if (control == null) return;

            // Intentar traducir cualquier control con propiedad Text
            if (!string.IsNullOrEmpty(control.Text))
            {
                control.Text = Traducir(control.Name);
            }

            // Si el control es un DataGridView, traducir los encabezados de columna
            if (control is DataGridView dgv)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.HeaderText = Traducir(col.Name);
                }
            }

            // Si el control es un MenuStrip, traducir los elementos del menú
            if (control is MenuStrip menu)
            {
                foreach (ToolStripMenuItem item in menu.Items)
                {
                    TraducirMenuItem(item);
                }
            }

            // Recorrer controles anidados (dentro de Paneles, GroupBox, TabPages, etc.)
            foreach (Control subControl in control.Controls)
            {
                TraducirFormulario(subControl);
            }
        }

        private void TraducirMenuItem(ToolStripMenuItem item)
        {
            if (!string.IsNullOrEmpty(item.Text))
            {
                item.Text = Traducir(item.Name);
            }

            // Traducir submenús si existen
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    TraducirMenuItem(subMenuItem);
                }
            }
        }

        public void CambiarIdioma(string nuevoIdioma)
        {
            idiomaActual = nuevoIdioma;

            string json = File.ReadAllText(rutaJSON);
            var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            var config = (JsonElement)data["Configuracion"];
            var dicConfig = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(config.ToString());
            dicConfig["IdiomaPredeterminado"] = nuevoIdioma;
            data["Configuracion"] = dicConfig;

            string nuevoJson = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaJSON, nuevoJson);
        }

        public string ObtenerIdiomaActual()
        {
            return idiomaActual;
        }

        public List<string> ObtenerIdiomas()
        {
            if (textos.Count > 0)
            {
                return new List<string>(textos.Values.First().Keys);
            }
            return new List<string>();
        }
    }
}
