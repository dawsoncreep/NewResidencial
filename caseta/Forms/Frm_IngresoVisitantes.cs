using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye.Controls.WinForms.StreamPlayerControl;
using BusinessLayer;
using SecureGateTypes;

namespace caseta
{
    public partial class Frm_IngresoVisita : Form
    {
        ExternalProcessor externalProcessor;
        LocationProcessor locationProcessor;
        EventProcessor eventProcessor;
        public Frm_IngresoVisita()
        {
            InitializeComponent();
            externalProcessor = new ExternalProcessor();
            locationProcessor = new LocationProcessor();
            eventProcessor = new EventProcessor();
            Cbbx_RType.Items.AddRange(eventProcessor.GetEventTypes());
            Cbbx_RType.ValueMember = "Id";
            Cbbx_RType.DisplayMember = "Descripcion";
        }

        private void Frm_IngresoVisita_Load(object sender, EventArgs e)
        {
            SPC_PLacaT.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaDelantera"]));
            SPC_Rostro.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
            SPC_Credencial.StartPlay(new Uri(ConfigurationManager.AppSettings["Credencial"]));            
            Cbbx_Domicilio.Items.AddRange(locationProcessor.GetLocations());            
            Cbbx_Domicilio.ValueMember = "ID";
            Cbbx_Domicilio.DisplayMember = "LocationStr";
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            Collection.AddRange(locationProcessor.GetLocationsString());            
            Cbbx_Domicilio.AutoCompleteCustomSource = Collection;
            Cbbx_Domicilio.AutoCompleteMode = AutoCompleteMode.Suggest;
            Cbbx_Domicilio.AutoCompleteSource = AutoCompleteSource.CustomSource;            
            Cbbx_Domicilio.AutoCompleteCustomSource = Collection;
        }

        private void Btn_PAcceso_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    Bitmap rostro = SPC_Rostro.GetCurrentFrame();
                    Bitmap placaT = SPC_PLacaT.GetCurrentFrame();
                    Bitmap placaD = SPC_PlacaDelantera.GetCurrentFrame();
                    Bitmap credencial = SPC_Credencial.GetCurrentFrame();
                    if (Cbbx_RType.Text == "Preregistro")
                    {
                        if (eventProcessor.SolicitarAcceso(rostro, placaT, placaD, credencial, (Location)Cbbx_Domicilio.SelectedItem,
                            Tbx_Nombre.Text, Tbx_Apellidos.Text, (EventType)Cbbx_RType.SelectedItem))
                        {
                            MessageBox.Show("Chido", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nel", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Error al Tomar las fotografias, revise sus camaras y vuelva a intentarlo","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }                
            }
        }

        private void Tbx_PLacas_Validating(object sender, CancelEventArgs e)
        {
            if (Tbx_PLacas.Text.Length < 6)
            {
                MessageBox.Show("Faltan caracteres a la Placa","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Tbx_Nombre_Validating(object sender, CancelEventArgs e)
        {
            if (Tbx_Nombre.Text.Length < 2 || Tbx_Nombre.Text == string.Empty)
            {
                MessageBox.Show("Falta indicar un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Tbx_Apellidos_Validating(object sender, CancelEventArgs e)
        {
            if (Tbx_Apellidos.Text.Length < 2 || Tbx_Apellidos.Text == string.Empty)
            {
                MessageBox.Show("Falta indicar un Apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Cbbx_Domicilio_Validating(object sender, CancelEventArgs e)
        {
            if (Cbbx_Domicilio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un Domicilio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Cbx_RType_Validating(object sender, CancelEventArgs e)
        {
            if (Cbbx_RType.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un Tipo de Registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }
}
