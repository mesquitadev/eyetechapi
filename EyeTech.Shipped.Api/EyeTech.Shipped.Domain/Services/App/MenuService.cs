using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class MenuService: ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menu;
        public MenuService(IMenuRepository menu)
            :base(menu)
        {
            _menu = menu;
        }
    }
}