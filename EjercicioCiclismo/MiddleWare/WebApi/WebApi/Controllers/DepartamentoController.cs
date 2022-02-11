using Business.Clss;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using rto = System.Web.Http;

namespace WebApi.Controllers
{
    public class DepartamentoController : ApiController
    {
        private ProductoBL producto = new ProductoBL();


        [rto.Route("Departamento/GetList")]
        public List<ProductoE> GetList()
        {
            // List<ProductoE> result = producto.GetList();
            return producto.GetList();
        }

        [rto.Route("Departamento/Insert")]
        public Tuple<bool, string> Insert(ProductoE prod)
        {
            Tuple<bool, string> result = producto.Insert(prod);
            return result;
        }

        [rto.Route("Departamento/Update")]
        public Tuple<bool, string> Update(ProductoE prod)
        {
            Tuple<bool, string> result = producto.Update(prod);
            return result;
        }

        [rto.Route("Departamento/Delete")]
        public Tuple<bool, string> Delete(int productoid)
        {
            Tuple<bool, string> result = producto.Delete(productoid);
            return result;
        }

    }
}
