using Business.Clss;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class FacturaController : ApiController
    {
        private FacturaBL factura = new FacturaBL();

        // GET: Factura
        [Route("Factura/Insert")]
        public Tuple<bool, string> Insert(Tuple<FacturaXUsuario, List<ProductoE>> tupla)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false,"");
            if (tupla.Item2.Count!=0)
            {
                result = factura.Insert(tupla.Item1, tupla.Item2);
            }
            return result;
        }
    }
}