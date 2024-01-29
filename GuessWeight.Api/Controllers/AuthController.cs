using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using GuessWeight.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuessWeight.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthController(ITokenRepository tokenRepository, IUsuarioRepository usuarioRepository)
    {
        _tokenRepository = tokenRepository;
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    [Route("login/")]
    public async Task<ActionResult<LoginRetornoUsuarioDto>> Login([FromBody] LoginUsuarioDto usuario)
    {
        var usuarioDb = await _usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email, usuario.Senha);
        if (usuarioDb is null)
        {
            return BadRequest("Usuario nao existe");
        }

        var token = await _tokenRepository.GeneratorToken(usuarioDb);

        return Ok(new LoginRetornoUsuarioDto
        {
            Email = usuarioDb.Email, 
            Nome = usuarioDb.Nome,
            ApiKey = token.ToString(),
            Id = usuarioDb.Id
        });
    }

    [HttpPost]
    [Route("create/")]
    public async Task<ActionResult<LoginRetornoUsuarioDto>> Create([FromBody]UsuarioDto usuario)
    {
        var usuarioDb = await _usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email);
        if (usuarioDb is not null)
        {
            return BadRequest("Usuario Ja existe");
        }
        //var usuarioDb = await _usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email, usuario.Senha);

        var token = await _tokenRepository.GeneratorToken(usuarioDb);

        return Ok(new LoginRetornoUsuarioDto
        {
            Email = usuarioDb.Email,
            Nome = usuarioDb.Nome,
            ApiKey = token.ToString(),
            Id = usuarioDb.Id
        });
    }
}

