using System;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class MoradorViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string ApartamentoId { get; set; }
        public ApartamentoViewModel Apartamento { get; set; }
        public DateTime? DataEnvio { get; set; }
        public bool? Enviado { get; set; }
        public bool Status { get; set; }
        public string ClienteId { get; set; }

    }
}