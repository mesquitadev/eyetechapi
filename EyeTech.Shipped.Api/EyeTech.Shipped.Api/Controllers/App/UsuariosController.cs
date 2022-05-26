using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EyeTech.Shipped.Api.Functions;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EyeTech.Shipped.Api.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidaHeader]
    [OAuth.Auth()]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService _usuario;
        private readonly UsuarioViewModel _usuarioLogado;
        public UsuariosController(IUsuarioAppService usuario)
        {
            _usuario = usuario;
            _usuarioLogado = new UsuarioLogadoToken(new HttpContextAccessor()).UserLogado();
        }

        [HttpGet("logado")]
        public ActionResult Logado()
        {
            try
            {
                return Ok(_usuarioLogado);
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var usuarios = Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuario.GetAll(_usuarioLogado.ClienteId.ToString()));
                return Ok(usuarios.Where(x=> x.Excluido == false));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var usuario = Mapper.Map<UsuarioViewModel>(_usuario.GetId(id));
                usuario.Token = null;
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioViewModel user)
        {
            try
            {
                var usuario = Mapper.Map<Usuario>(user);
                usuario.Senha = user.CriptografaMd5(usuario.Senha);
                usuario.ClienteId = _usuarioLogado.ClienteId;
                _usuario.Add(usuario);
                return Ok(new { message = "Cadastrado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UsuarioViewModel user)
        {
            try
            {
                var userAnterior = _usuario.GetId(user.Id);
                var usuario = Mapper.Map<Usuario>(user);
                if (userAnterior.Senha != usuario.Senha)
                {
                    usuario.Senha = user.CriptografaMd5(usuario.Senha);
                }
                _usuario.Update(usuario, usuario.Id);
                return Ok(new { message = "Alterado com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] UsuarioViewModel user)
        {
            try
            {
                var usuario = Mapper.Map<Usuario>(user);
                    usuario.Excluido = true;
                    usuario.Status = false;
                    usuario.DataExclusao = DateTime.Now;
                    _usuario.Update(usuario, usuario.Id);
                
                return Ok(new { message = "Excluido com sucesso", success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, success = false });
            }
        }
    }
}