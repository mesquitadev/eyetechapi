using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.Ambiente;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.Ambiente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EyeTech.Shipped.Api.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class DashboardController : ControllerBase
    {
        private readonly IVisitantesAppService _visitantesApp;
        private readonly ICameraAppService _cameraApp;
        private readonly IPortariaAppService _portariaApp;
        private readonly IApartamentoAppService _apartamentoApp;
        private readonly IMoradorAppService _moradorApp;
        private readonly IVeiculoAppService _veiculoApp;
        private readonly UsuarioViewModel _usuarioLogado;

        public DashboardController(IVisitantesAppService visitantesApp, ICameraAppService cameraApp, IPortariaAppService portariaApp, IMoradorAppService moradorApp, IApartamentoAppService apartamentoApp, IVeiculoAppService veiculoApp)
        {
            _visitantesApp = visitantesApp;
            _cameraApp = cameraApp;
            _portariaApp = portariaApp;
            _moradorApp = moradorApp;
            _apartamentoApp = apartamentoApp;
            _veiculoApp = veiculoApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = DateTime.Now.Date;
                var inicio = Convert.ToDateTime("01/" + data.Month + "/" + data.Year).Date;
                var veiculos = _veiculoApp.GetAll(_usuarioLogado.ClienteId);
                var visitantes = _visitantesApp.GetAll(_usuarioLogado.ClienteId);
                var acessos = _portariaApp.GetAll().Where(x => x.Entrada.Date >= inicio.Date && x.Entrada.Date <= data.Date);
                var cameras = _cameraApp.GetAll(_usuarioLogado.ClienteId);
                var dashboard = new
                {
                    veiculos = veiculos.Count,
                    visitantes = visitantes.Count,
                    naoAutorizado = acessos.Where(x=> x.Identificado == false).Count(),
                    cameras = cameras.Count
                };
                return Ok(dashboard);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}