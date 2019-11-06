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
    public class RegistroExitosoViewModel : BaseViewModel
    {
        #region Attributes
        private Registro registro;
        // private List<CatalogoRegistro.Municipio> municipiosList { get; set; }
        #endregion

        #region Properties

        public Registro Registro
        {
            get
            {
                return registro;
            }
            set
            {
                registro = value;
            }
        }


        public string NombreReg { get; set; }
        public string PuestoReg { get; set; }


        #endregion

        #region Constructors

        public RegistroExitosoViewModel(Registro reg)
        {
            this.Registro = reg;
            this.NombreReg = reg.nombre;
            if (reg.clvPuesto.Equals(1))
            {//promotor
                this.PuestoReg = "Promotor";
            }
            else if (reg.clvPuesto.Equals(2))
            {
                //supervisor
                this.PuestoReg = "Supervisor";
            }
            else if (reg.clvPuesto.Equals(3))
            {//intramuro
                this.PuestoReg = "Intramuro";
            }


        }



        #endregion

        #region Commands

        public ICommand EnteradoCommand
        {
            get
            {
                return new RelayCommand(Enterado);
            }
        }

        private void Enterado()
        {
            MainViewModel.GetInstance().Login = new LoginViewModel();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        #endregion
    }
}
