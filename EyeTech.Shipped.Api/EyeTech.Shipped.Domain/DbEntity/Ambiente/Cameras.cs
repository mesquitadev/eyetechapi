using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.Ambiente
{
    public class Cameras
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Qualidade { get; set; }
        public bool Enviado { get; set; }
        public bool Status { get; set; }
        public int Porta { get; set; }
        public string ClienteId { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
