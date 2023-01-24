using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenNet.Controllers.Request
{

    public class AgruparAsociadasRequest
    {
        public List<AsociadasDistrubuidoras> Entrada { get; set; }
    }

    public class AsociadasDistrubuidoras
    {
        public string Asociada { get; set; }
        public string Distribuidora { get; set; }
    }

}