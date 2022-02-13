using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FacturaXUsuario
    {
        public int FacturaXUsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaCompra { get; set; }
        public int Descuento { get; set; }
        public int ValorTotal { get; set; }
        //public FacturaE Factura { get; set; }

    }

    public class FacturaE
    {
        public int FacturaId { get; set; }
        public int FacturaXUsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        //public ProductoE producto { get; set; }
        
    }
}
