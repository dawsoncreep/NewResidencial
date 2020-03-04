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
	public partial class PersonalPage : ContentPage
	{
		public PersonalPage ()
		{
			InitializeComponent ();
            btnGenerarProvedor.Clicked += BtnGenerarProvedor_Clicked;
			
		}

        private void BtnGenerarProvedor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenerarPersonalPage());
        }
    }
}