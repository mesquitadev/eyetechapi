using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Application.AppService.App
{
    public class ClienteAppService: AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _cliente;

        public ClienteAppService(IClienteService cliente)
            :base(cliente)
        {
            _cliente = cliente;
        }
    }
}