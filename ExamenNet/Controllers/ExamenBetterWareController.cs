using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenNet.Controllers.Request;
using ExamenNet.Controllers.Response;
using ExamenNet.Controllers.Interfaces;

namespace ExamenNet.Controllers
{
    [RoutePrefix("api/ExamenBetterWare")]
    public class ExamenBetterWareController : ApiController
    {
        private IAgruparAsociadas _agruparAsociadas;
        private IInegi _inegi;

        public ExamenBetterWareController(IAgruparAsociadas agruparAsociadas, IInegi inegi)
        {
            _agruparAsociadas = agruparAsociadas;
            _inegi = inegi;
        }

        public ExamenBetterWareController()
        {
            _agruparAsociadas = null;
            _inegi = null;
        }

        [Route("agruparAsociadas")]
        [HttpGet]
        public IHttpActionResult AgruparAsociadas([FromBody] AgruparAsociadasRequest agruparAsociadasRequest)
        {
            var resultado = _agruparAsociadas.ObtenerRelacionDistribuidoryAsociadas(agruparAsociadasRequest);

            return Ok(resultado);
        }

        [Route("inegi")]
        [HttpGet]
        public IHttpActionResult Inegi([FromBody] InegiRequest inegiRequest)
        {
            int resultado = _inegi.ObtenerAnioMasPoblado(inegiRequest);

            return Ok(resultado);
        }
    }
}