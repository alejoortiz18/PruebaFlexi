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
    public class UsuarioDal
    {
        private string connect;

        public UsuarioDal()
        {
            connect = ConfigurationManager.ConnectionStrings["PedaleaEntities"].ToString();
        }

        public List<UsuarioE> GetList()
        {
            List<UsuarioE> productos = new List<UsuarioE>();

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Usuario", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var Producto = new UsuarioE
                            {
                                ClienteId = Convert.ToInt32(dr["ClienteId"]),
                                Nombre = Convert.ToString(dr["Nombre"].ToString()),
                                Apellidos = Convert.ToString(dr["Apellidos"]),
                                Identificacion = Convert.ToInt32(dr["Identificacion"]),
                                Contrasena = Convert.ToString(dr["Contrasena"].ToString()),
                                Direccion = Convert.ToString(dr["Direccion"])
                            };

                            productos.Add(Producto);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return productos;
        }

        public Tuple<bool, string> Insert(UsuarioE usuario)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.InsertarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = usuario.Nombre;
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = usuario.Apellidos;
                    cmd.Parameters.AddWithValue("@Identificacion", SqlDbType.Int).Value = usuario.Identificacion;
                    cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value = usuario.Direccion;
                    cmd.Parameters.AddWithValue("@Contrasena", SqlDbType.NVarChar).Value = usuario.Contrasena;
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

        public Tuple<bool, string> Update(UsuarioE usuario)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.ActualizarUsuarioByClienteId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteId", SqlDbType.Int).Value = usuario.ClienteId;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.Int).Value = usuario.Nombre;
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = usuario.Apellidos;
                    cmd.Parameters.AddWithValue("@Identificacion", SqlDbType.Int).Value = usuario.Identificacion;
                    cmd.Parameters.AddWithValue("@Contrasena", SqlDbType.NVarChar).Value = usuario.Contrasena;
                    cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value = usuario.Direccion;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Update Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Update Producto \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }

        public Tuple<bool, string> Delete(int clienteId)
        {
            //bool respuesta = false;
            Tuple<bool, string> respuesta = new Tuple<bool, string>(false, "");

            try
            {
                using (var con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("dbo.DeleteUsuarioByClientId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientId", SqlDbType.Int).Value = clienteId;
                    cmd.ExecuteNonQuery();
                    respuesta = new Tuple<bool, string>(true, "Delete Ok");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = new Tuple<bool, string>(false, $"Metodo: Delete Producto; ProductoId: {clienteId}; \n {ex.Message}; \t Recurso {ex.Source}");
            }

            return respuesta;
        }
    }
}
