using System;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class VisitanteViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        public ApartamentoViewModel Apartamento { get; set; }
        public string ClienteId { get; set; }
        public string ApartamentoId { get; set; }
        public bool? Enviado { get; set; }
        public bool Motorizado { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
