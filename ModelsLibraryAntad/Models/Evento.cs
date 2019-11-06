using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibraryAntad.Models
{
    public class Evento
    {
        public string folioEvento { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public int clvEdoEvento { get; set; }
        public string estadoEvento { get; set; }
        public int clvTipoEvento { get; set; }
        public string tipoEvento { get; set; }
        public int clvEmp { get; set; }
        public string fotoCentroTrabajo { get; set; }
        public string folioCentroTrabajo { get; set; }
        public string nombreCentroTrabajo { get; set; }
        public int clvCadenaCentroTrabajo { get; set; }
        public string cadenaCentroTrabajo { get; set; }
        public string fotoCadenaCentroTrabajo { get; set; }
        public string mensajeEvento { get; set; }
        public string descripcionMensajeEvento { get; set; }
        public bool seeQR { get; set; }
        public bool checkIn { get; set; }
        public bool seeUpdate { get; set; }



        public string agencia { get; set; }
        public string folioProyecto { get; set; }



        public string textoDetalle { get; set; }
        public bool botonDetalle { get; set; }
        public bool verBotonDetalle { get; set; }

        public string contratante { get; set; }
        public int clvContratante { get; set; }
        public string objetivoEvento { get; set; }
        public string puesto { get; set; }
        public int clvPuesto { get; set; }
        public string fechaInicioGeneral { get; set; }
        public string fechaFinalGeneral { get; set; }
        public string dinamica { get; set; }
        public List<RequisitoPersonal> requisitosPersonales { get; set; } //2

        public class RequisitoPersonal
        {
            public string nombreRequisito { get; set; }

        }

        public List<Indumentario> indumentarias { get; set; } //2

        public class Indumentario
        {
            public string nombreIndumentaria { get; set; }
            public string cantidadIndumentaria { get; set; }

        }
        public List<Material> materiales { get; set; } //2

        public class Material
        {
            public string nombreMaterial { get; set; }
            public string cantidadMaterial { get; set; }

        }

        public List<Actividad> actividades { get; set; } //2

        public class Actividad
        {
            public string nombreActividad { get; set; }

        }

        public List<ImagenDinamica> imagenesDinamicas { get; set; } //2

        public class ImagenDinamica
        {
            public string nombreImagen { get; set; }
            public string urlImagen { get; set; }

        }

        public List<ActividadBitacora> Bitacora { get; set; } //2

        public class ActividadBitacora
        {
            public string nombreActividad { get; set; }
            public string horaActividad { get; set; }

        }
    }
}
