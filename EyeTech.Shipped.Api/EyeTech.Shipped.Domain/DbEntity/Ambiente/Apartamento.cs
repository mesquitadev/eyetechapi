using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.Ambiente
{
    public class Apartamento
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Numero { get; set; }
        public string Bloco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Enviado { get; set; }
        public string ClienteId { get; set; }
    }
}