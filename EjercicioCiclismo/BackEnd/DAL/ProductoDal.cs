using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Dal
{
    public class ProductoDal
    {

        private string connect;


        public ProductoDal()
        {
            connect = ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString();
        }

        public List<ProductoE> GetList()
        {
            List<ProductoE> productos = new List<ProductoE>();

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Producto", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var Producto = new ProductoE
                            {
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                DepartamentoVentaId = Convert.ToInt32(dr["DepartamentoVentaId"]),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = Convert.ToInt32(dr["Precio"]),
                                Talla = dr["Talla"].ToString(),
                                Color = dr["Color"].ToString(),
                                Cantidad = Convert.ToInt32(dr["CantidadStock"])
                            };

                            // Agregamos el usuario a la lista genreica
                            productos.Add(Producto);
                        }
                    }

                    // Agregamos el ROL
                    //foreach (var u in productos)
                    //{
                    //    query = new SqlCommand("SELECT * FROM rol WHERE id = @id", con);
                    //    query.Parameters.AddWithValue("@id", u.Rol_id);

                    //    using (var dr = query.ExecuteReader())
                    //    {
                    //        dr.Read();
                    //        if (dr.HasRows)
                    //        {
                    //            u.Rol.id = Convert.ToInt32(dr["id"]);
                    //            u.Rol.Nombre = dr["Nombre"].ToString();
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return productos;
        }

        public Tuple<bool, string> Insert(ProductoE producto)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false,"");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.InsertarProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DepartamentoVentaId", SqlDbType.Int).Value = producto.DepartamentoVentaId;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = producto.Nombre;
                    cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = producto.Precio;
                    cmd.Parameters.AddWithValue("@Talla", SqlDbType.NVarChar).Value = producto.Talla;
                    cmd.Parameters.AddWithValue("@Color", SqlDbType.NVarChar).Value = producto.Color;
                    cmd.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = producto.Cantidad;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true,"Insert Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"{ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        public Tuple<bool, string> Update(ProductoE producto)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.ActualizarProductoByProductoId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductoId", SqlDbType.Int).Value = producto.ProductoId;
                    cmd.Parameters.AddWithValue("@DepartamentoVentaId", SqlDbType.Int).Value = producto.DepartamentoVentaId;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = producto.Nombre;
                    cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = producto.Precio;
                    cmd.Parameters.AddWithValue("@Talla", SqlDbType.NVarChar).Value = producto.Talla;
                    cmd.Parameters.AddWithValue("@Color", SqlDbType.NVarChar).Value = producto.Color;
                    cmd.Parameters.AddWithValue("@CantidadStock", SqlDbType.Int).Value = producto.Cantidad;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Insert Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Update Producto \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        public Tuple<bool, string> Delete(int productoId)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.DeleteByProductoId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductoId", SqlDbType.Int).Value = productoId;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Insert Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Delete Producto; ProductoId: {productoId}; \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }
    }
}
