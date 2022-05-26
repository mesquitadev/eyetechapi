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

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class VisitanteController : ControllerBase
    { 
        private readonly IVisitantesAppService _visitantesApp;
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public VisitanteController(IVisitantesAppService visitantesApp, IApartamentoAppService apartamentoApp)
        {
            _visitantesApp = visitantesApp;
            _apartamentoApp = apartamentoApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var visitantes =
                    Mapper.Map<List<VisitanteViewModel>>(_visitantesApp.GetAll(_usuarioLogado.ClienteId));
                visitantes.ForEach(v =>
                {
                    if (v.ApartamentoId != null)
                    {
                        v.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(v.ApartamentoId));
                    }
                });
                return Ok(visitantes);
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
                var visitante = Mapper.Map<VisitanteViewModel>(_visitantesApp.GetId(id));
                    if (visitante.ApartamentoId != null)
                    {
                        visitante.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(visitante.ApartamentoId));
                    }
                return Ok(visitante);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] VisitanteViewModel obj)
        {
            try
            {
                obj.Enviado = false;
                var visitante = Mapper.Map<Visitante>(obj);
                visitante.ClienteId = _usuarioLogado.ClienteId;
                _visitantesApp.Add(visitante);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] VisitanteViewModel obj)
        {
            try
            {
                var visitante = Mapper.Map<Visitante>(obj);
                _visitantesApp.Update(visitante, visitante.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] VisitanteViewModel obj)
        {
            try
            {
                _visitantesApp.RemoverDado(obj.Id);
                return Ok(new { message = "Deletado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}