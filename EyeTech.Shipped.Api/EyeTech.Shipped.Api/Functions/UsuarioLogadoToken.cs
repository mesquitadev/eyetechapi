using EyeTech.Shipped.Api.ViewModel.App;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace EyeTech.Shipped.Api.Functions
{
    public class UsuarioLogadoToken
    {
        private IHttpContextAccessor _accessor;

        public UsuarioLogadoToken(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public UsuarioViewModel UserLogado()
        {
            try
            {
                var usuario = _accessor.HttpContext.User.Claims.First().Value;
                var user = JsonConvert.DeserializeObject<UsuarioViewModel>(usuario);
                
                return user;
            }
            catch (Exception)
            {
                return new UsuarioViewModel();
            }
        }
    }
}