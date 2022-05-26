using AutoMapper;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Api.DomainAutoMapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente, ClienteViewModel>();
                cfg.CreateMap<Perfil, PerfilViewModel>();
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Menu, MenusViewModel>();
                cfg.CreateMap<Submenu, SubmenuViewModel>();
                cfg.CreateMap<Apartamento, ApartamentoViewModel>();
                cfg.CreateMap<Veiculo, VeiculoViewModel>();
                cfg.CreateMap<Morador, MoradorViewModel>();
                cfg.CreateMap<Visitante, VisitanteViewModel>();
                cfg.CreateMap<Cameras, CamerasViewModel>();
                cfg.CreateMap<VersionDataBase, VersionDataBaseViewModel>();
                cfg.CreateMap<Portaria, PortariaViewModel>();
            });
            
        }
    }
}
