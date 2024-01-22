using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GuessWeight.Library.Models;
using Microsoft.AspNetCore.Authorization;
namespace GuessWeight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
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
            var Usuario = await usuarioRepository.GetUsuarioPorEmailESenha(usuario.Email);

            if (Usuario is not null)
            {
                return Ok("Usuario com Email ja existente");
            }

            var usuarioCreate = await usuarioRepository.Create(new Usuario
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
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int Id)
        {      
           var usuario = await this.usuarioRepository.Get(Id);
            if (usuario is null)
            {
                return NotFound("Usuario nao existe");
            }
            return Ok(usuario);
        }
    }
}
