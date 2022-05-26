using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using EyeTech.Shipped.Api.OAuth;
using EyeTech.Shipped.Api.ViewModel.App;
using EyeTech.Shipped.Application.IAppService.App;
using EyeTech.Shipped.Domain.DbEntity.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace EyeTech.Shipped.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioApp;
        private readonly IPerfilAppService _perfilApp;
        public TokenController(IUsuarioAppService usuarioApp, IPerfilAppService perfilApp)
        {
            _usuarioApp = usuarioApp;
            _perfilApp = perfilApp;
        }
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioViewModel usuario,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            try
            {
                bool credenciaisValidas = false;
                if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Login))
                {
                    var senha = usuario.Senha;
                    if (usuario.Senha.Length <= 16)
                    {
                        senha = usuario.CriptografaMd5(senha);
                    }
                    var usuarioBase = _usuarioApp.Login(senha, usuario.Login);
                    credenciaisValidas = (usuarioBase != null && usuarioBase.Id != null);
                    if (!credenciaisValidas)
                    {
                        return BadRequest(new
                        {
                            authenticated = false,
                            message = "Usuário ou senha Inválida"
                        });
                    }
                    else
                    {
                        if (usuarioBase.Excluido == false && usuarioBase.Status)
                        {
                            usuario = Mapper.Map<UsuarioViewModel>(usuarioBase);
                            usuario.Token = null;
                        }
                        else
                        {
                            return BadRequest(new
                            {
                                authenticated = false,
                                message = "Usuário Desativado"
                            });
                        }                       
                    }
                }

                if (credenciaisValidas)
                {
                    var user = new PerfisUsuarioLogado(_perfilApp).Perfis(usuario);
                    var userJson = JsonConvert.SerializeObject(user);
                    ClaimsIdentity identity = new ClaimsIdentity();
                    identity.AddClaim(new Claim("Usuario", userJson, "Usuario"));
                    
                    DateTime dataCriacao = DateTime.Now;
                    DateTime dataExpiracao = dataCriacao +
                                             TimeSpan.FromSeconds(tokenConfigurations.Seconds);
                    var handler = new JwtSecurityTokenHandler();

                    var securityToken = handler.CreateToken(
                        new SecurityTokenDescriptor
                        {
                            Issuer = tokenConfigurations.Issuer,
                            Audience = tokenConfigurations.Audience,
                            SigningCredentials = signingConfigurations.SigningCredentials,
                            Subject = identity,
                            NotBefore = dataCriacao,
                            Expires = dataExpiracao
                        });

                    var token = handler.WriteToken(securityToken);
                    var userToken = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                    userToken.Token = token;
                    _usuarioApp.Update(userToken, userToken.Id);
                    return Ok(new
                    {
                        authenticated = true,
                        created = dataCriacao,
                        expiration = dataExpiracao,
                        accessToken = token,
                        message = "Logado com sucesso",
                        success = true
                    });
                }

                return BadRequest(new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                });
            }
            catch(Exception e)
            {
                return BadRequest(new {message = e.Message, success = false});
            }
        }
    }
}