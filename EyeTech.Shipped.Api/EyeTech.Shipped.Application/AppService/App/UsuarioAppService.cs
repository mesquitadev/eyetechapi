using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Application.AppService.App
{
    public class UsuarioAppService: AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuario;

        public UsuarioAppService(IUsuarioService usuario)
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