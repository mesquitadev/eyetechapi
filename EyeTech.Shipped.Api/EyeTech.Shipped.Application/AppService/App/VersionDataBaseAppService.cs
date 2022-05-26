using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Application.AppService.App
{
    public class VersionDataBaseAppService: AppServiceBase<VersionDataBase>, IVersionDataBaseAppService
    {
        private readonly IVersionDataBaseService _version;

        public VersionDataBaseAppService(IVersionDataBaseService version)
            :base(version)
        {
            _version = version;
        }
        public bool BuscarVersao(string versao)
        {
            return _version.BuscarVersao(versao);
        }
    }
}