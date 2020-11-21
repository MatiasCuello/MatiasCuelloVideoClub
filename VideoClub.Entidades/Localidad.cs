using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }
        public String NombreLocalidad { get; set; }
        public Provincia Provincia { get; set; }
    }
}
