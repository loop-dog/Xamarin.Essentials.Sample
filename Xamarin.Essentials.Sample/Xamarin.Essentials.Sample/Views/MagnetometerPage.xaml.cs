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
    public partial class MagnetometerPage : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;

        public MagnetometerPage()
        {
            InitializeComponent();

            // Register for reading changes.
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;

        }

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            this.ToggleMagnetometer();
        }

        private void BtnStop_Clicked(object sender, EventArgs e)
        {
            this.ToggleMagnetometer();
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var data = e.Reading;
            // Process MagneticField X, Y, and Z
            var ret=$"Reading: X: {data.MagneticField.X}, Y: {data.MagneticField.Y}, Z: {data.MagneticField.Z}";
            Console.WriteLine(ret);
            this.lblResult.Text += ret + Environment.NewLine;
        }

        public void ToggleMagnetometer()
        {
            try
            {
                if (Magnetometer.IsMonitoring)
                {
                    Magnetometer.Stop();
                    this.lblResult.Text += "Stop!!!" + Environment.NewLine;
                }
                else
                {
                    Magnetometer.Start(speed);
                    this.lblResult.Text = "";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                this.lblResult.Text = fnsEx.ToString();
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                this.lblResult.Text = ex.ToString();
            }
        }
    }
}