using System.Collections.Generic;
using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class VeiculoAppService: AppServiceBase<Veiculo>, IVeiculoAppService
    {
        private readonly IVeiculoService _veiculo;
        public VeiculoAppService(IVeiculoService veiculo)
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