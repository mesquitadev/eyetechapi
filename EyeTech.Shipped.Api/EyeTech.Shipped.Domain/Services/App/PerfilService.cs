using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class PerfilService: ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository _perfil;

        public PerfilService(IPerfilRepository perfil)
            :base(perfil)
        {
            _perfil = perfil;
        }
    }
}