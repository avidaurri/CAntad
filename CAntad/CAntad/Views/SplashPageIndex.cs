using CAntad.Helpers;
using CAntad.ViewModels;
using ModelsLibraryAntad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CAntad.Views
{
    class SplashPageIndex : ContentPage
    {
        Image splashImage;
        public static NavigationPage Navigator { get; internal set; }

        public SplashPageIndex()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "logoantad",
                WidthRequest = 200,
                HeightRequest = 200

            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);
            // this.BackgroundColor = Color.FromHex("#429de3");
            this.BackgroundImageSource = "fondosplash";
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 500);
            await splashImage.ScaleTo(0.9, 500, Easing.Linear);
            await splashImage.ScaleTo(150, 500, Easing.Linear);

            var mainViewModel = MainViewModel.GetInstance();

            if (Settings.IsRemembered)
            {

                if (!string.IsNullOrEmpty(Settings.UserSession))
                {
                    mainViewModel.UserSession = JsonConvert.DeserializeObject<UserSession>(Settings.UserSession);
                }

                mainViewModel.Bienvenido = new BienvenidoViewModel();
                Application.Current.MainPage = new Master(new Bienvenido());

            }
            else
            {
                mainViewModel.Login = new LoginViewModel();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }


        }

    }
}
