using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class ControleDeAcessoController : ControllerBase
    {
        private readonly IPortariaAppService _portariaApp;
        private readonly UsuarioViewModel _usuarioLogado;
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly IVisitantesAppService _visitantesApp;
        public ControleDeAcessoController(IPortariaAppService portariaApp, IApartamentoAppService apartamentoApp, IVisitantesAppService visitantesApp)
        {
            _portariaApp = portariaApp;
            _apartamentoApp = apartamentoApp;
            _visitantesApp = visitantesApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet("ultimosAcessos")]
        public IActionResult Ultimos()
        {
            try
            {
                var registros = Mapper.Map<IEnumerable<PortariaViewModel>>(_portariaApp.GetAll(_usuarioLogado.ClienteId)).OrderBy(x => x.Entrada).Take(10);
                return Ok(registros);
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
                var registros = Mapper.Map<IEnumerable<PortariaViewModel>>(_portariaApp.GetAll(_usuarioLogado.ClienteId));
                return Ok(registros);
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }
        }

        [HttpGet("Portaria/{id}")]
        public IActionResult Postaria(string id)
        {
            try
            {
                var dado = _portariaApp.GetId(id);
                dado.Alerta = false;
                _portariaApp.Update(dado, dado.Id);
                var registro = Mapper.Map<PortariaViewModel>(dado);
                
                
                return Ok(registro);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var registro = Mapper.Map<PortariaViewModel>(_portariaApp.GetId(id));
                if (!String.IsNullOrEmpty(registro.ApartamentoId))
                {
                    registro.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(registro.ApartamentoId));
                }
                if (!String.IsNullOrEmpty(registro.VisitaId))
                {
                    registro.Visitante = Mapper.Map<VisitanteViewModel>(_visitantesApp.GetId(registro.VisitaId));
                }
                return Ok(new { apartamento = registro.Apartamento, visitante = registro.Visitante});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPost]
        public IActionResult Post(PortariaViewModel obj)
        {
            try
            {
                var registro = Mapper.Map<Portaria>(obj);
                registro.ClienteId = _usuarioLogado.ClienteId;
                _portariaApp.Add(registro);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public IActionResult Put(PortariaViewModel obj)
        {
            try
            {
                var registro = Mapper.Map<Portaria>(obj);
                _portariaApp.Update(registro, registro.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

    }
}