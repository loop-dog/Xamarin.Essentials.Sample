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
    public partial class DeviceInformationPage : ContentPage
    {
        public DeviceInformationPage()
        {
            InitializeComponent();
        }

        private void BtnDeviceInfo_Clicked(object sender, EventArgs e)
        {
            var ret = "";

            var deviceInfo =
                        $"Model        :{DeviceInfo.Model}\n" +
                        $"Manufacturer :{DeviceInfo.Manufacturer}\n" +
                        $"VersionString:{DeviceInfo.VersionString}\n" +
                        $"Platform     :{DeviceInfo.Platform}\n" +
                        $"Idiom        :{DeviceInfo.Idiom}\n" +
                        $"DeviceType   :{DeviceInfo.DeviceType}\n";

            //プラットフォーム
            //DeviceInfo.Platform オペレーティング システムにマップされる定数文字列を相互に関連付けます。 値を確認できます、Platformsクラス。
            //DeviceInfo.Platforms.iOS – iOS
            //DeviceInfo.Platforms.Android – Android
            //DeviceInfo.Platforms.UWP – UWP
            //DeviceInfo.Platforms.Unsupported – サポートされていません。
            //表現方法
            //DeviceInfo.Idiom correlates アプリケーションをデバイスの種類にマップされる文字列定数がで実行されています。 値を確認できます、Idiomsクラス。
            //DeviceInfo.Idioms.Phone – 電話
            //DeviceInfo.Idioms.Tablet – タブレット
            //DeviceInfo.Idioms.Desktop – デスクトップ
            //DeviceInfo.Idioms.TV – テレビ
            //DeviceInfo.Idioms.Unsupported – サポートされていません。
            //デバイスの種類
            //DeviceInfo.DeviceType アプリケーションが、物理または仮想デバイスで実行されているかどうかを決定する列挙体を関連付けます。 仮想デバイスは、シミュレーターやエミュレーターです。

            ret = deviceInfo;
            Console.WriteLine(ret);
            this.lblResult.Text = ret;

        }
    }
}