using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Web;

namespace AppResidencial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string usuario;
        private string pass;

        public LoginPage()
        {
            InitializeComponent();

            btn_iniciar.Clicked += BtnIniciar_Clicked;
            picker_fracc.Items.Add("");
            picker_fracc.Items.Add("Pulgas pandas");


        }

        //Boton para iniciar sesion
        private void BtnIniciar_Clicked(object sender, EventArgs e)
        {

/*
            var login = new AppService.Models.LoginModel()
            {
                username = "admin", // gilberto  admin
                password = "Admin123.", // Gc090807  Admin123.
                client_id = "18fc7e3e20854a7584f7eea70063e5b7", //audience f1c30f3289614198a4a0626dae0725f4 18fc7e3e20854a7584f7eea70063e5b7
                grant_type = "password"

            };


            var tokenResult = (AppService.Models.TokenResultHelper)AppService.AppCommon.AppRestRequest.Login(login, "oauth2/token").Result;


            if (!String.IsNullOrEmpty(tokenResult.access_token))
            {
                var getResult = (System.Collections.Generic.List<Model.Domain.Permission>)
                    AppService.AppCommon.AppRestRequest.DoResourceServerGET("api/permission/GetAll",
                    tokenResult.access_token).Result;

                 // Navigation.PushAsync(new HomePage());

            }


           else
            {
                DisplayAlert("ERROR", "incorrect username and / or password", "OK");
                entry_pass.Text = "";


                //           Navigation.PushAsync(new HomePage());

            }
            */
            usuario = entry_usuario.Text;
            pass = entry_pass.Text;

            if (usuario == "demo1" && pass == "Demo1")
            {
                Navigation.PushAsync(new HomePage());
                limpiar();

            }
            else if (usuario == "demo2" && pass == "Demo2")
            {
                Navigation.PushAsync(new HomePage());
                limpiar();
            }
            else if (usuario == "demo3" && pass == "Demo3")
            {
                Navigation.PushAsync(new HomePage());
                limpiar();
            }
            else
            {
                DisplayAlert("Error", "Verifica tu usuario/contraseña", "OK");
                limpiar();

                //Navigation.PushAsync(new HomePage());

            }
            
             void limpiar()
            {
                entry_pass.Text = "";
                entry_usuario.Text = "";
                picker_fracc.SelectedIndex = -1;

            }

        }
    }

}