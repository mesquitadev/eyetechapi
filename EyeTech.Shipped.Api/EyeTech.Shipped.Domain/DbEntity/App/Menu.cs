using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.App
{
    public class Menu
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<Submenu> Submenus { get; set; }
        public string Icone { get; set; }
        public string Url { get; set; }
        public string NomeRouter { get; set; }
        public string Pagina { get; set; }
        public bool Supervisor { get; set; }
        public bool Suporte { get; set; }
        public bool Status { get; set; }
        public bool Publica { get; set; }
        public bool AtivoMenu { get; set; }
    }
}
