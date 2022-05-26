using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Application.AppService
{
    public class MenuAppService: AppServiceBase<Menu>, IMenuAppService
    {
        private readonly IMenuService _menu;
        public MenuAppService(IMenuService menu)
            :base(menu)
        {
            _menu = menu;
        }
    }
}