using System.Collections.Generic;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;

namespace EyeTech.Shipped.Application.IAppService.Ambiente
{
    public interface IVeiculoAppService: IAppServiceBase<Veiculo>
    {
        bool VerificarPlaca(string placa);
        Veiculo BuscarPorPlaca(string placa);
        IEnumerable<Veiculo> BuscarPorApartamento(string apartamento);
    }
}