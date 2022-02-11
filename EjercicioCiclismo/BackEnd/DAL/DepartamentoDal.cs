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
    public class DepartamentoDal
    {
        private string connect;

        public DepartamentoDal()
        {
            connect = ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString();
        }

        public List<DepartamentoE> GetList()
        {
            List<DepartamentoE> departamentos = new List<DepartamentoE>();

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM DepartamentoVenta", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var departamento = new DepartamentoE
                            {
                                DepartamentoVentaId = Convert.ToInt32(dr["DepartamentoVentaId"]),
                                Nombre  = Convert.ToString(dr["Nombre"])
                            };

                            departamentos.Add(departamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return departamentos;
        }

        public Tuple<bool, string> Insert(string NombreDepartamento)
        {
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.InsertarDepartamentoVenta", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = NombreDepartamento;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Insert Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"{ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        public Tuple<bool, string> Update(DepartamentoE departamento)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.ActualizarDepartamentoByDepartamentoVentaId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@departamentoVentaId", SqlDbType.Int).Value = departamento.DepartamentoVentaId;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.Int).Value = departamento.Nombre;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Update Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Update Dep Venta \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        public Tuple<bool, string> Delete(int departamentoVentaId)
        {
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.DeleteDepartamentoByDepartamentoVentaId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DepartamentoVentaId", SqlDbType.Int).Value = departamentoVentaId;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Delete Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Delete departamento; departamentoId: {departamentoVentaId}; \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }
    }
}
