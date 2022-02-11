using Business.Clss;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioBL usuario = new UsuarioBL();


        [Route("Usuario/GetList")]
        public List<UsuarioE> GetList()
        {
            // List<ProductoE> result = producto.GetList();
            return usuario.GetList();
        }

        [Route("Usuario/Insert")]
        public Tuple<bool, string> Insert(UsuarioE user)
        {
            Tuple<bool, string> result = usuario.Insert(user);
            return result;
        }

        [Route("Usuario/Update")]
        public Tuple<bool, string> Update(UsuarioE user)
        {
            Tuple<bool, string> result = usuario.Update(user);
            return result;
        }

        [Route("Usuario/Delete")]
        public Tuple<bool, string> Delete(int clienteId)
        {
            Tuple<bool, string> result = usuario.Delete(clienteId);
            return result;
        }
    }
}