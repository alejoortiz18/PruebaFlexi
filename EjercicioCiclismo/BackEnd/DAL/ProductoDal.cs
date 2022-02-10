using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Dal
{
    public class ProductoDal
    {

        public List<ProductoE> GetList()
        {
            List<ProductoE> productos = new List<ProductoE>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString()))
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




        public ProductoE GetListProducto()
        {
            List<ProductoE> listProducto = new List<ProductoE>();
            ProductoE Producto = new ProductoE();

            try
            {
                string connect = ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString();

                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Producto",con);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            Producto.ProductoId = Convert.ToInt32( dr["ProductoId"]);
                            Producto.DepartamentoVentaId = Convert.ToInt32( dr["DepartamentoVentaId"]);
                            Producto.Nombre = dr["Nombre"].ToString();
                            Producto.Precio = Convert.ToInt32( dr["Precio"]);
                            Producto.Talla = dr["Talla"].ToString();
                            Producto.Color = dr["Color"].ToString();
                            Producto.Cantidad = Convert.ToInt32( dr["CantidadStock"]);
                            //listProducto.Add(Producto);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                
            }
            return Producto;
        }
    }
}
