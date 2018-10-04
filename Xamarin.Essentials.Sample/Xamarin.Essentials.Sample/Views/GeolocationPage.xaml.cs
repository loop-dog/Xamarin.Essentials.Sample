using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials.Sample.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Essentials.Sample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeolocationPage : ContentPage
	{
        /// <summary>
        /// 
        /// </summary>
		public GeolocationPage ()
		{
			InitializeComponent ();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInitDisp_Clicked(object sender, EventArgs e)
        {
            var ret = "";
            ret = $"Init!!!";
            Console.WriteLine(ret);
            this.lblResult.Text = ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnGetLastKnownLocation_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var ret = "";
                var location = await Geolocation.GetLastKnownLocationAsync();

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
                // Handle not supported on device exception
                this.lblResult.Text = fnsEx.ToString();
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                this.lblResult.Text = pEx.ToString();
            }
            catch (Exception ex)
            {
                // Unable to get location
                this.lblResult.Text = ex.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnGetLocation_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var ret = "";
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

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
                // Handle not supported on device exception
                this.lblResult.Text = fnsEx.ToString();
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                this.lblResult.Text = pEx.ToString();
            }
            catch (Exception ex)
            {
                // Unable to get location
                this.lblResult.Text = ex.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalculateDistance_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ret = "";

                Double.TryParse(EdtSrcLat.Text, out var srcLat);
                Double.TryParse(EdtSrcLon.Text, out var srcLon);

                Double.TryParse(EdtDistLat.Text, out var distLat);
                Double.TryParse(EdtDistLon.Text, out var distLon);

                //Geocoding.MapKey = ConstSetting.MapKey;

                Location boston = new Location(srcLat, srcLon);
                Location sanFrancisco = new Location(distLat, distLon);
                double kilo = Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Kilometers);

                ret = $"Kilometers: {kilo.ToString("#.###")}";
                Console.WriteLine(ret);
                this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                this.lblResult.Text = ex.ToString();
            }
        }
    }
}