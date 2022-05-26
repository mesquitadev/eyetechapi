using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class UsuarioService:  ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuario;

        public UsuarioService(IUsuarioRepository usuario)
            :base(usuario)
        {
            _usuario = usuario;
        }

        public Usuario Login(string senha, string login)
        {
            return _usuario.Login(senha, login);
        }
    }
}