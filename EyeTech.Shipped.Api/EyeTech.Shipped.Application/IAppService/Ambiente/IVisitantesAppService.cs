using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;

namespace EyeTech.Shipped.Application.IAppService.Ambiente
{
    public interface IVisitantesAppService: IAppServiceBase<Visitante>
    {
        Visitante BuscarPorPlaca(string placa);
    }
}