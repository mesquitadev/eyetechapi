using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class ClienteService: ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _cliente;

        public ClienteService(IClienteRepository cliente)
            :base(cliente)
        {
            _cliente = cliente;
        }
    }
}