using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenNet.Controllers.Response
{ 
    public class AgruparAsociadasResponse
    {
        public string Distribuidora { get; set; }
        public List<string> Asociadas { get; set; }
    }      
}