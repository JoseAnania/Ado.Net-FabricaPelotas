using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricaPelotas.Models
{
    public class PlantaDto
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; }
        public string NombreFabrica { get; set; }
        public string NombreColor { get; set; }
        public double Superficie { get; set; }

        public PlantaDto(int idPlanta, string nombrePlanta, string nombreFabrica, string nombreColor, double superficie)
        {
            IdPlanta = idPlanta;
            NombrePlanta = nombrePlanta;
            NombreFabrica = nombreFabrica;
            NombreColor = nombreColor;
            Superficie = superficie;
        }

        public PlantaDto()
        {
        }
    }
}