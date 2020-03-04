using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppResidencial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerarEventoPage : ContentPage
	{
		public GenerarEventoPage ()
		{
			InitializeComponent ();
            this.BindingContext = new FotoClass();
            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;
            
		}

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {

           /* Model.Domain.Location location = new Model.Domain.Location()
            {
                Description = InLoc.Text
            };

          //  var postResult = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/location/InsertUpdate", location);

            Model.Domain.EventType eventType = new Model.Domain.EventType()
            {
                Description = InDesc.Text
            };
          // var postResult2 = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/eventtype/InsertUpdate", eventType);
            Model.Domain.Event evento = new Model.Domain.Event()
            {
             Description = eventType.Description,
             DateStart = dpstart.Date + tpStart.Time,
             DateEnd = dpEnd.Date + tpEnd.Time,
             Location = location
              
            };

            var postResult3 = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/event/InsertUpdate", evento);*/
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}