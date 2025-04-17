using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICIOS
{
    public class gestorPermisosControles941lp
    {
        public void AplicarPermisosAControles(Control parent, List<string> permisosUsuario)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag != null && !string.IsNullOrWhiteSpace(ctrl.Tag.ToString()))
                {
                    string permisoTag = ctrl.Tag.ToString();
                    ctrl.Enabled = permisosUsuario.Contains(permisoTag);
                }
                else
                {
                    ctrl.Enabled = true;
                }

                if (ctrl.HasChildren)
                {
                    AplicarPermisosAControles(ctrl, permisosUsuario);
                }
            }
        }
    }
}
