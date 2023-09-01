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
        var apiUrl = $"http://localhost:5504/odd/{MatchId}/{TeamId}/{BetValue}";

            
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return content;
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