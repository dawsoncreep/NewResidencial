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
using ResidencialEnums;

namespace caseta
{
    public partial class Frm_IngresoVisita : Form
    {
        private readonly IVisitaProcessor visitaProcessor;
        private readonly IUbicacionProcessor ubicacionProcessor;
        private readonly IDispositivoProcessor dispositivoProcessor;
        public int? Idvisita { get; set; }

        public Frm_IngresoVisita()
        {
            InitializeComponent();
            visitaProcessor = Factoria.Instancia.CreateVisitaProcessor();
            ubicacionProcessor = Factoria.Instancia.CreateUbicacionProcessor();
            dispositivoProcessor = Factoria.Instancia.CreateDispositivoProcessor();
        }

        private void Frm_IngresoVisita_Load(object sender, EventArgs e)
        {
            SPC_PLacaT.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpPlacaTrasera)));
            SPC_PlacaDelantera.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpPlacaDelantera)));
            SPC_Rostro.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpRostro)));
            SPC_Credencial.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpIdentificacion)));
            SetDataSources();
        }

        private void Btn_PAcceso_Click(object sender, EventArgs e)
        {
            CausesValidationComponents(true);
            if (ValidateChildren())
            {
                try
                {
                    Bitmap rostro = SPC_Rostro.GetCurrentFrame();
                    Bitmap placaT = SPC_PLacaT.GetCurrentFrame();
                    Bitmap placaD = SPC_PlacaDelantera.GetCurrentFrame();
                    Bitmap credencial = SPC_Credencial.GetCurrentFrame();
                    var i = visitaProcessor.RegistrarVisita(rostro, placaT, placaD, credencial, (int)Cbbx_RType.SelectedValue, Tbx_Nombre.Text,
                        Tbx_Apellidos.Text, Tbx_Desc.Text, Tbx_PLacas.Text, (int)Cbbx_Domicilio.SelectedValue, Idvisita);
                    if (i > 0)
                    {
                        MessageBox.Show("Visita Ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean();
                        SetDataSources();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CausesValidationComponents(false);
            DGV_Busqueda.Refresh();
            DGV_VisitantesActuales.Refresh();
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

        private void CausesValidationComponents(bool v)
        {
            Tbx_Apellidos.CausesValidation = v;
            Tbx_Desc.CausesValidation = v;
            Tbx_Nombre.CausesValidation = v;
            Tbx_PLacas.CausesValidation = v;
        }

        private void Clean()
        {
            Tbx_Apellidos.Text = string.Empty;
            Tbx_Desc.Text = string.Empty;
            Tbx_Nombre.Text = string.Empty;
            Tbx_PLacas.Text = string.Empty;
            Tbx_Busqueda.Text = string.Empty;
            Idvisita = null;
        }

        private void DGV_VisitantesActuales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            if (DGV_VisitantesActuales.Columns[e.ColumnIndex].Name == "Cmn_Foto")
            {
                var image = Image.FromFile(DGV_VisitantesActuales.Rows[e.RowIndex].Cells["Cmn_UrlFoto"].Value.ToString());
                var escala = new Bitmap(90, 90);
                Graphics.FromImage(escala).DrawImage(image, 0, 0, 90, 90);
                DGV_VisitantesActuales.Rows[e.RowIndex].Height = 90;
                DGV_VisitantesActuales.Columns[e.ColumnIndex].Width = 90;
                e.Value = new Bitmap(escala);
            }
        }

        private void DGV_Busqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var visita = visitaProcessor.GetVisitaByID(Convert.ToInt32(DGV_Busqueda.Rows[e.RowIndex].Cells["CmnB_ID"].Value));
            Idvisita = visita.ID;
            Tbx_Apellidos.Text = visita.Apellidos;
            Tbx_Desc.Text = string.Empty;
            Tbx_Nombre.Text = visita.Nombre;
            Tbx_PLacas.Text = visita.Placas;
            Cbbx_Domicilio.SelectedValue = visita.Ubicacion.ID;
            Cbbx_RType.SelectedValue = visita.TipoVisita.ID;
        }

        private void SetDataSources()
        {
            Cbbx_RType.DataSource = visitaProcessor.TiposDeVisita().ToArray();
            Cbbx_RType.ValueMember = "ID";
            Cbbx_RType.DisplayMember = "Nombre";
            DGV_VisitantesActuales.DataSource = visitaProcessor.GetVisitasActuales();
            DGV_Busqueda.DataSource = visitaProcessor.GetDGVBusquedas(string.Empty);
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
            DGV_VisitantesActuales.Refresh();
            DGV_Busqueda.Refresh();
            Lbl_NumeroVisita.Text = (visitaProcessor.GetNumVisitas(TiposDeVisita.Preregistro) + visitaProcessor.GetNumVisitas(TiposDeVisita.Habitual)).ToString("N0");
            Lbl_NumeroPreReg.Text = visitaProcessor.GetNumVisitas(TiposDeVisita.Preregistro).ToString("N0");
            Lbl_NumeroPrefer.Text = visitaProcessor.GetNumVisitas(TiposDeVisita.Habitual).ToString("N0");
        }

        private void Tbx_Busqueda_TextChanged(object sender, EventArgs e)
        {
            DGV_Busqueda.DataSource = visitaProcessor.GetDGVBusquedas(Tbx_Busqueda.Text);
            DGV_Busqueda.Refresh();
        }
    }
}
