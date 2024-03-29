﻿using GuessWeight.Library.Models;
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
        private readonly IJSRuntime _jsRuntime;
        public SalaServices(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<SalaDto> EntrarSala(UsuarioEntraSalaDto usuarioEntraSalaDto)
        {          
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
        public async Task<SalaDto> CreateSala(CreateSala salaDto)
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync<CreateSala>($"api/Sala/CriarSala", salaDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {

                }

                return await response.Content.ReadFromJsonAsync<SalaDto>();
            }
            return default(SalaDto);
        }
        public async Task<GameDto> StartGame(int SalaId)
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync<int>($"api/Game/IniciaJogo", SalaId);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {

                }

                return await response.Content.ReadFromJsonAsync<GameDto>();
            }
            return default(GameDto);
        }
        public async Task<IEnumerable<SalaDto>> getSalaAll()
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _httpClient.
                GetFromJsonAsync<IEnumerable<SalaDto>>
                ("api/sala/GetSalas") ?? new List<SalaDto> { };
        }
        public async Task<SalaDto> getSala(int Id)
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _httpClient.
                GetFromJsonAsync<SalaDto>
                ($"api/sala/GetSala/{Id}");
        }
        public async Task<GameDto> GetGame(int Id)
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _httpClient.
                GetFromJsonAsync<GameDto>
                ($"api/game/GetGame/{Id}");
        }
        public async Task<UsuarioDto> GetUsuario(int Id)
        {
            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _httpClient.
                GetFromJsonAsync<UsuarioDto>
                ($"api/Usuario/GetUsuario/{Id}");
        }
        public async Task EnviaResposta(UsuarioRespostaPesoDto usuarioRespostaPesoDto)
        {

            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync<UsuarioRespostaPesoDto>($"api/Usuario/RespostaUsuarioGame", usuarioRespostaPesoDto);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {

                }

            }
            
        }
        public async Task FinalizaGame(int Id)
        {

            var token = await ObterTokenDoLocalStorage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync<int>($"api/Game/FinalizarJogo", Id);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode is HttpStatusCode.NoContent)
                {

                }

            }

        }
        public async Task<string> ObterTokenDoLocalStorage()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "jwtToken");
        }
    }
}
