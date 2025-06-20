using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaEntidades;


namespace CapaNegocio
{
    // Clase de negocio para manejar los permisos de los usuarios
    public class CN_Permiso
    {
        private CD_Permisos objcd_permisos = new CD_Permisos();

        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_permisos.Listar(IdUsuario);
        }
    }
}
