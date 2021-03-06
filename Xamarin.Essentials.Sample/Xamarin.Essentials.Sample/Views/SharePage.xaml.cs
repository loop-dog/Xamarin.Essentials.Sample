﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Essentials.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SharePage : ContentPage
    {
        public SharePage()
        {
            InitializeComponent();
        }

        private async void BtnShareText_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                await Share.RequestAsync(new ShareTextRequest
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
                await Share.RequestAsync(new ShareTextRequest
                {
                    Uri = Uri.IsWellFormedUriString(EdtUri.Text, UriKind.Absolute) ? EdtUri.Text : null,
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
                await Share.RequestAsync(new ShareTextRequest
                {
                    Subject = EdtSubject3.Text,
                    Text = EdtText3.Text,
                    Uri = Uri.IsWellFormedUriString(EdtUri3.Text, UriKind.Absolute) ? EdtUri3.Text : null,
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