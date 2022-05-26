using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace EyeTech.Shipped.Domain.Interfaces.IServices.App
{
    public interface IServiceBase<T> where T: class
    {
        List<T> GetAll();
        List<T> GetAll(string clienteId);
        List<T> GetAll(ObjectId clienteId);
        List<T> GetAll(string clienteId, DateTime dataInicial, DateTime dataFinal);
        List<T> GetAll(DateTime dataInicial, DateTime dataFinal);
        T GetId(string id);
        void Add(T obj);
        void Update(T obj, string id);
        void Delete(string id);
        void Delete(T obj, string id = null);
        void RemoverDado(string id);
    }
}