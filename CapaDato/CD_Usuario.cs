using CapaEntidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class CD_Usuario
    {
        // Método para registrar un nuevo usuario
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario,u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {

                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() {IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() },
                            });
                        }
                    }

                } catch (Exception )
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }
        // Metodo para registrar un nuevo usuario
        public int Registrar(Usuario obj, out String Mensaje) 
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) 
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAUSUARIO", oconexion);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo", obj.Correo);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("IdUsuarioResultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }

                try { 
            } catch (Exception ex)
            {
                Mensaje = ex.Message;
                idusuariogenerado = 0;
            }

            return idusuariogenerado;
        }

        // Método para editar un usuario existente
        public bool Editar(Usuario obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                cmd.Parameters.AddWithValue("Documento", obj.Documento);
                cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo", obj.Correo);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["IdUsuarioResultado"].Value);
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

        // Método para eliminar un usuario existente
        public bool Eliminar(Usuario obj, out String Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);
                cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();

                cmd.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(cmd.Parameters["IdUsuarioResultado"].Value);
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