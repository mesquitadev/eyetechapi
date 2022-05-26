using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IServices.Ambiente;
using EyeTech.Shipped.Domain.Services.App;

namespace EyeTech.Shipped.Domain.Services.Ambiente
{
    public class CameraService: ServiceBase<Cameras>, ICameraService
    {
        private readonly ICameraRepository _camera;

        public CameraService(ICameraRepository camera)
            :base(camera)
        {
            _camera = camera;
        }
    }
}