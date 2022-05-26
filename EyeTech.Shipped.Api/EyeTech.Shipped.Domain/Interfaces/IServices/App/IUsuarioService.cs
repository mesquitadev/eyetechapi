using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Domain.Interfaces.IServices.App
{
    public interface IUsuarioService: IServiceBase<Usuario>
    {
        Usuario Login(string senha, string login);
    }
}