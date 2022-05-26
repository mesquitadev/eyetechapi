using System;
using System.Collections.Generic;
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
using MongoDB.Bson.Serialization.Conventions;

namespace EyeTech.Shipped.Api.Controllers.Ambiente
{
    [Route("api/[controller]")]
    [ApiController]
    [OAuth.Auth()]
    [ValidaHeader]
    public class CamerasController : ControllerBase
    {
        private readonly ICameraAppService _cameraApp;
        private readonly UsuarioViewModel _usuarioLogado;
        public CamerasController(ICameraAppService cameraApp)
        {
            _cameraApp = cameraApp;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cameras =
                    Mapper.Map<IEnumerable<CamerasViewModel>>(_cameraApp.GetAll(new ObjectId(_usuarioLogado.ClienteId)));
                return Ok(cameras);
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
                var camera =
                    Mapper.Map<CamerasViewModel>(_cameraApp.GetId(id));
                return Ok(camera);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPost]
        public IActionResult Post(CamerasViewModel obj)
        {
            try
            {
                var camera =
                    Mapper.Map<Cameras>(obj);
                camera.ClienteId = _usuarioLogado.ClienteId;
                _cameraApp.Add(camera);
                return BadRequest(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpPut]
        public IActionResult Put(CamerasViewModel obj)
        {
            try
            {
                var camera =
                    Mapper.Map<Cameras>(obj);
                _cameraApp.Update(camera, camera.Id);
                return BadRequest(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
        [HttpDelete]
        public IActionResult Delete(CamerasViewModel obj)
        {
            try
            {
                var camera =
                    Mapper.Map<Cameras>(obj);
                _cameraApp.RemoverDado(camera.Id);
                return BadRequest(new { message = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}