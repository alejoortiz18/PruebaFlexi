using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductoE
    {
        public int ProductoId { get; set; }
        public int DepartamentoVentaId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public int Cantidad { get; set; }
    }
}
