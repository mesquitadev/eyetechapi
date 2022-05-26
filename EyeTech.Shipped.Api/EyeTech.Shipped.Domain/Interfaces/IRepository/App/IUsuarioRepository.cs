using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Domain.Interfaces.IRepository.App
{
    public interface IUsuarioRepository: IRepositoryBase<Usuario>
    {
        Usuario Login(string senha, string login);
    }
}