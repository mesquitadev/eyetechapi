using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class MoradorAppService: AppServiceBase<Morador>, IMoradorAppService
    {
        private readonly IMoradorService _morador;

        public MoradorAppService(IMoradorService morador)
            :base(morador)
        {    
            _morador = morador;
        }
    }
}