using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFServicioWeb.Controllers
{
    public class TarjetaController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Tarjeta tarjeta)
        {
            if (tarjeta.agregarTarjeta("Insertar"))
            {
                var message = string.Format("Se guardó con éxito la tarjeta");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("No se guardó la tarjeta, verifique los datos.");
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, message);
            }
        }

        public HttpResponseMessage Put(string id, [FromBody] Tarjeta tarjeta)
        {
            int resultado = tarjeta.verificarTarjeta("Actualizar");
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
