using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.IController;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class MoradoresController : ControllerBase
    {
        private readonly IMoradorAppService _moradorApp;
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public MoradoresController(IMoradorAppService moradorApp, IApartamentoAppService apartamentoApp)
        {
            _moradorApp = moradorApp;
            _apartamentoApp = apartamentoApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet("Ativo")]
        public IActionResult Ativo()
        {
            try
            {
                var moradores = Mapper.Map<IEnumerable<MoradorViewModel>>(_moradorApp.GetAll(_usuarioLogado.ClienteId.ToString())).ToList();
                moradores.ForEach(x =>
                {
                    x.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(x.ApartamentoId.ToString()));
                });
                return Ok(moradores.Where(x=> x.Status));
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
                var moradores = Mapper.Map<IEnumerable<MoradorViewModel>>(_moradorApp.GetAll(_usuarioLogado.ClienteId.ToString())).ToList();
                moradores.ForEach(x =>
                {
                    x.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(x.ApartamentoId.ToString()));
                });
                return Ok(moradores);
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
                var morador = Mapper.Map<MoradorViewModel>(_moradorApp.GetId(id));
                return Ok(morador);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPost]
        public IActionResult Post(MoradorViewModel obj)
        {
            try
            {
                var morador = Mapper.Map<Morador>(obj);
                morador.Id = ObjectId.GenerateNewId().ToString();
                morador.ClienteId = _usuarioLogado.ClienteId;
                _moradorApp.Add(morador);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public IActionResult Put(MoradorViewModel obj)
        {
            try
            {
                var morador = Mapper.Map<Morador>(obj);
                _moradorApp.Update(morador, morador.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpDelete]
        public IActionResult Delete(MoradorViewModel obj)
        {
            try
            {
                var morador = Mapper.Map<Morador>(obj);
                _moradorApp.RemoverDado(morador.Id);
                return Ok(new { message = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}