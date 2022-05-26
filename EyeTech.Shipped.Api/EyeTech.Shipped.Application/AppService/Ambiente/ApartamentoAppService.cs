using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class ApartamentoAppService: AppServiceBase<Apartamento>, IApartamentoAppService
    {
        private readonly IApartamentoService _apartamento;

        public ApartamentoAppService(IApartamentoService apartamento)
            :base(apartamento)
        {
            _apartamento = apartamento;
        }

    }
}