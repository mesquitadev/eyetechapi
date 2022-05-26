using System.Collections.Generic;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;

namespace EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente
{
    public interface IVeiculoRepository: IRepositoryBase<Veiculo>
    {
        bool VerificarPlaca(string placa);
        Veiculo BuscarPorPlaca(string placa);
        IEnumerable<Veiculo> BuscarPorApartamento(string apartamento);

    }
}