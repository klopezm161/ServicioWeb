using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFServicioWeb.Controllers
{
    public class ActualizarTarjetaController : ApiController
    {
        public HttpResponseMessage Put(string id, [FromBody] ActualiarTarjeta tarjeta)
        {
            int resultado = tarjeta.actualizarTarjetaMonto("Actualizar");
            if (resultado == -1)
            {
                var message = string.Format("Numero de tarjeta invalido");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado == -2)
            {
                var message = string.Format("Fecha de expiración no valida o la tarjeta expiró");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado == -3)
            {
                var message = string.Format("CVV incorrecto");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado == -5)
            {
                var message = string.Format("Fondos insuficientes");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("Tarjeta aceptada");
                return Request.CreateResponse(HttpStatusCode.OK, message);

            }


        }
    }
}
