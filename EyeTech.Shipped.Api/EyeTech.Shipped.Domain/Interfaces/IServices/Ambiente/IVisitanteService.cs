using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente
{
    public interface IVisitanteService: IServiceBase<Visitante>
    {
        Visitante BuscarPorPlaca(string placa);
    }
}