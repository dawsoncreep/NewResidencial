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
using BusinessInterfaces;

namespace caseta
{
    public partial class Frm_IngresoVisita : Form
    {
        private readonly IVisitaProcessor visitaProcessor;
        private readonly IUbicacionProcessor ubicacionProcessor;

        public Frm_IngresoVisita()
        {
            InitializeComponent();
            visitaProcessor = Factoria.Instancia.CreateVisitaProcessor();
            ubicacionProcessor = Factoria.Instancia.UbicacionProcessor();
            Cbbx_RType.DataSource = visitaProcessor.TiposDeVisita().ToArray();
            Cbbx_RType.ValueMember = "ID";
            Cbbx_RType.DisplayMember = "Nombre";
        }

        private void Frm_IngresoVisita_Load(object sender, EventArgs e)
        {
            SPC_PLacaT.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaDelantera"]));
            SPC_Rostro.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
            SPC_Credencial.StartPlay(new Uri(ConfigurationManager.AppSettings["Credencial"]));
            var ubicaciones = ubicacionProcessor.UbicacionesValidas();
            Cbbx_Domicilio.DataSource = ubicaciones.ToArray();            
            Cbbx_Domicilio.ValueMember = "ID";
            Cbbx_Domicilio.DisplayMember = "Nombre";
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            Collection.AddRange(ubicaciones.Select(s => s.Nombre).ToArray());            
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
                    visitaProcessor.RegistrarVisita(rostro, placaT, placaD, credencial, (int)Cbbx_RType.SelectedValue, Tbx_Nombre.Text,
                        Tbx_Apellidos.Text, Tbx_Desc.Text, Tbx_PLacas.Text, (int)Cbbx_Domicilio.SelectedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
