using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.App
{
    public class Cliente
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Fantasia { get; set; }
        public string Razao { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string EmailContato { get; set; }
        public string EmailFinanceiro { get; set; }

    }
}
