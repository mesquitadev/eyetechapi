using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Application.IAppService.App
{
    public interface IUsuarioAppService: IAppServiceBase<Usuario>
    {
        Usuario Login(string senha, string login);
    }
}