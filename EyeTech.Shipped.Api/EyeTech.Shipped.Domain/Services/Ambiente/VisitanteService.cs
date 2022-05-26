using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class VisitanteService: ServiceBase<Visitante>, IVisitanteService
    {
        private readonly IVisitantesRepository _visitantes;

        public VisitanteService(IVisitantesRepository visitantes)
            :base(visitantes)
        {
            _visitantes = visitantes;
        }

        public Visitante BuscarPorPlaca(string placa)
        {
            return _visitantes.BuscarPorPlaca(placa);
        }
    }
}