using AutoMapper;
using EyeTech.Shipped.Api.Functions.App;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.App;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;

namespace EyeTech.Shipped.Api.Controllers.Publicas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistraEntradaController : ControllerBase
    {
        private readonly IVisitantesAppService _visitantesApp;
        private readonly IVeiculoAppService _veiculoApp;
        private readonly IPortariaAppService _portariaApp;
        private readonly IClienteAppService _clienteApp;
        private readonly Cliente cliente;
        public RegistraEntradaController(IVisitantesAppService visitantesApp,  IVeiculoAppService veiculoApp, IPortariaAppService portariaApp, IClienteAppService clienteApp)
        {
            _visitantesApp = visitantesApp;
            _veiculoApp = veiculoApp;
            _portariaApp = portariaApp;
            _clienteApp = clienteApp;
            cliente = _clienteApp.GetAll().FirstOrDefault();
        }
        
        [HttpPost]
        public IActionResult RegistraVaiculos([FromForm][FromBody][FromHeader]VeiculoViewModel veiculo)
        {
            var upload = new Upload("veiculos", ".jpg");
            try
            {
                var morador = _veiculoApp.BuscarPorPlaca(veiculo.Placa);
                var portaria = new PortariaViewModel();
                portaria.Id = ObjectId.GenerateNewId().ToString();
                portaria.ClienteId = cliente.Id;
                portaria.Entrada = DateTime.Now;
                portaria.Alerta = true;
                portaria.Identificado = true;
                if (morador != null)
                {
                    upload.ConverterImagem(veiculo.Imagem);
                    portaria.Morador = true;
                    portaria.ApartamentoId = morador.ApartamentoId;
                    portaria.Imagem = upload.NomeArquivo;
                    portaria.Veiculo = veiculo;
                    _portariaApp.Add(Mapper.Map<Portaria>(portaria));
                    return Ok(1);
                }
                var visitante = _visitantesApp.BuscarPorPlaca(veiculo.Placa);
                if (visitante != null && visitante.DataEntrada.Value.Date == DateTime.Now.Date)
                {
                    upload.ConverterImagem(veiculo.Imagem);
                    portaria.VisitaId = visitante.Id;
                    portaria.ApartamentoId = visitante.ApartamentoId;
                    portaria.Imagem = upload.NomeArquivo;
                    portaria.Veiculo = veiculo;
                    portaria.Morador = false;
                    _portariaApp.Add(Mapper.Map<Portaria>(portaria));

                    return Ok(2);
                }
                else
                {
                    visitante = null;
                }
                if (morador == null && visitante == null)
                {
                    upload.ConverterImagem(veiculo.Imagem);
                    portaria.Imagem = upload.NomeArquivo;
                    
                    portaria.Veiculo = veiculo;
                    portaria.Morador = false;
                    portaria.Identificado = false;
                    var port = Mapper.Map<Portaria>(portaria);
                    _portariaApp.Add(port);
                }
                return Ok(3);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                upload.ApagarImagem(upload.NomeArquivo);
                return BadRequest(400);
            }
        }

    }
}