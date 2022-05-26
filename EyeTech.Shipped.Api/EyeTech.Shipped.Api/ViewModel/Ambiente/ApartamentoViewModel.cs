using System;
using System.Collections.Generic;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class ApartamentoViewModel
    {
        public string Id { get; set; }
        public string Numero { get; set; }
        public string Bloco { get; set; }
        public string Telefone { get; set; }
        public List<VeiculoViewModel> Veiculos { get; set; }
        public List<MoradorViewModel> Moradores { get; set; }
        public DateTime? DataEnvio { get; set; }
        public bool? Enviado { get; set; }
        public string ClienteId { get; set; }
    }
}