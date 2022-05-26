using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class MoradorService: ServiceBase<Morador>, IMoradorService
    {
        private readonly IMoradorRepository _morador;

        public MoradorService(IMoradorRepository morador)
            :base(morador)
        {
            _morador = morador;
        }
    }
}