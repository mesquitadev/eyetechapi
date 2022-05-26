using System.Collections.Generic;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class VeiculoService: ServiceBase<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculo;

        public VeiculoService(IVeiculoRepository veiculo)
            :base(veiculo)
        {
            _veiculo = veiculo;
        }

        public bool VerificarPlaca(string placa)
        {
            return _veiculo.VerificarPlaca(placa);
        }

        public Veiculo BuscarPorPlaca(string placa)
        {
            return _veiculo.BuscarPorPlaca(placa);
        }

        public IEnumerable<Veiculo> BuscarPorApartamento(string apartamento)
        {
            return _veiculo.BuscarPorApartamento(apartamento);
        }
    }
}