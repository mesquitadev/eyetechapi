using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace EyeTech.Shipped.Domain.DbEntity.App
{
    public class Usuario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string ClienteId { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> PerfisId { get; set; }
        public DateTime DataExclusao { get; set; }
        public int Nivel { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Enviado { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}