using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFServicioWeb.Controllers
{
    public class ActualizarChequeController : ApiController
    {

        public HttpResponseMessage Put(string id, [FromBody] ActualizarCheque actualizarCheque)
        {
            int resultado = actualizarCheque.modificarCheque("Actualizar");
            if (resultado == -1)
            {
                var message = string.Format("Numero de cheque invalido");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado == -2)
            {
                var message = string.Format("Numero de cuenta invalido");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado == -3)
            {
                var message = string.Format("Fondos insuficientes");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("Cheque aceptado");
                return Request.CreateResponse(HttpStatusCode.OK, message);

            }
        }
    }
}