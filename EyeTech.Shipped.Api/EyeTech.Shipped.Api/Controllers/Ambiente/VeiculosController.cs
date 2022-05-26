using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoAppService _veiculoApp;
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public VeiculosController(IApartamentoAppService apartamentoApp, IVeiculoAppService veiculoApp)
        {
            _apartamentoApp = apartamentoApp;
            _veiculoApp = veiculoApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var veiculos = Mapper.Map<List<VeiculoViewModel>>(_veiculoApp.GetAll(_usuarioLogado.ClienteId.ToString()).ToList());
                veiculos.ForEach(v =>
                {
                    v.Apartamento = Mapper.Map<ApartamentoViewModel>(_apartamentoApp.GetId(v.ApartamentoId));
                });
                return Ok(veiculos);
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
                var veiculo = Mapper.Map<VeiculoViewModel>(_veiculoApp.GetId(id));
                return Ok(veiculo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPost("ConsultaPlaca")]
        public IActionResult Placa([FromBody] VeiculoViewModel obj)
        {
            try
            {
                var veiculo = _veiculoApp.BuscarPorPlaca(obj.Placa);
                if (veiculo != null && veiculo.Id != obj.Id)
                {
                    return Ok(new {message = "Veiculo já Cadastrado", success = false });
                }
                else
                {
                    return Ok(new { message = "liberado", success = true });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] VeiculoViewModel obj)
        {
            try
            {
                if (_veiculoApp.VerificarPlaca(obj.Placa) == false)
                {
                    obj.Id = ObjectId.GenerateNewId().ToString();
                    var veiculo = Mapper.Map<Veiculo>(obj);
                    veiculo.ClienteId = _usuarioLogado.ClienteId;
                    _veiculoApp.Add(veiculo);
                    return Ok(new {message = "Cadastrado com sucesso", success = true});
                }
                else
                {
                    return Ok(new { message = "Veiculo já Cadastrado", success = false });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] VeiculoViewModel obj)
        {
            try
            {
                var veiculo = Mapper.Map<Veiculo>(obj);
                _veiculoApp.Update(veiculo, veiculo.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] VeiculoViewModel obj)
        {
            try
            {
                _veiculoApp.RemoverDado(obj.Id);
                return Ok(new { message = "Excluir com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}