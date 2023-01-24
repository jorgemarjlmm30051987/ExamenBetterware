using ExamenNet.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNet.Controllers.Interfaces
{
    public interface IInegi
    {
        int ObtenerAnioMasPoblado(InegiRequest inegiRequest);
    }
}
