using Entidades_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos
{
    public interface IAccesoMongo
    {

        bool AgregarRegistroBitacora(Accion registro);

        List<Accion> ObtenerBitacoraCompleta();
    }
}
