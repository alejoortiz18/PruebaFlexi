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
        private DepartamentoBL dep = new DepartamentoBL();


        [rto.Route("Departamento/GetList")]
        public List<DepartamentoE> GetList()
        {
            // List<ProductoE> result = producto.GetList();
            return dep.GetList();
        }

        [rto.Route("Departamento/Insert")]
        public Tuple<bool, string> Insert(string nombreDepartamento)
        {
            Tuple<bool, string> result = dep.Insert(nombreDepartamento);
            return result;
        }

        [rto.Route("Departamento/Update")]
        public Tuple<bool, string> Update(DepartamentoE departamento)
        {
            Tuple<bool, string> result = dep.Update(departamento);
            return result;
        }

        [rto.Route("Departamento/Delete")]
        public Tuple<bool, string> Delete(int DepartamentoVentaId)
        {
            Tuple<bool, string> result = dep.Delete(DepartamentoVentaId);
            return result;
        }

    }
}
