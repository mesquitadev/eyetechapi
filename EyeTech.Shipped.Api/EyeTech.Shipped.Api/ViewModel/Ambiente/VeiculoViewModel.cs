using System;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class VeiculoViewModel
    {
        public string Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Taxa { get; set; }
        public string Modelo { get; set; }
        public string Imagem { get; set; }
        public string ApartamentoId { get; set; }
        public ApartamentoViewModel Apartamento { get; set; }
        public string ClienteId { get; set; }
        public DateTime? DataEnvio { get; set; }
        public bool Enviado { get; set; }
        public bool Status { get; set; }
    }
}