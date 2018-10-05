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
    public partial class GyroscopePage : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;

        public GyroscopePage()
        {
            InitializeComponent();

            // Register for reading changes.
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            this.ToggleGyroscope();
        }

        private void BtnStop_Clicked(object sender, EventArgs e)
        {
            this.ToggleGyroscope();
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }


        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            // Process Angular Velocity X, Y, and Z
            var ret=$"Reading: X: {data.AngularVelocity.X}, Y: {data.AngularVelocity.Y}, Z: {data.AngularVelocity.Z}";
            Console.WriteLine(ret);
            this.lblResult.Text += ret + Environment.NewLine;
        }

        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                {
                    Gyroscope.Stop();
                    this.lblResult.Text += "Stop!!!" + Environment.NewLine;
                }
                else
                {
                    Gyroscope.Start(speed);
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