using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAntad.Views.Regis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroTresPage : ContentPage
    {
        public RegistroTresPage()
        {
            InitializeComponent();
        }

        private async void Heartd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}