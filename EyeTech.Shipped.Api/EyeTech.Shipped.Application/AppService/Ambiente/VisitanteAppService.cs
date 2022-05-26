using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class VisitanteAppService: AppServiceBase<Visitante>, IVisitantesAppService
    {
        private readonly IVisitanteService _visitante;

        public VisitanteAppService(IVisitanteService visitante)
            :base(visitante)
        {
            _visitante = visitante;
        }

        public Visitante BuscarPorPlaca(string placa)
        {
            return _visitante.BuscarPorPlaca(placa);
        }
    }
}