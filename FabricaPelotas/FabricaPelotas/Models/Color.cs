using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabricaPelotas.Models
{
    public class Color
    {
        public int IdColor { get; set; }
        public string NombreColor { get; set; }

        public Color(int idColor, string nombreColor)
        {
            IdColor = idColor;
            NombreColor = nombreColor;
        }

        public Color()
        {
        }
    }
}