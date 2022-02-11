using Dal;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clss
{
    public class UsuarioBL
    {
        private UsuarioDal productoDal = new UsuarioDal();

        public List<UsuarioE> GetList()
        {
            return productoDal.GetList();
        }

        public Tuple<bool, string> Insert(UsuarioE producto)
        {
            return productoDal.Insert(producto);
        }

        public Tuple<bool, string> Update(UsuarioE producto)
        {
            return productoDal.Update(producto);
        }

        public Tuple<bool, string> Delete(int productoId)
        {
            return productoDal.Delete(productoId);
        }
    }
}
