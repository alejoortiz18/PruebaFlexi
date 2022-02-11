using Dal;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clss
{
    public class DepartamentoBL
    {
        private DepartamentoDal productoDal = new DepartamentoDal();

        public List<DepartamentoE> GetList()
        {
            return productoDal.GetList();
        }

        public Tuple<bool, string> Insert(string nombreDepartamento)
        {
            return productoDal.Insert(nombreDepartamento);
        }

        public Tuple<bool, string> Update(DepartamentoE producto)
        {
            return productoDal.Update(producto);
        }

        public Tuple<bool, string> Delete(int departamentoVentaId)
        {
            return productoDal.Delete(departamentoVentaId);
        }
    }
}
