using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenNet.Controllers.Modelos;

namespace ExamenNet.Controllers.Interfaces
{
    interface IAgruparAsociadasHerramientas
    {
        List<RelacionDistrubuidorAsociadas> RelacionDistrubuidorAsociada(string[,] matriz);
    }
}