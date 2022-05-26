using AutoMapper;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using EyeTech.Shipped.Api.Functions;
using Microsoft.AspNetCore.Http;

namespace EyeTech.Shipped.Api.Controllers.App
{
    [Route("api/Menus")]
    [ApiController]
    [ValidaHeader]
    [OAuth.Auth()]
    public class MenusController : ControllerBase
    {
        private readonly IMenuAppService _menuApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public MenusController(IMenuAppService menuApp)
        {
            _menuApp = menuApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var nivel = 4;
                var menus = Mapper.Map<IEnumerable<MenusViewModel>>(_menuApp.GetAll()).ToList();
                var menuslist = new List<MenusViewModel>();
                if (_usuarioLogado.Perfis.Exists(x => x.Nivel == 4))
                {
                    _usuarioLogado.Perfis.ForEach(x =>
                    {
                        x.MenuId.ForEach(m =>
                        {
                            if (!menuslist.Exists(l => l.Id == m))
                            {
                                menuslist.Add(menus.First(menu => menu.Id == m));
                            }
                        });
                    });
                }
                else if(_usuarioLogado.Perfis.Exists(x => x.Nivel == 3))
                {
                    menuslist = new List<MenusViewModel>();
                    menuslist.AddRange(menus.Where(x => x.Supervisor == false && x.Status && x.Suporte == false));
                } else if (_usuarioLogado.Perfis.Exists(x => x.Nivel == 2))
                {
                    menuslist = new List<MenusViewModel>();
                    menuslist.AddRange(menus.Where(x=> x.Supervisor == false && x.Status == true));
                }
                 else if (_usuarioLogado.Perfis.Exists(x => x.Nivel == 1))
                {
                    menuslist = new List<MenusViewModel>();
                    menuslist.AddRange(menus);
                }

                return Ok(menuslist);
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }    
        }
    }
}