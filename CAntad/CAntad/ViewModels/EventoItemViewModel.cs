using CAntad.Services;
using CAntad.Views;
using GalaSoft.MvvmLight.Command;
using ModelsLibraryAntad.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CAntad.ViewModels
{
    public class EventoItemViewModel : Evento
    {

        #region Attributes
        private ApiService apiService;
        // private Evento eventt { get; set; }
        #endregion

        #region Properties
        public Evento Eventt
        { get; set; }
        #endregion

        #region Commands
        public ICommand DetalleEventoCommand
        {
            get
            {
                return new RelayCommand(DetalleEvento);
            }
        }

        private async void DetalleEvento()
        {
            MainViewModel.GetInstance().EventoDeta = new EventoDetalleViewModel(this.clvEmp, this.folioEvento);
            //await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage());
            await App.Navigator.PushAsync(new DetalleEventoTabbedPage());
            //EventoDetallePage

            /*string usuario = this.clvEmp.ToString();
            string folioEvento = this.folioEvento;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;
            }

            var usser = new Evento
            {
                clvEmp = Convert.ToInt32(usuario),
                folioEvento = folioEvento,

            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlEventoMensajeDetalle"].ToString();
            var response = await this.apiService.GetDetalleEvento(url, prefix, controller, usser);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            this.Eventt = (Evento)response.Result;

            if (this.Eventt.clvEdoEvento.Equals(3))
            {
                //autorizado- ir a pantalla de operacion
                MainViewModel.GetInstance().EventoOperacion = new EventoOperacionViewModel(this);
                //await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage());
                await App.Navigator.PushAsync(new EventoOperacionPage());

            }
            else if (this.Eventt.clvEdoEvento.Equals(20))
            {
                // evento cancelado
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Tu evento esta cancelado", "Aceptar");
                return;

            }
            else if (this.Eventt.seeQR)
            {
                // mostrar qr
                PopupNavigation.Instance.PushAsync(new PopupView(this.Eventt.clvEmp.ToString(), this.Eventt.folioEvento,this.Eventt.clvEdoEvento.ToString(), "Pide autorización a través de este código"));
            }
            else if (!this.Eventt.seeQR && this.Eventt.clvEdoEvento.Equals(4))
            {
                // mostrar descripcion de mensaje
                await Application.Current.MainPage.DisplayAlert("Mensaje", this.Eventt.descripcionMensajeEvento, "Aceptar");
                return;
            }*/
        }
        #endregion


        #region Contructors
        public EventoItemViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion
    }
}
