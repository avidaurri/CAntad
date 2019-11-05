using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class UserSession
    {
        public int clvEmp { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public int clvGen { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string foto { get; set; }
        public int clvPuesto { get; set; }
        public string puesto { get; set; }
        public string mensajeLogin { get; set; }
        public bool seLogeo { get; set; }

    }
}
