
using Dal;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clss
{
    public class ProductoBL
    {
        private ProductoDal productoDal = new ProductoDal();

        public List<ProductoE> GetList()
        {
            return productoDal.GetList();
        }

        public Tuple<bool, string> Insert(ProductoE producto)
        {
           return productoDal.Insert(producto);
        }
    }
}
