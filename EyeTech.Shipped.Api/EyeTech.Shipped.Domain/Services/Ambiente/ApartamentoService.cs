using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class ApartamentoService: ServiceBase<Apartamento>, IApartamentoService
    {
        private readonly IApartamentoRepository _apartamento;

        public ApartamentoService(IApartamentoRepository apartamento)
            :base(apartamento)
        {
            _apartamento = apartamento;
        }
    }
}