using EyeTech.Shipped.Domain.DbEntity.App;

namespace EyeTech.Shipped.Domain.Interfaces.IRepository.App
{
    public interface IVersionDataBaseRespository: IRepositoryBase<VersionDataBase>
    {
        bool BuscarVersao(string versao);
    }
}