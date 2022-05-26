using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class ApartamentosController : ControllerBase
    {
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public ApartamentosController(IApartamentoAppService apartamentoApp)
        {
            _apartamentoApp = apartamentoApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var apartamentos =
                    Mapper.Map<IEnumerable<ApartamentoViewModel>>(
                        _apartamentoApp.GetAll(new ObjectId(_usuarioLogado.ClienteId)));
                return Ok(apartamentos);
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
                var apartamento =
                    Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(id));
                return Ok(apartamento);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ApartamentoViewModel obj)
        {
            try
            {
                var apartamento = Mapper.Map<Apartamento>(obj);
                apartamento.ClienteId = _usuarioLogado.ClienteId;
                _apartamentoApp.Add(apartamento);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]ApartamentoViewModel obj)
        {
            try
            {
                var apartamento = Mapper.Map<Apartamento>(obj);
                _apartamentoApp.Update(apartamento, apartamento.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]ApartamentoViewModel obj)
        {
            try
            {
               _apartamentoApp.RemoverDado(obj.Id);
                return Ok(new { message = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}