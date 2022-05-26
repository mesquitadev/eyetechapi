using System;
using System.Collections.Generic;
using EyeTech.Shipped.Domain.Interfaces.IRepository.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;
using MongoDB.Bson;

namespace EyeTech.Shipped.Domain.Services.App
{
    public class ServiceBase<T>: IServiceBase<T> where T: class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetAll()
        {
           return _repository.GetAll();
        }

        public List<T> GetAll(string clienteId)
        {
            return _repository.GetAll(clienteId);
        }

        public List<T> GetAll(ObjectId clienteId)
        {
            return _repository.GetAll(clienteId);
        }

        public List<T> GetAll(string clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            return _repository.GetAll(clienteId, dataInicial, dataFinal);
        }

        public List<T> GetAll(DateTime dataInicial, DateTime dataFinal)
        {
            return _repository.GetAll(dataInicial, dataFinal);
        }

        public T GetId(string id)
        {
            return _repository.GetId(id);
        }

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public void Update(T obj, string id)
        {
            _repository.Update(obj, id);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public void Delete(T obj, string id = null)
        {
            _repository.Delete(obj, id);
        }

        public void RemoverDado(string id)
        {
            _repository.RemoverDado(id);
        }
    }
}