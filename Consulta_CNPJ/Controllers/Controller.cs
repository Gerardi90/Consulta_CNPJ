using Consulta_CNPJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consulta_CNPJ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CnpjController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly Context_CNPJ _dbContext; // Adicionando o DbContext

        // Injetando o DbContext no construtor
        public CnpjController(HttpClient httpClient, Context_CNPJ dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext; // Inicializando o DbContext
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> GetCnpjInfo(string cnpj)
        {
            // URL da API ReceitaWS
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

            // Fazendo a requisição GET para a API externa
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Erro ao consultar a API.");
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var cnpjData = JsonConvert.DeserializeObject<CNPJ_DADOS>(responseData);

            if (cnpjData != null)
            {
                // Adiciona o objeto ao DbSet
                _dbContext.CNPJ_DADOS.Add(cnpjData);
                await _dbContext.SaveChangesAsync(); // Salva as alterações no banco
            }

            return Ok(cnpjData); // Retorna os dados deserializados como JSON
        }
    }
}
