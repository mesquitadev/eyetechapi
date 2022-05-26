using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace EyeTech.Shipped.Api.OAuth
{
    public class ValidaHeader: ActionFilterAttribute
    {
    public List<string> Enderecos { get; set; }
    public ValidaHeader()
    {
        //Enderecos = new List<string>();
        //Enderecos.Add("https://localhost:8180");
        //Enderecos.Add("http://192.168.0.238:8180");
        //Enderecos.Add("https://192.168.0.238:8180");
        //Enderecos.Add("http://localhost:8180");
        //Enderecos.Add("http://webpago.com.br");
        //Enderecos.Add("https://webpago.com.br");
        //Enderecos.Add("https://app.webpago.com.br");
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //try
        //{
        //    var host = context.HttpContext.Request.Headers.First(x => x.Key == "Origin").Value;

        //    Console.WriteLine("====================================");
        //    Console.WriteLine(host);
        //    Console.WriteLine("====================================");
        //    if (!Enderecos.Exists(x => x == host))
        //    {
        //        context.Result = new ContentResult()
        //        {
        //            Content = (new { message = "Sem permissão para este acesso " }).ToString()
        //        };
        //    }
        //}
        //catch (Exception e)
        //{
        //    context.Result = new ContentResult()
        //    {
        //        Content = (new { message = "Sem permissão para este acesso " }).ToString()
        //    };
        //}
    }
}
}
