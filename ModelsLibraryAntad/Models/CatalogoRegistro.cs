using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class CatalogoRegistro
    {
        public List<Banco> listaBancos { get; set; } //2
        public List<EstadoCivil> listaEdoCivil { get; set; } //2
        public List<GradoEstudios> listaGradoEstudios { get; set; } //2
        public List<Estados> listaEstados { get; set; } //2
        public List<Municipio> listaMunicipios { get; set; } //2
        public List<Region> listaRegiones { get; set; } //2

        public List<Puesto> listaPuestos { get; set; } //2

        public class Puesto
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class Banco
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class EstadoCivil
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class GradoEstudios
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class Estados
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class Municipio
        {
            public int key { get; set; }
            public string value { get; set; }
        }

        public class Region
        {
            public int key { get; set; }
            public string value { get; set; }
        }

    }
}
