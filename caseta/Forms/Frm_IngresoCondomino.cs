using BusinessInterfaces;
using ResidencialEnums;
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
    public partial class Frm_IngresoCondomino : Form
    {
        private readonly IDispositivoProcessor dispositivoProcessor;
        public Frm_IngresoCondomino()
        {
            InitializeComponent();
            dispositivoProcessor = Factoria.Instancia.CreateDispositivoProcessor();
        }

        private void Frm_IngresoTag_Load(object sender, EventArgs e)
        {
            SPC_PlacaTrasera.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpPlacaTrasera)));
            SPC_PlacaDelantera.StartPlay(new Uri(dispositivoProcessor.GetDispositivoString(TiposDispositivos.CamaraIpRostro)));
        }
    }
}
