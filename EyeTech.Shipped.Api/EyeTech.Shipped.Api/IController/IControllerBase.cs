using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EyeTech.Shipped.Api.IController
{
    public interface IControllerBase<T> where T: class 
    {
        IActionResult Get();
        IActionResult Get(string id);
        IActionResult Post(T obj);
        IActionResult Put(T obj);
        IActionResult Delete(T obj);
    }
}