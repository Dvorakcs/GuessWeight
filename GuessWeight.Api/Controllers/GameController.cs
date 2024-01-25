using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories;
using GuessWeight.Api.Repositories.Interfaces;
using GuessWeight.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuessWeight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly ISalaRepository _salaRepository;
        public GameController(IGameRepository gameRepository, ISalaRepository salaRepository)
        {
            _gameRepository = gameRepository;
            _salaRepository = salaRepository;
        }

        [HttpPost]
        [Route("IniciaJogo")]
        public async Task<ActionResult<GameDto>> IniciaJogo([FromBody]int salaId)
        {
            try
            {
                var sala = await _salaRepository.Get(salaId);

                if (sala is null)
                {
                    return NotFound("Sala nao existe");
                }

                var game = await _gameRepository.CreateGame(sala);

                if(game is null)
                {
                    return NotFound("Erro ao criar o jogo");
                }

                return Ok(game);

            }
            catch (Exception error)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("FinalizarJogo")]
        public async Task<ActionResult<GameDto>> FinalizarJogo([FromBody]int gameId)
        {
            try
            {
                var game = await _gameRepository.Vencedor(gameId);

                if (game is null)
                {
                    return NotFound("Erro ao Finalizar o jogo");
                }

                return Ok(game);

            }
            catch (Exception error)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetGame/{gameId}")]
        public async Task<ActionResult<GameDto>> GetGame(int gameId)
        {
            try
            {
                var game = await _gameRepository.Get(gameId);

                if (game is null)
                {
                    return NotFound("Erro ao Finalizar o jogo");
                }

                return Ok(game);

            }
            catch (Exception error)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetVencedor")]
        public async Task<ActionResult<Game>> GetVencedor(int gameId)
        {
            var gameFinalizado = await _gameRepository.Vencedor(gameId);
            return Ok(gameFinalizado);

        }
    }
}
