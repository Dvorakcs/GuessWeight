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
    public async Task<ActionResult<string>> Login(UsuarioDto usuario)
    {
        var usuarioDb = await _usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email, usuario.Senha);
        if (usuarioDb is null)
        {
            return BadRequest("Usuario nao existe");
        }

        var token = await _tokenRepository.GeneratorToken(usuarioDb);

        return Ok(token);
    }
}

