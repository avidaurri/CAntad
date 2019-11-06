using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace CAntad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView
    {
        ZXingBarcodeImageView barcode;
        public PopupView(string usuario, string evento)
        {
            //
            InitializeComponent();
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 500;
            barcode.BarcodeOptions.Height = 500;
            barcode.BarcodeValue = usuario + "/" + evento;
            //mensajePop.Text = mensaje;
            // Task.Delay(500);
            stackPrinc.Children.Insert(1, barcode);

        }
    }
}