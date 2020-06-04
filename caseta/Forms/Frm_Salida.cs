using BusinessInterfaces;
using SecureGateTypes;
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

namespace caseta.Forms
{
    public partial class Frm_Salida : Form
    {
        private readonly IVisitaProcessor visitaProcessor;
        private IDispositivoProcessor dispositivoProcessor; 
        private Visita visita { get; set; }
        public Frm_Salida()
        {
            InitializeComponent();
            visitaProcessor = Factoria.Instancia.CreateVisitaProcessor();
            dispositivoProcessor = Factoria.Instancia.CreateDispositivoProcessor();
        }

        private void SetDataSources(IEnumerable<DGVVisitaActual> busqueda = null)
        {
            if (busqueda == null)
            {
                DGV_Visitas.DataSource = visitaProcessor.GetVisitasActuales();
            }
            else
            {
                DGV_Visitas.DataSource = busqueda;
            }
            DGV_Visitas.Refresh();
        }

        private void Frm_Salida_Load(object sender, EventArgs e)
        {
            SPC_PlacaTrasera.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpPlacaTrasera)));
            SPC_PlacaDelantera.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpPlacaDelantera)));
            SetDataSources();
            try
            {
                var ultimaVisita = visitaProcessor.GetUltimaVisita();
                Pbx_PlacaDelantera.ImageLocation = ultimaVisita.FotoSalidaUrl;
                Pbx_PlacaDelantera.SizeMode = PictureBoxSizeMode.StretchImage;
                Pbx_PlacaTrasera.ImageLocation = ultimaVisita.FotoCabina;
                Pbx_PlacaTrasera.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (InvalidOperationException)
            {
                
            }
            
        }

        private void DGV_Visitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_Visitas.Columns[e.ColumnIndex].Name == "Cmn_Foto")
            {
                var image = Image.FromFile(DGV_Visitas.Rows[e.RowIndex].Cells["Cmn_UrlFoto"].Value.ToString());
                var escala = new Bitmap(90, 90);
                Graphics.FromImage(escala).DrawImage(image, 0, 0, 90, 90);
                DGV_Visitas.Rows[e.RowIndex].Height = 90;
                DGV_Visitas.Columns[e.ColumnIndex].Width = 90;
                e.Value = new Bitmap(escala);
            }
        }

        private void DGV_Visitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            visita = visitaProcessor.GetVisitaByID(Convert.ToInt32(DGV_Visitas.Rows[e.RowIndex].Cells["Cmn_ID"].Value));
            TxBx_Direccion.Text = visita.Ubicacion.Nombre;
            TxBx_Nombre.Text = visita.Nombre + " " + visita.Apellidos;
            TxBx_Placas.Text = visita.Placas;
        }

        private void Btn_Salida_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap placaT = SPC_PlacaTrasera.GetCurrentFrame();
                Bitmap placaD = SPC_PlacaDelantera.GetCurrentFrame();                
                visitaProcessor.DarSalida(visita,placaD);
                Clean();
                SetDataSources();
                Pbx_PlacaDelantera.Image = placaD;
                Pbx_PlacaDelantera.SizeMode = PictureBoxSizeMode.StretchImage;
                Pbx_PlacaTrasera.Image = placaT;
                Pbx_PlacaTrasera.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
        private void Clean()
        {
            TxBx_Descripcion.Text = string.Empty;
            TxBx_Direccion.Text = string.Empty;
            TxBx_Nombre.Text = string.Empty;
            TxBx_Placas.Text = string.Empty;
            TxtBx_Search.Text = string.Empty;
        }

        private void TxtBx_Search_TextChanged(object sender, EventArgs e)
        {
            SetDataSources(visitaProcessor.GetVisitasActuales(TxtBx_Search.Text.Trim()));
        }
    }
}
