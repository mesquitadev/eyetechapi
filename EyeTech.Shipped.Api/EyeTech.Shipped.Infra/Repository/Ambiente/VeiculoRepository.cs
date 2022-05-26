using System.Collections.Generic;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.Interfaces.IRepository.Ambiente;
using EyeTech.Shipped.Infra.Repository.App;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Repository.Ambiente
{
    public class VeiculoRepository: RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public bool VerificarPlaca(string placa)
        {
            var collection = _context.Veiculos;
            var query = Builders<Veiculo>.Filter.Eq(x => x.Placa, placa);
            var veiculo = collection.Find(query).FirstOrDefault();
            if (veiculo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Veiculo BuscarPorPlaca(string placa)
        {
            var collection = _context.Veiculos;
            var query = Builders<Veiculo>.Filter.Eq(x => x.Placa, placa);
            var veiculo = collection.Find(query).FirstOrDefault();
            return veiculo;
        }

        public IEnumerable<Veiculo> BuscarPorApartamento(string apartamento)
        {
            var collection = _context.Veiculos;
            var query = Builders<Veiculo>.Filter.Eq(x => x.ApartamentoId, apartamento);
            var veiculo = collection.Find(query).ToList();
            return veiculo;
        }
    }
}