using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricaPelotas.Models
{
    public class Planta
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; }
        public int IdFabrica { get; set; }
        public int IdColor { get; set; }
        public decimal Superficie { get; set; }

        public Planta(int idPlanta, string nombrePlanta, int idFabrica, int idColor, decimal superficie)
        {
            IdPlanta = idPlanta;
            NombrePlanta = nombrePlanta;
            IdFabrica = idFabrica;
            IdColor = idColor;
            Superficie = superficie;
        }

        public Planta()
        {
        }
    }
}