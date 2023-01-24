using ExamenNet.Controllers.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNet.Controllers.Interfaces
{
    public interface IInegiHerramientas
    {
        List<AniosNacimientoDefuncion> ConvertirMatrizaLista(int[,] matriz);
    }
}
