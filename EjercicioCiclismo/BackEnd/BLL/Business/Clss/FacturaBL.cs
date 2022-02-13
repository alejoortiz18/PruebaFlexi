using Dal;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clss
{
    public class FacturaBL
    {
        private FacturaDal factura = new FacturaDal();

        public Tuple<bool, string> Insert(FacturaXUsuario fxu, List<ProductoE> lProd)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false,"");
            int valorTotal = 0;

            lProd.ForEach(x=>
            {
                valorTotal = valorTotal + (x.Cantidad * x.Precio);
            });

            fxu.ValorTotal = valorTotal;
            Tuple<bool, string, string> Insertesult = factura.InsertFacturaXUsuario(fxu);

            if (Insertesult.Item1)
            {
                result = new Tuple<bool, string>(true, $"INSERTAR FACTURAXUSUARIO: {Insertesult.Item2}; Identity: {Insertesult.Item3}");
                Tuple<bool, string> resultFact = new Tuple<bool, string>(false,"");
                string msn = "";
                lProd.ForEach(x=>
                {
                    FacturaE fact = new FacturaE();
                    fact.FacturaXUsuarioId = Convert.ToInt32(Insertesult.Item3);
                    fact.ProductoId = x.ProductoId;
                    fact.Cantidad = x.Cantidad;
                    resultFact = factura.InsertFact(fact);
                    msn = msn + resultFact.Item2;
                });

                if (resultFact.Item1)
                {
                    string insertar = result.Item2;
                    result = new Tuple<bool, string>(true, $"{insertar}; INSERTAR FACTURA: {msn} ");
                }
                else
                { 
                    Tuple<bool, string> resultDelete = factura.Delete(Convert.ToInt32(Insertesult.Item3));
                    result = new Tuple<bool, string>(false, $"Insertar facturaxusuario quedó ok; pero al insertar la factora saca el siguiente error: " +
                        $"'{resultFact.Item2}'; se procede a desahacer la transacción");
                }

            }
            else
            {
                result = new Tuple<bool, string>(false, $"No se pudo sealizar el guardado de la factura ");
            }


            return result;
        }
    }
}
