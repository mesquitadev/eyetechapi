using System;
using EyeTech.Shipped.Api.Functions.App;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.Controllers.Publicas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private readonly IVersionDataBaseAppService _versionApp;

        public VersaoController(IVersionDataBaseAppService versionApp)
        {
            _versionApp = versionApp;
        }
        [HttpGet("start")]
        public IActionResult Get()
        {
            try
            {
                var atualiza = new AtualizadorDataBase();
                if (!_versionApp.BuscarVersao("v1.1"))
                {
                    EyetechContext context = new EyetechContext();
                    atualiza.IniciaSistema(context);
                    var version = new VersionDataBase()
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Versao = "v1.1",
                        Data = DateTime.Now
                    };
                    _versionApp.Add(version);
                    return Ok(new { message = "Banco e usuário supervisor criado com sucesso", success = true });
                }
                return Ok(new { message = "Sistema já Atualizado", success = false });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message, success = false});
            }
        }

        [HttpGet("atualiza")]
        public IActionResult Atualiza()
        {
            try
            {
                var atualiza = new AtualizadorDataBase();
                if (!_versionApp.BuscarVersao("v1.2"))
                {
                    EyetechContext context = new EyetechContext();
                    atualiza.Atualiza(context);
                    var version = new VersionDataBase()
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Versao = "v1.2",
                        Data = DateTime.Now
                    };
                    _versionApp.Add(version);
                    return Ok(new { message = "Banco Atualizado com sucesso", success = true });
                }
                return Ok(new { message = "Sistema já Atualizado", success = false });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}