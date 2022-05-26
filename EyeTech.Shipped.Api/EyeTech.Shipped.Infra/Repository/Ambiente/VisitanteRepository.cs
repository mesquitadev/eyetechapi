using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Infra.Repository.App;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Repository.Ambiente
{
    public class VisitanteRepository: RepositoryBase<Visitante>, IVisitantesRepository
    {
        public Visitante BuscarPorPlaca(string placa)
        {
            var collection = _context.Visitantes;
            var query = Builders<Visitante>.Filter.Eq(x => x.Veiculo.Placa, placa);
            var visitante = collection.Find(query).FirstOrDefault();
            return visitante;
        }
    }
}