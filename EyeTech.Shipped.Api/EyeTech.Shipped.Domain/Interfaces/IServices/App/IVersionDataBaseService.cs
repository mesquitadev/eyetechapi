using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Domain.Interfaces.IServices.App
{
    public interface IVersionDataBaseService: IServiceBase<VersionDataBase>
    {
        bool BuscarVersao(string versao);
    }
}