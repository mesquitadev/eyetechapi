using System;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Repository.App
{
    public class VersionDataBaseRepository: RepositoryBase<VersionDataBase>, IVersionDataBaseRespository
    {
        public bool BuscarVersao(string versao)
        {
            try
            {
                var collection = _context.VersionDataBase;
                var query = Builders<VersionDataBase>.Filter.Where(x => x.Versao.ToLower() == versao.ToLower());

                VersionDataBase version = collection.FindAsync(query).Result.FirstOrDefault();
                if (version != null && version.Id != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}