using BusinessInterfaces;
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
        private IVisitaProcessor visitaProcessor;
        public Frm_Salida()
        {
            InitializeComponent();
            visitaProcessor = Factoria.Instancia.CreateVisitaProcessor();            
        }

        private void SetDataSources()
        {
            DGV_Visitas.DataSource = visitaProcessor.GetVisitasActuales();
            DGV_Visitas.Refresh();
        }

        private void Frm_Salida_Load(object sender, EventArgs e)
        {
            SPC_PlacaTrasera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
            SetDataSources();
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
            var visita = visitaProcessor.GetVisitaByID(Convert.ToInt32(DGV_Visitas.Rows[e.RowIndex].Cells["Cmn_ID"].Value));
            TxBx_Direccion.Text = visita.Ubicacion.Nombre;
            TxBx_Nombre.Text = visita.Nombre;
            TxBx_Placas.Text = visita.Placas;
        }
    }
}
