using CapaDato;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_Producto
    {
        // Clase de negocio para manejar los usuarios
        
            private CD_Producto objcd_usuario = new CD_Producto();

            public List<Producto> Listar()
            {
                return objcd_usuario.Listar();
            }

            public int Registrar(Producto obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                if (obj.Codigo == "")
                {
                    Mensaje += "Es necesario el codigo del producto\n";
                }

                if (obj.Nombre == "")
                {
                    Mensaje += "Es necesario el nombre del producto\n";
                }

                if (obj.Descripcion == "")
                {
                    Mensaje += "Es necesario la descripcion del producto\n";
                }

                if (Mensaje != string.Empty)
                {
                    return 0; // Si hay errores, no se registra el usuario
                }
                else
                {
                    return objcd_usuario.Registrar(obj, out Mensaje);
                }


            }

            public bool Editar(Producto obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                if (obj.Codigo == "")
                {
                    Mensaje += "Es necesario el codigo del producto\n";
            }

                if (obj.Nombre == "")
                {
                    Mensaje += "Es necesario el nombre del producto\n";
            }

                if (obj.Descripcion == "")
                {
                    Mensaje += "Es necesario la descripcion del producto\n";
            }

                if (Mensaje != string.Empty)
                {
                    return false; // Si hay errores, no se registra el usuario
                }
                else
                {
                    return objcd_usuario.Editar(obj, out Mensaje);
                }

            }

            public bool Eliminar(Producto obj, out string Mensaje)
            {
                return objcd_usuario.Eliminar(obj, out Mensaje);
            }
   }
}
