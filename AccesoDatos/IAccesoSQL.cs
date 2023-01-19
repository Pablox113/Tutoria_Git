using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades_DAL;

namespace AccesoDatos
{
   public interface IAccesoSQL
    {
        #region Usuarios
        bool AgregarUsuarios(Usuarios P_Entidad);
        bool ModificarUsuarios(Usuarios P_Entidad);
        bool EliminarUsuarios(Usuarios P_Entidad);
        List<Usuarios> ConsultarUsuarios(Usuarios P_Entidad);
        #endregion
    }
}
