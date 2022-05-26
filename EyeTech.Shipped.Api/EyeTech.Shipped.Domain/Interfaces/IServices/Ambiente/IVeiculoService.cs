using System.Collections.Generic;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente
{
    public interface IVeiculoService: IServiceBase<Veiculo>
    {
        bool VerificarPlaca(string placa);
        Veiculo BuscarPorPlaca(string placa);
        IEnumerable<Veiculo> BuscarPorApartamento(string apartamento);
    }
}