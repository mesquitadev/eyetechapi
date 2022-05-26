using EyeTech.Shipped.Application.AppService.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;

namespace EyeTech.Shipped.Application.AppService.Ambiente
{
    public class CameraAppService: AppServiceBase<Cameras>, ICameraAppService
    {
        private readonly ICameraService _camera;

        public CameraAppService(ICameraService camera)
            :base(camera)
        {
            _camera = camera;
        }
    }
}