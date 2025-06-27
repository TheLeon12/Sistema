using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class CD_Proveedor
    {
        // Método para registrar un nuevo Proveedor
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }
        // Metodo para registrar un nuevo Proveedor
        public int Registrar(Proveedor obj, out String Mensaje)
        {
            int idProveedorgenerado = 0;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarProveedor", oconexion);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                cmd.Parameters.AddWithValue("Correo", obj.Correo);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

            try
            {
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                idProveedorgenerado = 0;
            }

            return idProveedorgenerado;
        }

        // Método para editar un Proveedor existente
        public bool Editar(Proveedor obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ModificarProveedor", oconexion);
                cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                cmd.Parameters.AddWithValue("Correo", obj.Correo);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

            try
            {
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        // Método para eliminar un Proveedor existente
        public bool Eliminar(Proveedor obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarProveedor", oconexion);
                cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

            try
            {
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
