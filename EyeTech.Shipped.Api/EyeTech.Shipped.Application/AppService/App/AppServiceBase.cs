using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.Interfaces.IServices.App;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace EyeTech.Shipped.Application.AppService.App
{
    public class AppServiceBase<T>: IAppServiceBase<T> where T: class
    {
        private readonly IServiceBase<T> _service;

        public AppServiceBase(IServiceBase<T> service)
        {
            _service = service;
        }

        public List<T> GetAll()
        {
            return _service.GetAll();
        }

        public List<T> GetAll(string clienteId)
        {
            return _service.GetAll(clienteId);
        }

        public List<T> GetAll(ObjectId clienteId)
        {
            return _service.GetAll(clienteId);
        }

        public List<T> GetAll(string clienteId, DateTime dataInicial, DateTime dataFinal)
        {
            return _service.GetAll(clienteId, dataInicial, dataFinal);
        }

        public List<T> GetAll(DateTime dataInicial, DateTime dataFinal)
        {
            return _service.GetAll(dataInicial, dataFinal);
        }

        public T GetId(string id)
        {
            return _service.GetId(id);
        }

        public void Add(T obj)
        {
            _service.Add(obj);
        }

        public void Update(T obj, string id)
        {
            _service.Update(obj, id);
        }

        public void Delete(string id)
        {
            _service.Delete(id);
        }

        public void Delete(T obj, string id = null)
        {
            _service.Delete(obj, id);
        }

        public void RemoverDado(string id)
        {
            _service.RemoverDado(id);
        }
    }
}