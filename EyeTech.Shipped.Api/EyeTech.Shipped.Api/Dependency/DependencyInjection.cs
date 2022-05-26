using EyeTech.Shipped.Application.AppService;
using EyeTech.Shipped.Application.AppService.Ambiente;
using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;
using EyeTech.Shipped.Domain.Services.Ambiente;
using EyeTech.Shipped.Domain.Services.App;
using EyeTech.Shipped.Infra.Repository.Ambiente;
using EyeTech.Shipped.Infra.Repository.App;
using Microsoft.Extensions.DependencyInjection;

namespace EyeTech.Shipped.Api.Dependency
{
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddSingleton(typeof(IUsuarioAppService), typeof(UsuarioAppService));
            services.AddSingleton(typeof(IPerfilAppService), typeof(PerfilAppService));
            services.AddSingleton(typeof(IApartamentoAppService), typeof(ApartamentoAppService));
            services.AddSingleton(typeof(IClienteAppService), typeof(ClienteAppService));
            services.AddSingleton(typeof(IMenuAppService), typeof(MenuAppService));
            services.AddSingleton(typeof(IMoradorAppService), typeof(MoradorAppService));
            services.AddSingleton(typeof(IVisitantesAppService), typeof(VisitanteAppService));
            services.AddSingleton(typeof(IVeiculoAppService), typeof(VeiculoAppService));
            services.AddSingleton(typeof(ICameraAppService), typeof(CameraAppService));
            services.AddSingleton(typeof(IVersionDataBaseAppService), typeof(VersionDataBaseAppService));
            services.AddSingleton(typeof(IPortariaAppService), typeof(PortariaAppService));


            services.AddSingleton(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddSingleton(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddSingleton(typeof(IPerfilService), typeof(PerfilService));
            services.AddSingleton(typeof(IApartamentoService), typeof(ApartamentoService));
            services.AddSingleton(typeof(IClienteService), typeof(ClienteService));
            services.AddSingleton(typeof(IMenuService), typeof(MenuService));
            services.AddSingleton(typeof(IMoradorService), typeof(MoradorService));
            services.AddSingleton(typeof(IVisitanteService), typeof(VisitanteService));
            services.AddSingleton(typeof(IVeiculoService), typeof(VeiculoService));
            services.AddSingleton(typeof(ICameraService), typeof(CameraService));
            services.AddSingleton(typeof(IVersionDataBaseService), typeof(VersionDataBaseService));
            services.AddSingleton(typeof(IPortariaService), typeof(PortariaService));


            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddSingleton(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddSingleton(typeof(IPerfilRepository), typeof(PerfilRepository));
            services.AddSingleton(typeof(IApartamentoRepository), typeof(ApartamentoRepository));
            services.AddSingleton(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddSingleton(typeof(IMenuRepository), typeof(MenuRepository));
            services.AddSingleton(typeof(IMoradorRepository), typeof(MoradorRepository));
            services.AddSingleton(typeof(IVisitantesRepository), typeof(VisitanteRepository));
            services.AddSingleton(typeof(IVeiculoRepository), typeof(VeiculoRepository));
            services.AddSingleton(typeof(ICameraRepository), typeof(CameraRepository));
            services.AddSingleton(typeof(IVersionDataBaseRespository), typeof(VersionDataBaseRepository));
            services.AddSingleton(typeof(IPortariaRepository), typeof(PortariaRepository));
        }
    }
}