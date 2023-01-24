using ExamenNet.Controllers.Request;
using ExamenNet.Controllers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNet.Controllers.Interfaces
{
    public interface IAgruparAsociadas
    {
        List<AgruparAsociadasResponse> ObtenerRelacionDistribuidoryAsociadas(AgruparAsociadasRequest agruparAsociadasRequest);
    }
}
