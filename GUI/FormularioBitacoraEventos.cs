using BE;
using BLL;
using SERVICIOS;
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
    public partial class FormularioBitacoraEventos: Form, IObservadorTraduccion
    {
        bll_bitacora bllBitacora;
        bll_usuario bllUsuario;
        private GestorDeTraducciones gestorTraducciones;
        public FormularioBitacoraEventos(GestorDeTraducciones gestor)
        {
            InitializeComponent();
            bllBitacora = new bll_bitacora();
            bllUsuario = new bll_usuario();
            MostrarBitacora(bllBitacora.RetornarBitacora());
            gestorTraducciones = gestor; // Asignamos el gestor recibido
            // Registra los controles en el JSON
            gestorTraducciones.RegistrarControles(this);
            // Se registra como observador
            gestorTraducciones.RegistrarObservador(this);
            // Aplica la traducción actual
            Load += (s, e) => ActualizarTraduccion();
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
                GestorFormulario.gestorFormSG.DefinirEstado(new EstadoMenu(gestorTraducciones));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioBitacoraEventos_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (object[] item in bllBitacora.RetornarBitacora())
                {
                    if (comboboxUsuario.Items.Contains(item[1]) == false)
                    {
                        comboboxUsuario.Items.Add(item[1]);
                    }
                    if (comboboxModulo.Items.Contains(item[4]) == false)
                    {
                        comboboxModulo.Items.Add(item[4]);
                    }
                    if (comboBoxDescripcion.Items.Contains(item[5]) == false)
                    { 
                        comboBoxDescripcion.Items.Add(item[5]);
                    }
                    if (comboBoxCriticidad.Items.Contains(item[6]) == false)
                    {
                        comboBoxCriticidad.Items.Add(item[6]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Usuario usuario = bllUsuario.RetornarUsuarios().Find(x => x.nombreUsuario == dataBitacora.SelectedRows[0].Cells[1].Value.ToString());
                if (usuario != null)
                {
                    txtUsuario.Text = usuario.nombreUsuario;
                    txtNombre.Text = usuario.nombre;
                    txtApellido.Text = usuario.apellido;
                    txtEstado.Text = usuario.estado.ToString();
                }
                else
                {
                    txtUsuario.Text = "-";
                    txtNombre.Text = "-";
                    txtApellido.Text = "-";
                    txtEstado.Text = "-";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxCriticidad.SelectedIndex = -1;
                comboBoxDescripcion.SelectedIndex = -1;
                comboboxModulo.SelectedIndex = -1;
                comboboxUsuario.SelectedIndex = -1;
                checkBoxFechaConsulta.Checked = false ;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboboxUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            try
            {
                string usuario = comboboxUsuario.Text;
                string descripcion = comboBoxDescripcion.Text;
                string modulo = comboboxModulo.Text;
                string criticidad = comboBoxCriticidad.Text;
                string desde = "";
                string hasta = "";
                if(checkBoxFechaConsulta.Checked==true)
                {
                     desde = dateTimePickerDesde.Value.ToString("yyyy-dd-MM");
                     hasta = dateTimePickerHasta.Value.ToString("yyyy-dd-MM");
                }
                MostrarBitacora(bllBitacora.RetornarConsulta(usuario, descripcion, modulo, criticidad, desde, hasta));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void comboboxModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void comboBoxDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void comboBoxCriticidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void checkBoxFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        public void ActualizarTraduccion()
        {
            gestorTraducciones.TraducirControles(this);
        }

        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                gestorTraducciones.CambiarIdioma("en");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
