using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Infra.Repository.App;

namespace EyeTech.Shipped.Infra.Repository.Ambiente
{
    public class ApartamentoRepository: RepositoryBase<Apartamento>, IApartamentoRepository
    {
    }
}