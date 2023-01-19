using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades_DAL;
using AccesoDatos.Models;

namespace Negocio_BLL.Logica
{
    public  class Logica : ILogica
    {
        private readonly IAccesoSQL _iaccesoSQL;
        public Logica(AccesoDatosSQL iaccesoSQL)
        {
            _iaccesoSQL = iaccesoSQL;
        }

        #region Usuarios
        public bool AgregarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.AgregarUsuarios(P_Entidad);
        }

        public List<Usuarios> ConsultarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.ConsultarUsuarios(P_Entidad);
        }

        public bool ModificarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.ModificarUsuarios(P_Entidad);
        }

        public bool EliminarUsuarios(Usuarios P_Entidad)
        {
            return _iaccesoSQL.EliminarUsuarios(P_Entidad);
        }


        #endregion
    }
}
