using CAntad.Helpers;
using CAntad.Services;
using CAntad.Views;
using CAntad.Views.Regis;
using GalaSoft.MvvmLight.Command;
using ModelsLibraryAntad.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CAntad.ViewModels
{
    public class RegistroUnoViewModel : BaseViewModel
    {

        #region Attributes
        private bool isEnabled;
        private MediaFile fileFoto;
        private MediaFile fileIdentificacion;
        private MediaFile fileComprobante;
        private ImageSource imageSourceFoto;
        private ImageSource imageSourceComprobante;
        private ImageSource imageSourceIdentificacion;
        private ApiService apiService;
        private Registro registro;
        private List<CatalogoRegistro.Banco> bancoList { get; set; }
        private List<CatalogoRegistro.EstadoCivil> estadoCivilList { get; set; }
        private List<CatalogoRegistro.GradoEstudios> gradoEstudiosList { get; set; }
        private List<CatalogoRegistro.Estados> estadosList { get; set; }
        private List<CatalogoRegistro.Municipio> municipiosList { get; set; }
        private List<CatalogoRegistro.Region> regionList { get; set; }
        private List<CatalogoRegistro.Puesto> puestoList { get; set; }
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
        public ImageSource ImageSourceFoto
        {
            get { return this.imageSourceFoto; }
            set
            {
                imageSourceFoto = value;
                OnPropertyChanged();
            }
        }

        public ImageSource ImageSourceComprobante
        {
            get { return this.imageSourceComprobante; }
            set
            {
                imageSourceComprobante = value;
                OnPropertyChanged();
            }
        }

        public ImageSource ImageSourceIdentificacion
        {
            get { return this.imageSourceIdentificacion; }
            set
            {
                imageSourceIdentificacion = value;
                OnPropertyChanged();
            }
        }
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
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }
        public int ClvPuesto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Curp { get; set; }
        public string Telefono { get; set; }
        public string DescripcionTelefono { get; set; }
        public int ClvEstadoCivil { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public int ClvGradoEstudios { get; set; }
        public int ClvEstado { get; set; }
        public int ClvMunicipio { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public int ClvBanco { get; set; }
        public string Clabe { get; set; }
        public string NumeroCuenta { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreReferenciaUno { get; set; }
        public string TelefonoReferenciaUno { get; set; }
        public string NombreReferenciaDos { get; set; }
        public string TelefonoReferenciaDos { get; set; }
        public string NombreReferenciaTres { get; set; }
        public string TelefonoReferenciaTres { get; set; }
        public string clabe { get; set; }
        public string foto { get; set; }
        public string identificacion { get; set; }
        public string comprobanteDomiciliario { get; set; }
        public int Puesto { get; set; }
        public string banco { get; set; }
        private string _estadoText { get; set; }
        public string EstadoText
        {
            get
            {
                return _estadoText;
            }
            set
            {
                _estadoText = value;
            }
        }
        private string _puestoText { get; set; }

        public string PuestoText
        {
            get
            {
                return _puestoText;
            }
            set
            {
                _puestoText = value;
            }
        }

        private string _bancoText { get; set; }
        public string BancoText
        {
            get
            {
                return _bancoText;
            }
            set
            {
                _bancoText = value;
            }
        }
        private string _estadocivilText { get; set; }
        public string EstadoCivilText
        {
            get
            {
                return _estadocivilText;
            }
            set
            {
                _estadocivilText = value;
            }
        }
        private string _gradoestudiosText { get; set; }
        public string GradoEstudiosText
        {
            get
            {
                return _gradoestudiosText;
            }
            set
            {
                _gradoestudiosText = value;
            }
        }

        private string _municipioText { get; set; }
        public string MunicipioText
        {
            get
            {
                return _municipioText;
            }
            set
            {
                _municipioText = value;
            }
        }

        private string _regionText { get; set; }
        public string RegionText
        {
            get
            {
                return _regionText;
            }
            set
            {
                _regionText = value;
            }
        }
        private CatalogoRegistro.Banco _selectedBanco;
        public CatalogoRegistro.Banco SelectedBanco
        {
            get
            {
                return _selectedBanco;
            }
            set
            {
                _selectedBanco = value;
                //put here your code  
                BancoText = _selectedBanco.key.ToString();
            }
        }
        private CatalogoRegistro.EstadoCivil _selectedEstadoCivil;
        public CatalogoRegistro.EstadoCivil SelectedEstadoCivil
        {

            get
            {
                return _selectedEstadoCivil;
            }
            set
            {
                _selectedEstadoCivil = value;
                //put here your code  

                EstadoCivilText = _selectedEstadoCivil.value.ToString();

            }
        }

        private CatalogoRegistro.Estados _selectedEstado;
        public CatalogoRegistro.Estados SelectedEstado
        {
            get
            {
                return _selectedEstado;
            }
            set
            {
                _selectedEstado = value;

                //put here your code  
                EstadoText = _selectedEstado.value.ToString();
                cargaMun(_selectedEstado.key.ToString());
            }
        }
        private async void cargaMun(string val)
        {
            this.IsEnabled = false;
            //this.MunicipiosList.Clear();
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                //await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Hubo un problema al cargar tu municipio, por favor selecciona tu estado nuevamente", "Aceptar");
                return;
            }


            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlGetCatalogo"].ToString();// + "?idEstado=0";
            var response = await this.apiService.Post(url, prefix, controller, Convert.ToInt32(val));
            if (!response.IsSuccess)
            {

                //await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Hubo un problema al cargar tu municipio, por favor selecciona tu estado nuevamente", "Mensaje");
                return;
            }
            this.IsEnabled = true;
            CatalogoRegistro cat = new CatalogoRegistro();
            cat = (CatalogoRegistro)response.Result;

            //municipios
            this.MunicipiosList = null;
            this.MunicipiosList = cat.listaMunicipios;

        }
        private CatalogoRegistro.Municipio _selectedMunicipio;
        public CatalogoRegistro.Municipio SelectedMunicipio
        {
            get
            {
                return _selectedMunicipio;
            }
            set
            {
                _selectedMunicipio = value;
                // ????????
                if (_selectedMunicipio != null)
                {
                    MunicipioText = _selectedMunicipio.value.ToString();
                }
                //put here your code  

            }
        }
        public List<CatalogoRegistro.Estados> EstadosList
        {

            get { return this.estadosList; }
            set
            {
                estadosList = value;
                OnPropertyChanged();
            }
        }
        public List<CatalogoRegistro.Municipio> MunicipiosList
        {

            get { return this.municipiosList; }
            set
            {
                municipiosList = value;
                OnPropertyChanged();
            }
        }
        private CatalogoRegistro.GradoEstudios _selectedGradoEstudios;
        public CatalogoRegistro.GradoEstudios SelectedGradoEstudios
        {
            get
            {
                return _selectedGradoEstudios;
            }
            set
            {
                _selectedGradoEstudios = value;
                //put here your code  
                GradoEstudiosText = _selectedGradoEstudios.key.ToString();
            }
        }
        public List<CatalogoRegistro.EstadoCivil> EstadoCivilList
        {

            get { return this.estadoCivilList; }
            set
            {
                estadoCivilList = value;
                OnPropertyChanged();
            }
        }
        public List<CatalogoRegistro.GradoEstudios> GradoEstudiosList
        {

            get { return this.gradoEstudiosList; }
            set
            {
                gradoEstudiosList = value;
                OnPropertyChanged();
            }
        }
        public List<CatalogoRegistro.Region> RegionList
        {

            get { return this.regionList; }
            set
            {
                regionList = value;
                OnPropertyChanged();
            }
        }
        public List<CatalogoRegistro.Puesto> PuestoList
        {

            get { return this.puestoList; }
            set
            {
                puestoList = value;
                OnPropertyChanged();
            }
        }
        public List<CatalogoRegistro.Banco> BancoList
        {

            get { return this.bancoList; }
            set
            {
                bancoList = value;
                OnPropertyChanged();
            }
        }
        private CatalogoRegistro.Puesto _selectedPuesto;
        public CatalogoRegistro.Puesto SelectedPuesto
        {
            get
            {
                return _selectedPuesto;
            }
            set
            {
                _selectedPuesto = value;
                //put here your code  
                PuestoText = _selectedPuesto.key.ToString();
            }
        }

        #endregion

        #region Constructors

        public RegistroUnoViewModel(CatalogoRegistro Catt)
        {
            this.IsEnabled = true;
            this.apiService = new ApiService();
            this.ImageSourceFoto = "ic_camara";
            this.ImageSourceComprobante = "ic_camara";
            this.ImageSourceIdentificacion = "ic_camara";
            CargarCatalogos(Catt);
        }

        private void CargarCatalogos(CatalogoRegistro catt)
        {


            // bancos
            this.BancoList = catt.listaBancos;
            // estados civil
            this.EstadoCivilList = catt.listaEdoCivil;
            // grados de estudios
            this.GradoEstudiosList = catt.listaGradoEstudios;
            //estados
            this.EstadosList = catt.listaEstados;
            //municipios
            //this.MunicipiosList = cat.listaMunicipios;
            //regiones
            this.RegionList = catt.listaRegiones;
            //puesto
            this.PuestoList = catt.listaPuestos;
        }
        #endregion

        #region Commands
        public ICommand CargarImagenCommand
        {
            get
            {
                return new RelayCommand(CargarImagen);
            }
        }

        private async void CargarImagen()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Elegir Imagen",
                "Cancelar",
                null,
                "De Galería",
                "Nueva Foto");

            if (source == "Cancelar")
            {
                this.fileFoto = null;
                return;
            }

            if (source == "Nueva Foto")
            {
                this.fileFoto = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.fileFoto = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.fileFoto != null)
            {
                this.ImageSourceFoto = ImageSource.FromStream(() =>
                {
                    var stream = this.fileFoto.GetStream();
                    return stream;
                });
            }
        }
        public ICommand CargarIdentificacionCommand
        {
            get
            {
                return new RelayCommand(CargarIdentificacion);
            }
        }

        private async void CargarIdentificacion()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Elegir Imagen",
                "Cancelar",
                null,
                "De Galería",
                "Nueva Foto");

            if (source == "Cancelar")
            {
                this.fileIdentificacion = null;
                return;
            }

            if (source == "Nueva Foto")
            {
                this.fileIdentificacion = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.fileIdentificacion = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.fileIdentificacion != null)
            {
                this.ImageSourceIdentificacion = ImageSource.FromStream(() =>
                {
                    var stream = this.fileIdentificacion.GetStream();
                    return stream;
                });
            }
        }

        public ICommand CargarComprobanteCommand
        {
            get
            {
                return new RelayCommand(CargarComprobante);
            }
        }

        private async void CargarComprobante()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Elegir Imagen",
                "Cancelar",
                null,
                "De Galería",
                "Nueva Foto");

            if (source == "Cancelar")
            {
                this.fileComprobante = null;
                return;
            }

            if (source == "Nueva Foto")
            {
                this.fileComprobante = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.fileComprobante = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.fileComprobante != null)
            {
                this.ImageSourceComprobante = ImageSource.FromStream(() =>
                {
                    var stream = this.fileComprobante.GetStream();
                    return stream;
                });
            }
        }
        public ICommand CancelRegCommand
        {
            get
            {
                return new RelayCommand(CancelReg);
            }
        }

        private async void CancelReg()
        {
            var source = await Application.Current.MainPage.DisplayActionSheet(
    "¿Esta seguro que desea salir de la sección registro registro?",
    "SI",
    "NO");

            if (source == "NO")
            {
                //this.fileFoto = null;
                return;
            }
            else
            {

                MainViewModel.GetInstance().Login = new LoginViewModel();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }




        }

        public ICommand IrDosCommand
        {
            get
            {
                return new RelayCommand(IrDos);
            }
        }


        private async void IrDos()
        {

            //Nombre
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu nombre", "Aceptar");
                return;
            }
            if (this.Nombre.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu nombre no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            //ApellidoPaterno
            if (string.IsNullOrEmpty(this.ApellidoPaterno))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu apellido paterno", "Aceptar");
                return;
            }
            if (this.ApellidoPaterno.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu apellido paterno no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            //ApellidoMaterno
            if (string.IsNullOrEmpty(this.ApellidoMaterno))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu apellido materno", "Aceptar");
                return;
            }
            if (this.ApellidoMaterno.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu apellido materno no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            //Curp
            if (string.IsNullOrEmpty(this.Curp))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu CURP", "Aceptar");
                return;
            }
            if (this.Curp.Length > 18)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu curp no debe exceder los 18 caracteres", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidCurp(this.Curp))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe una CURP valida", "Aceptar");
                return;
            }
            //Telefono
            if (string.IsNullOrEmpty(this.Telefono))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu teléfono", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidTel(this.Telefono) || this.Telefono.Length != 10)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un teléfono de 10 dígitos", "Aceptar");
                return;
            }
            //Email
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu email", "Aceptar");
                return;
            }
            if (this.Email.Length > 50)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu email no debe exceder los 50 caracteres", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidEmailAddress(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un email valido", "Aceptar");
                return;
            }
            //ClvPuesto--  this.PuestoText
            if (this.PuestoText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona el puesto que te interesa", "Aceptar");
                return;
            }

            Registro unreg = new Registro();
            unreg.nombre = this.Nombre;
            unreg.apellidoPaterno = this.ApellidoPaterno;
            unreg.apellidoMaterno = this.ApellidoMaterno;
            unreg.curp = this.Curp;
            unreg.telefono = this.Telefono;
            unreg.email = this.Email;
            unreg.clvPuesto = Convert.ToInt32(this.PuestoText);

            this.Registro = unreg;
            //MainViewModel.GetInstance().RegistroDos = new RegistroDosViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroDosPage());

        }
        #endregion
        public ICommand IrTresCommand
        {
            get
            {
                return new RelayCommand(IrTres);
            }
        }

        private async void IrTres()
        {

            if (this.GradoEstudiosText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona tu grado de estudios", "Aceptar");
                return;
            }
            //ClvEstadoCivil --this.EstadoCivilText
            if (this.EstadoCivilText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona tu estado civil", "Aceptar");
                return;
            }
            //Peso
            double ejem = 0;
            if (double.TryParse(this.Peso, out ejem))
            {
                if (double.IsNaN(Convert.ToDouble(this.Peso)) || Convert.ToDouble(this.Peso) == 0 || Convert.ToDouble(this.Peso) > 200 || Convert.ToDouble(this.Peso) < 20)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un peso valido en Kilogramos", "Aceptar");
                    return;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Introduce un Peso valido", "Aceptar");
                return;
            }
            if (this.Peso.Length > 5)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu peso no debe exceder los 5 caracteres", "Aceptar");
                return;
            }
            //Altura
            if (double.TryParse(this.Altura, out ejem))
            {
                if (double.IsNaN(Convert.ToDouble(this.Altura)) || Convert.ToDouble(this.Altura) == 0 || Convert.ToDouble(this.Altura) > 2 || Convert.ToDouble(this.Altura) < .5)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe una altura valida en Metros", "Aceptar");
                    return;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Introduce una Altura valida", "Aceptar");
                return;
            }
            if (this.Altura.Length > 5)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu altura no debe exceder los 5 caracteres", "Aceptar");
                return;
            }
            this.Registro.clvGradoEstudios = Convert.ToInt32(this.GradoEstudiosText);
            this.Registro.estadoCivil = this.EstadoCivilText;
            this.Registro.peso = Convert.ToDouble(this.Peso);
            this.Registro.altura = Convert.ToDouble(this.Altura);

            //MainViewModel.GetInstance().RegistroTres = new RegistroTresViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroTresPage());
        }

        public ICommand IrCuatroCommand
        {
            get
            {
                return new RelayCommand(IrCuatro);
            }
        }

        private async void IrCuatro()
        {


            //Calle
            if (string.IsNullOrEmpty(this.Calle))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe el nombre de tu calle", "Aceptar");
                return;
            }
            if (this.Calle.Length > 50)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu calle no debe exceder los 50 caracteres", "Aceptar");
                return;
            }
            //NumeroExterior
            if (string.IsNullOrEmpty(this.NumeroExterior)) //|| !RegexHelper.IsValidCP(this.NumeroExterior)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu número exterior", "Aceptar");
                return;
            }
            if (this.NumeroExterior.Length > 10)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu número exterior no debe exceder los 10 caracteres", "Aceptar");
                return;
            }
            //NumeroInterior
            if (string.IsNullOrEmpty(this.NumeroInterior))
            {
                this.NumeroInterior = "N/A";

            }
            else
            {
                if (this.NumeroInterior.Length > 10)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu número interior no debe exceder los 10 caracteres", "Aceptar");
                    return;
                }
            }

            //Colonia
            if (string.IsNullOrEmpty(this.Colonia))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu colonia", "Aceptar");
                return;
            }
            if (this.Colonia.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu colonia no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            // ClvEstado -- this.EstadoText
            if (this.EstadoText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona tu estado", "Aceptar");
                return;
            }
            // ClvMunicipio -- this.MunicipioText
            if (this.MunicipioText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona tu municipio", "Aceptar");
                return;
            }
            //CodigoPostal
            if (string.IsNullOrEmpty(this.CodigoPostal))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu código postal", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidCP(this.CodigoPostal) || this.CodigoPostal.Length != 5)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Código postal no valido", "Aceptar");
                return;
            }

            this.Registro.calle = this.Calle;
            this.Registro.numeroExterior = this.NumeroExterior;
            this.Registro.numeroInterior = this.NumeroInterior;
            this.Registro.estado = this.EstadoText;
            this.Registro.municipio = this.MunicipioText;
            this.Registro.codigoPostal = this.CodigoPostal;
            this.Registro.colonia = this.Colonia;

            //MainViewModel.GetInstance().RegistroCuatro = new RegistroCuatroViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroCuatroPage());

        }
        public ICommand IrCincoCommand
        {
            get
            {
                return new RelayCommand(IrCinco);
            }
        }

        private async void IrCinco()
        {
            if (this.Colonia.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu colonia no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            //ClvBanco -- this.BancoText
            if (this.BancoText == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Selecciona un banco", "Aceptar");
                return;
            }
            //Clabe
            if (string.IsNullOrEmpty(this.Clabe))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu cuenta clabe", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidCP(this.Clabe) || this.Clabe.Length != 18)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu cuenta clabe de 18 números", "Aceptar");
                return;
            }

            //NumeroCuenta
            if (string.IsNullOrEmpty(this.NumeroCuenta))
            {
                this.NumeroCuenta = "0";
            }
            else
            {
                if (!RegexHelper.IsValidCP(this.NumeroCuenta) || this.NumeroCuenta.Length > 20)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un número de cuenta no mayor a 20 números", "Aceptar");
                    return;
                }
            }

            //NumeroTarjeta
            if (string.IsNullOrEmpty(this.NumeroTarjeta))
            {
                //await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu número de tarjeta", Languages.Accept);
                //return;
                this.NumeroTarjeta = "0";
            }
            else
            {
                if (!RegexHelper.IsValidCP(this.NumeroTarjeta) || this.NumeroTarjeta.Length != 16)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un número de tarjeta de 16 dígitos", "Aceptar");
                    return;
                }
            }



            this.Registro.clvBanco = Convert.ToInt32(this.BancoText);
            this.Registro.clabe = this.Clabe;
            this.Registro.numeroCuenta = this.NumeroCuenta;
            this.Registro.numeroTarjeta = this.NumeroTarjeta;



           // MainViewModel.GetInstance().RegistroCinco = new RegistroCincoViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroCincoPage());
        }
        public ICommand IrSeisCommand
        {
            get
            {
                return new RelayCommand(IrSeis);
            }
        }

        private async void IrSeis()
        {

            //NombreReferenciaUno
            if (string.IsNullOrEmpty(this.NombreReferenciaUno))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe el nombre de la referencia Uno", "Aceptar");
                return;
            }
            if (this.NombreReferenciaUno.Length > 30)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "La referencia no debe exceder los 30 caracteres", "Aceptar");
                return;
            }
            //TelefonoReferenciaUno
            if (string.IsNullOrEmpty(this.TelefonoReferenciaUno) || this.TelefonoReferenciaUno.Length != 10)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe el teléfono de tu referencia", "Aceptar");
                return;
            }
            if (!RegexHelper.IsValidTel(this.TelefonoReferenciaUno))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe un teléfono de 10 dígitos para tu referencia", "Aceptar");
                return;
            }


            this.Registro.nombreReferenciaUno = this.NombreReferenciaUno;
            this.Registro.telefonoReferenciaUno = this.TelefonoReferenciaUno;



            //MainViewModel.GetInstance().RegistroSeis = new RegistroSeisViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroSeisPage());
        }

        public ICommand IrSieteCommand
        {
            get
            {
                return new RelayCommand(IrSiete);
            }
        }

        private async void IrSiete()
        {
            byte[] imageArray = null;
            if (this.fileFoto != null)
            {
                imageArray = FilesHelper.ReadFully(this.fileFoto.GetStream());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Agrega tu foto de perfil", "Aceptar");
                return;
            }

            this.Registro.ImageArray = imageArray;

            //MainViewModel.GetInstance().RegistroSiete = new RegistroSieteViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroSietePage());
        }

        public ICommand IrOchoCommand
        {
            get
            {
                return new RelayCommand(IrOcho);
            }
        }

        private async void IrOcho()
        {
            //validar identificacion
            byte[] imageArrayIdentificacion = null;
            if (this.fileIdentificacion != null)
            {
                imageArrayIdentificacion = FilesHelper.ReadFully(this.fileIdentificacion.GetStream());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Agrega la foto de tu identificación", "Aceptar");
                return;
            }

            this.Registro.IdentificacionArray = imageArrayIdentificacion;

            //MainViewModel.GetInstance().RegistroOcho = new RegistroOchoViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroOchoPage());

        }

        public ICommand IrNueveCommand
        {
            get
            {
                return new RelayCommand(IrNueve);
            }
        }

        private async void IrNueve()
        {
            byte[] imageArrayComprobante = null;
            if (this.fileComprobante != null)
            {
                imageArrayComprobante = FilesHelper.ReadFully(this.fileComprobante.GetStream());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Agrega la foto de tu comprobante domiciliario", "Aceptar");
                return;
            }
            this.Registro.ComprobanteArray = imageArrayComprobante;

            //MainViewModel.GetInstance().RegistroNueve = new RegistroNueveViewModel(this.Registro);
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroNuevePage());
        }



        public ICommand GuardarRegistroUsuarioCommand
        {
            get
            {
                return new RelayCommand(GuardarRegistroUsuario);
            }
        }

        private async void GuardarRegistroUsuario()
        {
            //Login
            if (string.IsNullOrEmpty(this.Login))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu login o username", "Aceptar");
                return;
            }
            if (this.NumeroInterior.Length > 10)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Tu login o username no debe exceder los 10 caracteres", "Aceptar");
                return;
            }
            //Password
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe tu contraseña", "Aceptar");
                return;
            }
            if (this.Password.Length < 3 || this.Password.Length > 15)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Escribe una contraseña mayor a 3 caracteres y menor a 15 caracteres", "Aceptar");
                return;
            }

            //ConfirmarPassword
            if (string.IsNullOrEmpty(this.ConfirmarPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Confirma tu contraseña", "Aceptar");
                return;
            }
            if (this.ConfirmarPassword.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Escribe una contraseña mayor a 3 caracteres", "Aceptar");
                return;
            }

            //confirmar ambos passwords
            if (this.Password.Equals(this.ConfirmarPassword))
            {

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso de registro", "Las contraseñas no coinciden", "Aceptar");
                return;
            }

            this.Registro.login = this.Login;
            this.Registro.password = this.Password;
            this.Registro.foto = "";
            this.Registro.identificacion = "";
            this.Registro.comprobanteDomiciliario = "";





            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlRegistro"].ToString();
            var response = await this.apiService.Post<Registro>(url, prefix, controller, this.Registro);

            if (!response.IsSuccess)
            {
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Mensaje",
                    response.Message,
                    "Aceptar");
                return;
            }

            this.IsEnabled = true;

            Registro respuesta = (Registro)response.Result;

            await Application.Current.MainPage.DisplayAlert(
            "Mensaje",
           respuesta.mensajeRegistro,
            "Aceptar");

            if (respuesta.usuarioRegistrado)
            {

                MainViewModel.GetInstance().RegistroExitoso = new RegistroExitosoViewModel(this.Registro);
                Application.Current.MainPage = new NavigationPage(new RegistroExitosoPage());
            }

        }
    }
}
