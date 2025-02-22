using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormularioBitacoraEventos: Form
    {
        bll_bitacora bllBitacora;
        public FormularioBitacoraEventos()
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora();
            MostrarBitacora(bllBitacora.RetornarBitacora());
        }

        private void MostrarBitacora(List<object[]> bitacora)
        {
            dataBitacora.Rows.Clear();
            foreach(object[] row in bitacora)
            {
                dataBitacora.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
