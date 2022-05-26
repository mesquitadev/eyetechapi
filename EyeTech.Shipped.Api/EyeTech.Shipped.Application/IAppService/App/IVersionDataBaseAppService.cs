using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Application.IAppService.App
{
    public interface IVersionDataBaseAppService: IAppServiceBase<VersionDataBase>
    {
        bool BuscarVersao(string versao);
    }
}