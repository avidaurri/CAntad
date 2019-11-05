using CAntad.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAntad
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; set; }
        public App()
        {
            InitializeComponent();

            /* var mainViewModel = MainViewModel.GetInstance();

             if (Settings.IsRemembered)
             {

                 if (!string.IsNullOrEmpty(Settings.UserSession))
                 {
                     mainViewModel.UserSession = JsonConvert.DeserializeObject<UserSession>(Settings.UserSession);
                 }

                 //mainViewModel.Usuarios = new UsuariosViewModel();
                 //mainViewModel.Intramuro = new IntramuroViewModel();
                 //mainViewModel.Promotor = new PromotorViewModel();
                 mainViewModel.Bienvenido = new BienvenidoViewModel();

                 this.MainPage = new Master(new Bienvenido());
                 //
             }
             else
             {
                 mainViewModel.Login = new LoginViewModel();
                 this.MainPage = new NavigationPage(new LoginPage());
             }*/
            //
            MainPage = new SplashPageIndex();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
