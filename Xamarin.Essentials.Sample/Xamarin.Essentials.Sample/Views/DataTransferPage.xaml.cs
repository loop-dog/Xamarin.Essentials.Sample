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
    public partial class DataTransferPage : ContentPage
    {
        public DataTransferPage()
        {
            InitializeComponent();
        }

        private async void BtnShareText_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                await DataTransfer.RequestAsync(new ShareTextRequest
                {
                    Text = EdtText.Text,
                    Title = EdtTitle1.Text
                });

                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to open screen
                this.lblResult.Text = ex.ToString();
            }
        }

        private async void BtnShareUri_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                await DataTransfer.RequestAsync(new ShareTextRequest
                {
                    Uri = EdtUri.Text,
                    Title = EdtTitle2.Text
                });
                
                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to open screen
                this.lblResult.Text = ex.ToString();
            }
       }

        private async void BtnShareAllData_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                await DataTransfer.RequestAsync(new ShareTextRequest
                {
                    Subject = EdtSubject3.Text,
                    Text = EdtText3.Text,
                    Uri = EdtUri3.Text,
                    Title = EdtTitle3.Text
                });

                //ret = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                //Console.WriteLine(ret);
                //this.lblResult.Text = ret;
            }
            catch (Exception ex)
            {
                // Unable to open screen
                this.lblResult.Text = ex.ToString();
            }
        }
    }
}