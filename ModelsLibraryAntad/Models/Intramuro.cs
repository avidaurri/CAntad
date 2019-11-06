using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class Intramuro
    {
        public int clvEmp { get; set; }
        public string empresa { get; set; }
        public string fotoEmpresa { get; set; }
        public string folioCentroTrabajo { get; set; }
        public string nombreCentroTrabajo { get; set; }
        public string fotoCentroTrabajo { get; set; }
        public string distanciaIntramuroCTrabajo { get; set; }
        public bool existeSucursal { get; set; }
        public bool existeOperacion { get; set; }
        public bool errorOperacion { get; set; }
        public string mensajeSucursal { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public bool errorSucursal { get; set; }
        public double latitudSucursal { get; set; }
        public double longitudSucursal { get; set; }
    }
}
