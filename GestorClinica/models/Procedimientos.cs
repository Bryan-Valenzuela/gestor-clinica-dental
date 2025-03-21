using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica.models
{
    class Procedimientos
    {
        static public int Id_Procedimiento { get; set; }
        public string nombre { get; set; }
        public double duracion { get; set; }
        public double costo { get; set; }

        public void setearVariables()
        {
            Id_Procedimiento = int.Parse("");
            nombre = "";
            duracion = int.Parse("");
            costo = int.Parse("");
        }

    }
}
