using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials.Sample.Common;


namespace Xamarin.Essentials.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeocodingPage : ContentPage
    {
        public GeocodingPage()
        {
            InitializeComponent();
        }

        private async void BtnGetLocations_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                //var address = "Microsoft Building 25 Redmond WA USA";
                var address = EdtContents.Text;

                Geocoding.MapKey = ConstSetting.MapKey;
                var locations = await Geocoding.GetLocationsAsync(address);

                var ret = "";
                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                    Console.WriteLine(ret);
                    this.lblResult.Text = ret;
                }
                else
                {
                    this.lblResult.Text = ret;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                this.lblResult.Text = fnsEx.ToString();

            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                this.lblResult.Text = ex.ToString();
            }
        }

        private async void BtnGetPlacemarks_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                //var lat = 47.673988;
                //var lon = -122.121513;

                Double.TryParse(EdtLat.Text, out var lat);
                Double.TryParse(EdtLon.Text,out var lon);

                Geocoding.MapKey = ConstSetting.MapKey;
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var ret = "";
                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var geocodeAddress =
                        $"AdminArea:       {placemark.AdminArea}\n" +
                        $"CountryCode:     {placemark.CountryCode}\n" +
                        $"CountryName:     {placemark.CountryName}\n" +
                        $"FeatureName:     {placemark.FeatureName}\n" +
                        $"Locality:        {placemark.Locality}\n" +
                        $"PostalCode:      {placemark.PostalCode}\n" +
                        $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                        $"SubLocality:     {placemark.SubLocality}\n" +
                        $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                        $"Thoroughfare:    {placemark.Thoroughfare}\n";

                    ret = geocodeAddress;
                    Console.WriteLine(ret);
                    this.lblResult.Text = ret;
                }
                else
                {
                    this.lblResult.Text = ret;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                this.lblResult.Text = fnsEx.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                this.lblResult.Text = ex.ToString();
            }
        }

    }
}