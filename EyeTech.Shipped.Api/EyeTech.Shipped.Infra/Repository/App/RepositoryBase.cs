using System;
using System.Collections.Generic;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Repository.App
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        public readonly EyetechContext _context;

        public RepositoryBase()
        {
            _context = new EyetechContext();
        }

        public List<T> GetAll()
        {
            return _context.DataBase.GetCollection<T>(typeof(T).Name).Find(x => true).ToList();

        }

        public List<T> GetAll(string clienteId)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("ClienteId", clienteId);
            return collection.Find(filter).ToList();
        }

        public List<T> GetAll(ObjectId clienteId)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("ClienteId", clienteId);
            return collection.Find(filter).ToList();
        }

        public List<T> GetAll(string clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.Eq("ClienteId", clienteId));
            return collection.Find(filter).ToList();
        }

        public List<T> GetAll(DateTime dataInicial, DateTime dataFinal)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            return collection.Find(x => true).ToList();
        }

        public T GetId(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            return _context.DataBase.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefault();
        }

        public void Add(T obj)
        {
            _context.DataBase.GetCollection<T>(typeof(T).Name).InsertOne(obj);
        }

        public void Update(T obj, string id)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            var query = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            collection.FindOneAndReplace(query, obj);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj, string id = null)
        {
            throw new NotImplementedException();
        }

        public void RemoverDado(string id)
        {
            var collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
            var query = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            collection.FindOneAndDelete(query);
        }
    }
}