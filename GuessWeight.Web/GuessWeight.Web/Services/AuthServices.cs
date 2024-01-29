using GuessWeight.Library.Models;
using GuessWeight.Web.Services.Interfaces;
using System.Net.Http.Json;
using System.Net;

namespace GuessWeight.Web.Services
{
    public class AuthServices : IAuthServices
    {
        public HttpClient _httpClient;

        public AuthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginRetornoUsuarioDto> Login(LoginUsuarioDto loginUsuarioDto)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginUsuarioDto>($"api/Auth/login", loginUsuarioDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {
                    return default(LoginRetornoUsuarioDto);
                }

                return await response.Content.ReadFromJsonAsync<LoginRetornoUsuarioDto>();
            }
            return default(LoginRetornoUsuarioDto);
        }

        public async Task<LoginRetornoUsuarioDto> Create(UsuarioDto usuarioDto)
        {
            var response = await _httpClient.PostAsJsonAsync<UsuarioDto>($"api/Usuario/CriarUsuario", usuarioDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {
                    return default(LoginRetornoUsuarioDto);
                }

                return await response.Content.ReadFromJsonAsync<LoginRetornoUsuarioDto>();
            }
            return default(LoginRetornoUsuarioDto);
        }
    }
}
