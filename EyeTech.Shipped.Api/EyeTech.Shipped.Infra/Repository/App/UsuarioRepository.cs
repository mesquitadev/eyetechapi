using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Repository.App
{
    public class UsuarioRepository: RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario Login(string senha, string login)
        {
            var collection = _context.Usuarios;
            var query = Builders<Usuario>.Filter.Where(x => x.Login.ToLower() == login.ToLower() && x.Senha.ToLower() == senha.ToLower());

            Usuario usu = collection.FindAsync(query).Result.FirstOrDefault();
            return usu;
        }
    }
}