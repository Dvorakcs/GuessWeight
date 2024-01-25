using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GuessWeight.Library.Models;
using Microsoft.AspNetCore.Authorization;
using GuessWeight.Api.Repositories;
namespace GuessWeight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioRespostaPesoRepository _usuarioRespostaPesoRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioRespostaPesoRepository usuarioRespostaPesoRepository)
        {
            this._usuarioRepository = usuarioRepository;
            this._usuarioRespostaPesoRepository = usuarioRespostaPesoRepository;
        }


        [HttpPost]
        [Route("CriarUsuario")]
        public async Task<ActionResult<UsuarioDto>> CreateUsuario(UsuarioDto usuario)
        {
            if (usuario is null)
            {
                return NotFound("Erro ao preencher o Usuario ");
            }

            if (usuario.Senha != usuario.ConfirmaSenha)
            {
                return Ok("Senhas devem ser iguais");
            }
            var Usuario = await _usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email);

            if (Usuario is not null)
            {
                return Ok("Usuario com Email ja existente");
            }

            var usuarioCreate = await _usuarioRepository.Create(new Usuario
            {
                 Email = usuario.Email,
                 Nome = usuario.Nome,
                 Senha = usuario.Senha,
            });

            if(usuarioCreate is null)
            {
                return NotFound("Nao foi possivel criar o usuario");
            }

            return Ok(Usuario);
        }
        [HttpPost]
        [Route("GetUsuario")]
        [Authorize]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int Id)
        {      
           var usuario = await this._usuarioRepository.Get(Id);
            if (usuario is null)
            {
                return NotFound("Usuario nao existe");
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Route("RespostaUsuarioGame")]
        public async Task<ActionResult> RespostaUsuarioGame(UsuarioRespostaPeso usuarioRespostaPeso)
        {
            await _usuarioRespostaPesoRepository.Update(usuarioRespostaPeso);
            return Ok("resposta Enviada com sucesso");

        }

    }
}
