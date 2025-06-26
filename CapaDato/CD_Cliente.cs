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
    public class CD_Cliente
    {
        // Método para registrar un nuevo Cliente
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente,Documento, NombreCompleto,Correo,Telefono,Estado from CLIENTE");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }
        // Metodo para registrar un nuevo Cliente
        public int Registrar(Cliente obj, out String Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", oconexion);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo", obj.Correo);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

            try
            {
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                idClientegenerado = 0;
            }

            return idClientegenerado;
        }

        // Método para editar un Cliente existente
        public bool Editar(Cliente obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ModificarCliente", oconexion);
                cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
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

        // Método para eliminar un Cliente existente
        public bool Eliminar(Cliente obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente =@Id", oconexion);
                cmd.Parameters.AddWithValue("@Id", obj.IdCliente);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
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
