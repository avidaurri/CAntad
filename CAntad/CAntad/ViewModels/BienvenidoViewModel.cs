using CAntad.Helpers;
using CAntad.Views;
using GalaSoft.MvvmLight.Command;
using ModelsLibraryAntad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CAntad.ViewModels
{
    public class BienvenidoViewModel : BaseViewModel
    {



        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public UserSession urr = JsonConvert.DeserializeObject<UserSession>(Settings.UserSession);

        public string UserName
        {
            get
            {

                return urr.nombre;


            }
        }
        public string ImageUser
        {
            get
            {

                return urr.foto;


            }
        }
        public string Puesto
        {
            get
            {

                return urr.clvPuesto.ToString();


            }
        }
        #endregion

        #region Contructors

        public BienvenidoViewModel()
        {
            LoadMenu();
            //Direccionar();

        }

        private void LoadMenu()
        {
            /*UserSession urr = JsonConvert.DeserializeObject<UserSession>(Settings.UserSession);
            int clvPu = urr.clvPuesto;*/
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            string roo = this.Puesto;

            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_bienvenido",
                PageName = "Bienvenido",
                Title = "Bienvenido",
            });


            if (roo.Equals("3"))
            {

                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misucursal",
                    PageName = "misucursal",
                    Title = "Mi Sucursal",
                });
                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misusuarios",
                    PageName = "misusuarios",
                    Title = "Mis Usuarios",
                });

                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misincidencias",
                    PageName = "misincidencias",
                    Title = "Incidencias",
                });
                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misautorizaciones",
                    PageName = "misautorizaciones",
                    Title = "Mis Autorizaciones",
                });
                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misrechazos",
                    PageName = "misrechazos",
                    Title = "Mis Rechazos",
                });
            }
            else if (roo.Equals("1"))
            {
                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misucursal",
                    PageName = "miseventos",
                    Title = "Mis Eventos",
                });

                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misincidencias",
                    PageName = "misincidencias",
                    Title = "Incidencias",
                });
                this.Menu.Add(new MenuItemViewModel
                {
                    Icon = "ic_misautorizaciones",
                    PageName = "mihistorial",
                    Title = "Mis Historial",
                });

            }




            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Salir",
            });
        }

        #endregion

        #region Command

        [Obsolete]
        public ICommand DireccionarCommand
        {
            get
            {

                return new RelayCommand(Direccionar);

            }
        }

        [Obsolete]
        private async void Direccionar()
        {
            //await Task.Delay(1000);
            string roo = this.Puesto;
            if (roo.Equals("3"))
            {
                //intramuro
                MainViewModel.GetInstance().Intramuro = new IntramuroViewModel();
                //await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage());
                await App.Navigator.PushAsync(new IntramuroPage());
            }
            else if (roo.Equals("1"))
            {
                //promotor
                MainViewModel.GetInstance().Promotor = new PromotorViewModel();
                //await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage());
                await App.Navigator.PushAsync(new PromotorPage());
            }
        }

        #endregion
    }
}
