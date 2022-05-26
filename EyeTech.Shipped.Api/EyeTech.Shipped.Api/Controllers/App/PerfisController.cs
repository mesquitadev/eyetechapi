using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EyeTech.Shipped.Api.IController;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EyeTech.Shipped.Api.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class PerfisController : ControllerBase
    {
        private readonly IPerfilAppService _perfilApp;

        public PerfisController(IPerfilAppService perfilApp)
        {
            _perfilApp = perfilApp;
        }

        [HttpGet("ativos")]
        public IActionResult Ativos()
        {
            try
            {
                var perfis = Mapper.Map<List<PerfilViewModel>>(_perfilApp.GetAll());
                return Ok(perfis.Where(x=> x.Status));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfis = Mapper.Map<List<PerfilViewModel>>(_perfilApp.GetAll());
                return Ok(perfis);
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var perfil = Mapper.Map<PerfilViewModel>(_perfilApp.GetId(id));
                return Ok(perfil);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]PerfilViewModel obj)
        {
            try
            {
                var perfil = Mapper.Map<Perfil>(obj);
                _perfilApp.Add(perfil);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] PerfilViewModel obj)
        {
            try
            {
                var perfil = Mapper.Map<Perfil>(obj);
                _perfilApp.Update(perfil, perfil.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] PerfilViewModel obj)
        {
            try
            {
                var perfil = Mapper.Map<Perfil>(obj);
                _perfilApp.RemoverDado(perfil.Id);
                return Ok(new { message = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}