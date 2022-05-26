using System;
using System.Linq;
using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidaHeader]
    [OAuth.Auth()]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteApp;
        private readonly UsuarioViewModel _usuariologado;
        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
            _usuariologado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cliente = Mapper.Map<ClienteViewModel>(_clienteApp.GetId(_usuariologado.ClienteId));
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClienteViewModel client)
        {
            try
            {
                var cliente = Mapper.Map<Cliente>(client);
                cliente.Id = ObjectId.GenerateNewId().ToString();
                _clienteApp.Add(cliente);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]ClienteViewModel client)
        {
            try
            {
                var cliente = Mapper.Map<Cliente>(client);
                _clienteApp.Update(cliente, cliente.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}