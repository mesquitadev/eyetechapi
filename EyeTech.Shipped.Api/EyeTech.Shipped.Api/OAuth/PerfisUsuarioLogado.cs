using AutoMapper;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using System.Collections.Generic;
using EyeTech.Shipped.Domain.DbEntity.App;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.OAuth
{
    public class PerfisUsuarioLogado
    {
        private readonly IPerfilAppService _perfilApp;

        public PerfisUsuarioLogado(IPerfilAppService perfilApp)
        {
            _perfilApp = perfilApp;
        }

        public UsuarioViewModel Perfis(UsuarioViewModel usuario)
        {
            usuario.Perfis = new List<PerfilViewModel>();
            foreach (var p in usuario.PerfisId)
            {
                var perfil = Mapper.Map<Perfil, PerfilViewModel>(_perfilApp.GetId(p.ToString()));
                usuario.Perfis.Add(perfil);
            }
            if (usuario.Perfis.Exists(x => x.Nivel == 3)) { usuario.Nivel = 3; }
            else if (usuario.Perfis.Exists(x => x.Nivel == 2)) { usuario.Nivel = 2; }
            else if (usuario.Perfis.Exists(x => x.Nivel == 1))
            {
                usuario.Nivel = 1;
            }
            else
            {
                usuario.Nivel = 4;
            }
            return usuario;
        }
    }
}
