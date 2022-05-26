using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.App
{
    public class VersionDataBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Versao { get; set; }
        public DateTime Data { get; set; }
    }
}