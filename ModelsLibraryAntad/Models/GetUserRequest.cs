using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class GetUserRequest
    {
        public string User { get; set; }

        public int clvEmp { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}
