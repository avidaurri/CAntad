using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class Registro
    {
        public string login { get; set; }
        public string password { get; set; }
        public int clvPuesto { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string email { get; set; }
        public string curp { get; set; }
        public string telefono { get; set; }
        public string descripcionTelefono { get; set; }
        public int clvEstadoCivil { get; set; }
        public string estadoCivil { get; set; }
        public double peso { get; set; }
        public double altura { get; set; }
        public int clvGradoEstudios { get; set; }
        public int clvEstado { get; set; }
        public string estado { get; set; }
        public int clvMunicipio { get; set; }
        public string municipio { get; set; }
        public string colonia { get; set; }
        public string codigoPostal { get; set; }
        public string calle { get; set; }
        public string numeroExterior { get; set; }
        public string numeroInterior { get; set; }
        public int clvBanco { get; set; }
        public string clabe { get; set; }
        public string numeroCuenta { get; set; }
        public string numeroTarjeta { get; set; }
        public string nombreReferenciaUno { get; set; }
        public string telefonoReferenciaUno { get; set; }
        public string nombreReferenciaDos { get; set; }
        public string telefonoReferenciaDos { get; set; }
        public string foto { get; set; }
        public string identificacion { get; set; }
        public string comprobanteDomiciliario { get; set; }
        public bool usuarioRegistrado { get; set; }
        public string mensajeRegistro { get; set; }
        public byte[] ImageArray { get; set; }

        public byte[] IdentificacionArray { get; set; }

        public byte[] ComprobanteArray { get; set; }
    }
}
