using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class FacturaDal
    {
        private string connect;

        public FacturaDal()
        {
            connect = ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString();
        }



        #region metodos para manipular la tabla de FacturaXUsuario

        public Tuple<bool, string, string> InsertFacturaXUsuario(FacturaXUsuario fxu)
        {
            //bool respuesta = false;
            Tuple<bool, string, string> respuesta = new Tuple<bool, string, string>(false, "", "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.InsertarFacturaXUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteId", SqlDbType.Int).Value = fxu.ClienteId;
                    cmd.Parameters.AddWithValue("@FechaCompra", SqlDbType.DateTime).Value = fxu.FechaCompra;
                    cmd.Parameters.AddWithValue("@Descuento", SqlDbType.Int).Value = fxu.Descuento;
                    cmd.Parameters.AddWithValue("@ValorTotal", SqlDbType.NVarChar).Value = fxu.ValorTotal;
                    //var result = cmd.ExecuteReader();
                    
                    var modified = cmd.ExecuteScalar();

                    respuesta = new Tuple<bool, string, string>(true, "Insert Ok", (modified).ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string, string>(false, $"{ex.Message}; \t Recurso {ex.Source}", "");
            }

            return respuesta;
        }

        public Tuple<bool, string> Delete(int facturaxUsuarioId)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.DeleteFacturaxUsuarioxId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FacturaxUsuarioId", SqlDbType.Int).Value = facturaxUsuarioId;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Delete Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Delete Producto; ProductoId: {facturaxUsuarioId}; \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        #endregion


        #region metodos para manipular la tabla de factura

        public Tuple<bool, string> InsertFact(FacturaE fact)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.InsertarFactura", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FacturaXUsuarioId", SqlDbType.Int).Value = fact.FacturaXUsuarioId;
                    cmd.Parameters.AddWithValue("@ProductoId", SqlDbType.Int).Value = fact.ProductoId;
                    cmd.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = fact.Cantidad;
                    var modified = cmd.ExecuteScalar();
                    respuesta = new Tuple<bool, string>(true, $"Insert Ok; Identity {modified}");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"{ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        #endregion

    }
}
