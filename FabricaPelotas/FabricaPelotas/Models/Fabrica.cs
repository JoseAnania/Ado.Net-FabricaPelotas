using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricaPelotas.Models
{
    public class Fabrica
    {
        public int IdFabrica { get; set; }
        public string NombreFabrica { get; set; }

        public Fabrica(int idFabrica, string nombreFabrica)
        {
            IdFabrica = idFabrica;
            NombreFabrica = nombreFabrica;
        }

        public Fabrica()
        {
        }
    }
}