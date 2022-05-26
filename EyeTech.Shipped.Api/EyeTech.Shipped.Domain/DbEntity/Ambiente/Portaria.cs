using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Domain.DbEntity.Ambiente
{
    public class Portaria
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public string ApartamentoId { get; set; }
        public bool Alerta { get; set; }
        public string VisitaId { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public Veiculo Veiculo { get; set; }
        public string Imagem { get; set; }
        public bool Identificado { get; set; }
        public bool Morador { get; set; }
    }
}