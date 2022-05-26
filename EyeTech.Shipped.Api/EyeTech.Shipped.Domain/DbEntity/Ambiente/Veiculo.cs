using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.Ambiente
{
    public class Veiculo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Placa { get; set; }
        public string ApartamentoId { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public bool Status { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Enviado { get; set; }
        public string ClienteId { get; set; }

    }
}