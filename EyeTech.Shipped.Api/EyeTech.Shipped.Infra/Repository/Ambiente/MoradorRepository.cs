using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Infra.Repository.App;

namespace EyeTech.Shipped.Infra.Repository.Ambiente
{
    public class MoradorRepository: RepositoryBase<Morador>, IMoradorRepository
    {
        //public IEnumerable<Morador> GetAll(string clientId)
        //{
        //    var collection = _context.Apartamentos;
        //    var group = new BsonDocument{ { "_id", "$Moradores" }};
        //    var moradores = collection.Aggregate().Group(group).ToListAsync();
        //    return moradores;
        //}
    }
}