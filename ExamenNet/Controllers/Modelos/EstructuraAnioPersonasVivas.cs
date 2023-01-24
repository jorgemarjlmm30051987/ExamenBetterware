using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenNet.Controllers.Modelos
{
    public class EstructuraAnioPersonasVivas
    {
        public int Anio { get; set; }
        public int PersonasVivas { get; set; }
    }

    public class AniosNacimientoDefuncion
    {
        public int AnioNacimiento { get; set; }
        public int AnioDefuncion { get; set; }
    }
}