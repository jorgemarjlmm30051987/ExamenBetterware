using ExamenNet.Controllers.Modelos;
using ExamenNet.Controllers.Request;
using ExamenNet.Controllers.Response;
using ExamenNet.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenNet.Controllers.Services
{
    public class ExamenBetterWareServices: IAgruparAsociadas, IInegi, IInegiHerramientas, IAgruparAsociadasHerramientas
    {
        public List<AgruparAsociadasResponse> ObtenerRelacionDistribuidoryAsociadas(AgruparAsociadasRequest agruparAsociadasRequest)
        {
            //variables para mostrar el resultado de la relacion en el response            
            List<AgruparAsociadasResponse> lstRelacionDistAsocResponse = new List<AgruparAsociadasResponse>();

            //obtengo la lista de los distribuidores y asociados de acuerdo al json
            var lstRelacionesDistAsoc = agruparAsociadasRequest.Entrada.ToList();

            //obtengo solo los distribuidores
            var lstDistribuidoras = lstRelacionesDistAsoc.Select(x => x.Distribuidora).Distinct().ToList();

            //recorro las distribuidoras para agrupar a sus asociadas
            foreach (var distribuidora in lstDistribuidoras)
            {
                AgruparAsociadasResponse agruparRelacionDisAsocResponse = new AgruparAsociadasResponse();
                //obtengo la lista de asociadas por cada distribuidora
                var lstAsociadasPorDistribuidora = lstRelacionesDistAsoc.Where(x => x.Distribuidora == distribuidora).Select(x => x.Asociada).ToList();

                agruparRelacionDisAsocResponse.Distribuidora = distribuidora;
                agruparRelacionDisAsocResponse.Asociadas = lstAsociadasPorDistribuidora;

                lstRelacionDistAsocResponse.Add(agruparRelacionDisAsocResponse);
            }

            return lstRelacionDistAsocResponse;
        }

        public List<RelacionDistrubuidorAsociadas> RelacionDistrubuidorAsociada(string[,] matriz)
        {
            List<RelacionDistrubuidorAsociadas> lstRelacionDistrubuidorAsociadas = new List<RelacionDistrubuidorAsociadas>();

            int i, j = 0;

            for (i = 0; i < matriz.GetLength(0); i++)
            {
                //inicializo la posición en 0 de la columna del renglon que estoy recorriendo para tomar posteriormente el año de nacimiento
                j = 0;

                RelacionDistrubuidorAsociadas relacionDistrubuidorAsociadas = new RelacionDistrubuidorAsociadas();

                //guardo el año de nacimiento ya que es la primera posición del arreglo
                relacionDistrubuidorAsociadas.Asociada = matriz[i, j];

                while (j < matriz.GetLength(1))
                {
                    //guardo el año de defunción ya que es la segunda posición del arreglo
                    relacionDistrubuidorAsociadas.Distribuidor = matriz[i, j];
                    j = j + 1;
                }

                lstRelacionDistrubuidorAsociadas.Add(relacionDistrubuidorAsociadas);
            }

            return lstRelacionDistrubuidorAsociadas;
        }

        public int ObtenerAnioMasPoblado(InegiRequest inegiRequest)
        {
            //Datos utilizados para el response
            InegiResponse inegiResponse = new InegiResponse();

            //Estructura donde guardare el total de personas vivas por año
            List<EstructuraAnioPersonasVivas> lstEstructuraPersonasVivas = new List<EstructuraAnioPersonasVivas>();

            //Convierto la matriz a la lista de Anio Nacimiento y Anio Defuncion para manejar mas facilmente la información
            var lstAnioNacimientoDefuncion = ConvertirMatrizaLista(inegiRequest.Entrada);

            //obtengo el minimo anio de nacimiento y el maximo anio de defuncion
            var minAnio = lstAnioNacimientoDefuncion.Min(x => x.AnioNacimiento);
            var maxAnio = lstAnioNacimientoDefuncion.Max(x => x.AnioDefuncion);

            for (int i = minAnio; i <= maxAnio; i++)
            {
                //recorro anio por anio y voy contando cuantas personas hay vivas por cada anio
                var lstPersonasAnio = lstAnioNacimientoDefuncion.Where(x => x.AnioNacimiento <= i && x.AnioDefuncion >= i).ToList();

                int totalPersonasVivas = lstPersonasAnio.Count();

                //Creo un objeto para guardar la información por anio y despues guardarlo en una lista
                EstructuraAnioPersonasVivas estructuraAnioPersonasVivas = new EstructuraAnioPersonasVivas();
                estructuraAnioPersonasVivas.Anio = i;
                estructuraAnioPersonasVivas.PersonasVivas = totalPersonasVivas;

                lstEstructuraPersonasVivas.Add(estructuraAnioPersonasVivas);
            }

            //Guardo  el año con mas personas vivas en caso de que sean varios años con el mismo numero tomo el primer 
            inegiResponse.Anio = lstEstructuraPersonasVivas.OrderByDescending(x => x.PersonasVivas).ThenBy(x => x.Anio).Select(x => x.Anio).FirstOrDefault();

            return inegiResponse.Anio;
        }

        public List<AniosNacimientoDefuncion> ConvertirMatrizaLista(int[,] matriz)
        {
            //objeto de respuesta
            List<AniosNacimientoDefuncion> lstAniosNacimientoDefuncion = new List<AniosNacimientoDefuncion>();

            int i, j = 0;

            for (i = 0; i < matriz.GetLength(0); i++)
            {
                //inicializo la posición en 0 de la columna del renglon que estoy recorriendo para tomar posteriormente el año de nacimiento
                j = 0;

                AniosNacimientoDefuncion aniosNacimientoDefuncion = new AniosNacimientoDefuncion();

                //guardo el año de nacimiento ya que es la primera posición del arreglo
                aniosNacimientoDefuncion.AnioNacimiento = matriz[i, j];

                while (j < matriz.GetLength(1))
                {
                    //guardo el año de defunción ya que es la segunda posición del arreglo
                    aniosNacimientoDefuncion.AnioDefuncion = matriz[i, j];
                    j = j + 1;
                }

                lstAniosNacimientoDefuncion.Add(aniosNacimientoDefuncion);
            }

            return lstAniosNacimientoDefuncion;
        }
    }
}