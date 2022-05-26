using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class PortariaAppService: AppServiceBase<Portaria>, IPortariaAppService
    {
        private readonly IPortariaService _portaria;

        public PortariaAppService(IPortariaService portaria)
            :base(portaria)
        {
            _portaria = portaria;
        }
    }
}