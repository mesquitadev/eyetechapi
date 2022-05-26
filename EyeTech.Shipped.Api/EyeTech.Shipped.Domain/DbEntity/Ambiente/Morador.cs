using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.Ambiente
{
    public class Morador
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataEnvio { get; set; }
        public string ApartamentoId { get; set; }
        public bool Enviado { get; set; }
        public bool Status { get; set; }
        public string ClienteId { get; set; }

    }
}