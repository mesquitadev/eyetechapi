using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.App
{
    public class Perfil
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string Nome { get; set; }
        public string ClienteId { get; set; }
        public int Nivel { get; set; }
        public bool Status { get; set; }
        public List<string> MenuId { get; set; }
    }
}