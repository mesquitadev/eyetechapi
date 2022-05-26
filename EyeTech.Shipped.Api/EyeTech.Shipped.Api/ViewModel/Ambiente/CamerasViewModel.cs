using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class CamerasViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public bool Enviado { get; set; }
        public string Qualidade { get; set; }
        public int Porta { get; set; }
        public bool Status { get; set; }
        public string ClienteId { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
