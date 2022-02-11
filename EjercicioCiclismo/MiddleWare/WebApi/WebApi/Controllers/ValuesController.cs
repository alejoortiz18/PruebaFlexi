using Business.Clss;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
   // public class ValuesController : ApiController
    public class ProductoController : ApiController
    {

        private ProductoBL producto = new ProductoBL();

        
        [Route("Producto/GetList")]
        public List<ProductoE> GetList()
        {
           // List<ProductoE> result = producto.GetList();
            return producto.GetList();
        }

        [Route("Producto/Insert")]
        public Tuple<bool, string> Insert(ProductoE prod)
        {
            Tuple<bool, string> result =  producto.Insert(prod);
            return result;
        }
    }
}