using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using AccesoDatos.Models;

namespace Entidades_DAL
{
    public class Accion
    {

        #region Atributos
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjID { get; set; }

        [BsonElement("Accion")]
        public string AccionRealizada { get; set; }
        [BsonElement("Objeto")]
        public string Objeto { get; set; }
        [BsonElement("Instancia")]
        public string Instancia { get; set; }
        [BsonElement("Usuario")]
        public string Usuario { get; set; }
        [BsonElement("Resultado")]
        public string Resultado { get; set; }
        [BsonElement("Momento")]
        public DateTime Momento { get; set; }
        #endregion

        #region Constructor
        public Accion()
        {
            AccionRealizada = string.Empty;
            Objeto = string.Empty;
            Instancia = string.Empty;
            Usuario = string.Empty;
            Resultado = string.Empty;
            Momento = DateTime.MinValue;
        }
        #endregion

        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
    }


}
