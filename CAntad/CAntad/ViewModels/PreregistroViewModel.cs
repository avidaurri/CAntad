using CAntad.Services;
using CAntad.Views;
using GalaSoft.MvvmLight.Command;
using ModelsLibraryAntad.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CAntad.ViewModels
{
    public class PreregistroViewModel : BaseViewModel
    {
        #region attributes
        private bool isEnabled;
        private ApiService apiService;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Contructors
        public PreregistroViewModel()
        {
            this.IsEnabled = true;
            this.apiService = new ApiService();
        }
        #endregion


        #region Commands


        [Obsolete]
        public ICommand AceptarRegistroCommand
        {
            get
            {
                return new RelayCommand(AceptarRegistroAsync);
            }

        }

        [Obsolete]
        private async void AceptarRegistroAsync()
        {
            this.IsEnabled = false;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Mensaje", connection.Message, "Aceptar");
                return;
            }


            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlGetCatalogo"].ToString();// + "?idEstado=0";
            var response = await this.apiService.GetCatalogos(url, prefix, controller);
            this.IsEnabled = true;
            if (!response.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert("Mensaje", "Hubo un problema con su conexión a internet, por favor intentalo nuevamente", "Aceptar");

                return;




            }
            else
            {
                CatalogoRegistro cat = new CatalogoRegistro();
                cat = (CatalogoRegistro)response.Result;

                MainViewModel.GetInstance().RegistroUno = new RegistroUnoViewModel(cat);
                Application.Current.MainPage = new NavigationPage(new RegistroUnoPage());
            }




        }
        #endregion

    }
}
