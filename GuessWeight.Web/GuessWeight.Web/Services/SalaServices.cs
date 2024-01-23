using GuessWeight.Library.Models;
using GuessWeight.Web.Services.Interfaces;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GuessWeight.Web.Services
{
    public class SalaServices : ISalaServices
    {
        public HttpClient _httpClient;
        public JSRuntime _runtime;
        public SalaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        
        }

        public async Task<SalaDto> EntrarSala(UsuarioEntraSalaDto usuarioEntraSalaDto)
        {          
           
            var response = await _httpClient.PostAsJsonAsync<UsuarioEntraSalaDto>($"api/Sala/EntrarSala", usuarioEntraSalaDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {
                    
                }

              return  await response.Content.ReadFromJsonAsync<SalaDto>();
            }
            return default(SalaDto);
        }

        public async Task<IEnumerable<SalaDto>> getSalaAll()
        {
            return await _httpClient.
                GetFromJsonAsync<IEnumerable<SalaDto>>
                ("api/sala/GetSalas") ?? new List<SalaDto> { };
        }
        public async Task<SalaDto> getSala(int Id)
        {    
            return await _httpClient.
                GetFromJsonAsync<SalaDto>
                ($"api/sala/GetSala/{Id}");
        }
     
    }
}
