using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class PortariaService: ServiceBase<Portaria>, IPortariaService
    {
        private readonly IPortariaRepository _portaria;

        public PortariaService(IPortariaRepository portaria)
            :base(portaria)
        {
            _portaria = portaria;
        }
    }
}