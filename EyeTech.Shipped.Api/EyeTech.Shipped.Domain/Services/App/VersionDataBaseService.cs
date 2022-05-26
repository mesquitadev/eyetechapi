using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class VersionDataBaseService: ServiceBase<VersionDataBase>, IVersionDataBaseService
    {
        private readonly IVersionDataBaseRespository _version;
        public VersionDataBaseService(IVersionDataBaseRespository version)
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