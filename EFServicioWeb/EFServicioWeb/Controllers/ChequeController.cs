using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using BLL;

namespace EFServicioWeb.Controllers
{
    public class ChequeController : ApiController
    {
        public HttpResponseMessage Put(string id, [FromBody] Cheque cheque)
        {
            int resultado = cheque.modificarCheque("Actualizar");
            if (resultado == -1)
            {
                var message = string.Format("Numero de cheque invalido");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else if (resultado==-2)
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
