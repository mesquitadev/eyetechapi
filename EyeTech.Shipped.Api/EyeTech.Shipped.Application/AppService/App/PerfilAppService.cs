using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Application.AppService.App
{
    public class PerfilAppService: AppServiceBase<Perfil>, IPerfilAppService
    {
        private readonly IPerfilService _perfil;

        public PerfilAppService(IPerfilService perfil)
            :base(perfil)
        {
            _perfil = perfil;
        }
    }
}