using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Essentials.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }

        private async void BtnOpenWithLocation_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                Double.TryParse(EdtLat.Text, out var lat);
                Double.TryParse(EdtLon.Text, out var lon);

                var location = new Location(lat, lon);
                var options = new MapsLaunchOptions { Name = EdtMapsLaunchOptions1.Text };

                await Maps.OpenAsync(location, options);

                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to get location
                this.lblResult.Text = ex.ToString();
            }
        }

        private async void BtnOpenWithPlacemark_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var ret = "";
                var placemark = new Placemark
                {
                    CountryName = EdtCountryName2.Text,
                    AdminArea = EdtAdminArea2.Text,
                    Thoroughfare = EdtThoroughfare2.Text,
                    Locality = EdtLocality2.Text
                };
                var options = new MapsLaunchOptions { Name = EdtMapsLaunchOptions2.Text };

                await Maps.OpenAsync(placemark, options);

                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to get location
                this.lblResult.Text = ex.ToString();
            }
        }

        private async void BtnPlacemark_OpenMaps_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var ret = "";
                var placemark = new Placemark
                {
                    CountryName = EdtCountryName3.Text,
                    AdminArea = EdtAdminArea3.Text,
                    Thoroughfare = EdtThoroughfare3.Text,
                    Locality = EdtLocality3.Text
                };

                //var options = new MapsLaunchOptions { Name = "Microsoft Building 25" };
                await placemark.OpenMapsAsync();

                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to get location
                this.lblResult.Text = ex.ToString();
            }

        }
    }
}