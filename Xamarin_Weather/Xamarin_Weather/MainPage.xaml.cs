using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace Xamarin_Weather
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Recupera_Clicked(object sender, EventArgs e)
        {
            using (var cliente = new HttpClient())
            {

                var jsontxt2 = await cliente.GetStringAsync("http://ip-api.com/json");
                var data2 = OpenIpApi.FromJson(jsontxt2);

                var jsontxt = await cliente.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat="+data2.Lat+"&lon="+data2.Lon+"&appid=a2ba646b4466268388ee5cbf636be496&units=metric");




                var data = OpenWeatherMapProxy.FromJson(jsontxt);
                Resultado.Text = "Nombre estacion: " + data.Name +
                    "\nTemperatura: " + data.Main.Temp +
                    "\nHumedad: " + data.Main.Humidity +
                    "Cº\nDescripcion: " + data.Weather[0].Description+
                    "\nLatitud: "+data2.Lat+" Longitud: "+data2.Lon
                    ;

               
                Icono.Source = ImageSource.FromResource("Xamarin_Weather.Assets.Weather." + data.Weather[0].Icon + ".png");

            }
        }

        private async void Recupera1_Clicked(object sender, EventArgs e)
        {
            using (var cliente = new HttpClient())
            {


                 var jsontxt = await cliente.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q=" + Ciudad.Text + "&appid=a2ba646b4466268388ee5cbf636be496&units=metric");




                var data = OpenWeatherMapProxy.FromJson(jsontxt);
                Resultado1.Text = "Nombre estacion: " + data.Name +
                    "\nTemperatura: " + data.Main.Temp +
                    "\nHumedad: " + data.Main.Humidity +
                    "Cº\nDescripcion: " + data.Weather[0].Description 
                    ;

                
                Icono1.Source = ImageSource.FromResource("Xamarin_Weather.Assets.Weather." + data.Weather[0].Icon + ".png");

            }

        }
    }
}
