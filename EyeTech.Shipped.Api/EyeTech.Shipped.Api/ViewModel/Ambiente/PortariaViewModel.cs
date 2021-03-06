using System;

namespace EyeTech.Shipped.Api.ViewModel.Ambiente
{
    public class PortariaViewModel
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public string ApartamentoId { get; set; }
        public ApartamentoViewModel Apartamento { get; set; }
        public bool Alerta { get; set; }
        public string VisitaId { get; set; }
        public VisitanteViewModel Visitante { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        public string Imagem { get; set; }
        public bool Identificado { get; set; }
        public bool Morador { get; set; }
    }
}
