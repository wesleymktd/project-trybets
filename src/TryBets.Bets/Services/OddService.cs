using System.Net.Http;
using System.Text;
namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var apiUrl = $"http://localhost:5504/{MatchId}/{TeamId}/{BetValue}";

            // Crie um objeto JSON para enviar, se necessário.
            // Exemplo: var json = JsonConvert.SerializeObject(objeto);

            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            var response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                // A atualização falhou. Trate os erros aqui.
                var errorMessage = await response.Content.ReadAsStringAsync();
                // Trate o erro com base na mensagem ou no código de status da resposta.
                return errorMessage;
            }
    }
}