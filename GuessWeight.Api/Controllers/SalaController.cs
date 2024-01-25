using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using GuessWeight.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;


namespace GuessWeight.Api.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaRepository _Salarepository;
        private readonly IUsuarioRepository _Usuariorepository;

        public SalaController(ISalaRepository Salarepository, IUsuarioRepository Usuariorepository)
        {
            _Salarepository = Salarepository;
            _Usuariorepository = Usuariorepository;
        }

        [HttpPost]
        [Route("EntrarSala")]
        public async Task<ActionResult<SalaDto>> EntrarSala(UsuarioEntraSalaDto usuarioEntraSalaDto)
        {
            var sala = await _Salarepository.Get(usuarioEntraSalaDto.SalaId);

            if(sala is null)
            {
                return NotFound("Sala nao existe");
            }

            var usuarioDb = await _Usuariorepository.Get(usuarioEntraSalaDto.UsuarioId);

            if (usuarioDb is null)
            {
                return NotFound("Usuario nao existe");
            }

            var salaEntrou = await _Salarepository.EntrarSala(sala,usuarioDb);

            return Ok(salaEntrou);
        }
       
        [HttpPost]
        [Route("CriarSala")]
        public async Task<ActionResult<SalaDto>> CriarSala(CreateSala createSala)
        {

          var sala =  await _Salarepository.Create(new Sala { 
                 Nome = createSala.SalaDto.Nome,
                 Senha = createSala.SalaDto.Senha,
                 QuantidadePartida = createSala.SalaDto.QuantidadePartida,
                 QuantidadeTempo = createSala.SalaDto.QuantidadeTempo
            });
            var usuarioDb = await _Usuariorepository.Get(createSala.usuarioIdAdmin);

            if (usuarioDb is null)
            {
                return NotFound("Usuario nao existe");
            }
            await _Salarepository.EntrarSala(sala, usuarioDb);
            return Ok(sala);
        }
        [HttpGet]
        [Route("GetSalas")]
        public async Task<ActionResult<IEnumerable<SalaDto>>> GetSalas()
        {
            var salaDb = await _Salarepository.GetAll();
            var salaDtoConvert = (from sala in salaDb
                                  select new SalaDto
                                  {
                                      Id = sala.Id,
                                      Nome = sala.Nome,
                                      QuantidadePartida = sala.QuantidadePartida,
                                      QuantidadeTempo = sala.QuantidadeTempo,
                                  });

            return salaDtoConvert.ToList();


        }
        [HttpGet]
        [Route("GetSala/{Id}")]
        public async Task<ActionResult<SalaDto>> GetSala(int Id)
        {
            var salaDb = await _Salarepository.GetSalaEUsuarios(Id);
           
            return Ok(salaDb);
        }


    }
}
