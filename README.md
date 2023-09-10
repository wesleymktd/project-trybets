## 🧐 Sobre

<p align="left"> 
O projeto Trybets consiste no backend de um site de apostas. Nesse projeto a aplicação já veio pronta no formato monolítica, minha participação no projeto foi dividir essa aplicação em microsserviços com determinadas especificidades.

### Microsserviço TryBets.Matches.
  - Este microsserviço será responsável pela visualização de times e partidas, onde ele funciona na porta `5502`.
  - As rotas necessárias nesse microsserviço são:
<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-get.png' />    /team</h3>

Rota utilizada para obter a lista de times.

<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
    </tr>
    <tr>
        <td>(em branco)</td>
        <td>Não</td>
        <td>200</td>
        <td>
            <pre lang="json">
[
    {
        "teamId": 1,
        "teamName": "Sharks"
    }, /*...*/
]
            </pre>
        </td>
    </tr>

</table>

<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-get.png' />    /match/{finished}</h3>

Rota utilizada para obter a lista de partidas. Parâmetro {finished} varia entre `true` e `false` para listar partidas finalizadas ou não.


<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
    </tr>
    <tr>
        <td>(em branco)</td>
        <td>Não</td>
        <td>200</td>
        <td>
            <pre lang="json">
[
	{
		"matchId": 1,
		"matchDate": "2023-07-23T15:00:00",
		"matchTeamAId": 1,
		"matchTeamBId": 8,
		"teamAName": "Sharks",
		"teamBName": "Bulls",
		"matchTeamAOdds": "3,33",
		"matchTeamBOdds": "1,43",
		"matchFinished": true,
		"matchWinnerId": 1
	}, /*...*/
]
            </pre>
        </td>
    </tr>

</table>

### Microsserviço TryBets.Users.
  - Este microsserviço será responsável pelo cadastro e login de pessoas usuárias.
  - Este microsserviço funciona na porta 5501.
  - As rotas necessárias nesse microsserviço são:
<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-post.png' />    /user/signup</h3>

Rota utilizada para cadastrar uma nova pessoa usuária. Ao cadastrar com sucesso, retorna um token. Não permitido adicionar duas pessoas usuárias com o mesmo e-mail.


<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
        <th>Observações</th>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "Name": "Isabel Santos",
		    
   "Email": "isabel.santos@trybets.com",
   "Password": "123456"
}
            </pre>
        </td>
        <td>Não</td>
        <td>201</td>
        <td>
            <pre lang="json">
{
   "token": "eyJhbG..."
}
            </pre>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "Name": "Isabel Santos",
   "Email": "isabel.santos@trybets.com",
   "Password": "123456"
}
            </pre>
        </td>
        <td>Não</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
   "message": "E-mail already used"
}
            </pre>
        </td>
        <td>Caso o e-mail da pessoa usuária já tenha sido cadastrado no banco de dados.</td>
    </tr>

</table>


<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-post.png' />    /user/login</h3>

Rota utilizada para realizar o login de uma pessoa usuária.


<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
        <th>Observações</th>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "Email": "isabel.santos@trybets.com",
   "Password": "123456"
}
            </pre>
        </td>
        <td>Não</td>
        <td>200</td>
        <td>
            <pre lang="json">
{
   "token": "eyJhbG..."
}
            </pre>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "Email": "isabel.santos@trybets.com",
   "Password": "1234567"
}
            </pre>
        </td>
        <td>Não</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
   "message": "Authentication failed"
}
            </pre>
        </td>
        <td>Caso a pessoa usuária não tenha os dados autenticados ou não informe algum dos parâmetros corretamente.</td>
    </tr>

</table>

### Microsserviço TryBets.Bets.
  - Este microsserviço será responsável pelo cadastro e visualização de apostas.
  - Este microsserviço funciona na porta 5503.
  - As rotas necessárias nesse microsserviço são:
<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-post.png' />    /bet</h3>

Rota utilizada para realizar uma nova aposta


<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
        <th>Observações</th>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 5,
   "TeamId":  2,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Sim</td>
        <td>201</td>
        <td>
            <pre lang="json">
{
   "betId": 1,
   "matchId": 5,
   "teamId": 2,
   "betValue": 550.65,
   "matchDate": "2024-03-15T14:00:00",
   "teamName": "Eagles",
   "email": "isabel.santos@trybets.com"
}
            </pre>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 5,
   "TeamId":  2,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Não</td>
        <td>401</td>
        <td>
        </td>
        <td>Caso o token não tenha sido informado ou esteja errado</td>
    </tr>
    <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 5,
   "TeamId":  6,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
    "message": "Team is not in this match"
}
            </pre>
        </td>
        <td>Caso o time não esteja na partida correta</td>
    </tr>
     <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 5,
   "TeamId":  60,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
    "message": "Team not founded"
}
            </pre>
        </td>
        <td>Caso o time não exista</td>
    </tr>
     <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 50,
   "TeamId":  6,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
    "message": "Match not founded"
}
            </pre>
        </td>
        <td>Caso a partida não exista</td>
    </tr>
     <tr>
        <td>
            <pre lang="json">
{
   "MatchId": 1,
   "TeamId":  6,
   "BetValue": 550.65
}
            </pre>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
            <pre lang="json">
{
    "message": "Match finished"
}
            </pre>
        </td>
        <td>Caso a partida já tenha sido finalizada</td>
    </tr>
</table>



<h3 style="vertical-align:middle;display:inline-block;"><img src='img/icon-get.png' />    /bet/{BetId}</h3>

Rota utilizada para visualizar uma aposta criada. Uma aposta só pode ser visualizada pela pessoa que a criou.

<table>
    <tr>
        <th>Request</th>
        <th>Token?</th>
        <th>Status</th>
        <th>Response</th>
        <th>Observações</th>
    </tr>
    <tr>
        <td>
        </td>
        <td>Sim</td>
        <td>200</td>
        <td>
            <pre lang="json">
{
   "betId": 1,
   "matchId": 5,
   "teamId": 2,
   "betValue": 550.65,
   "matchDate": "2024-03-15T14:00:00",
   "teamName": "Eagles",
   "email": "isabel.santos@trybets.com"
}
            </pre>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
            (Indiferente)
        </td>
        <td>Caso a aposta não pertencer à pessoa usuária do token.</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>Sim</td>
        <td>400</td>
        <td>
             <pre lang="json">
{
   "message": "Bet not founded"
}
            </pre>
        </td>
        <td>Caso a aposta não exista.</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>Não</td>
        <td>401</td>
        <td>
        </td>
        <td>Caso não seja informado um token.</td>
    </tr>
</table>

### Microsserviço TryBets.Odds.
  - Este microsserviço será responsável pela atualização das odds de cada partida. Este microsserviço é novo e não é acessível ao site. Ele será utilizado pelo microsserviço TryBets.Bets e será chamado por este toda vez que uma nova aposta for cadastrada.

  - Este microsserviço funciona na porta 5504.
  - A rota necessária nesse microsserviço é:
    - `PATCH`/odd/{matchId}/{TeamId}/{BetValue}
### Cada microsserviços foi desenvolvido os Dockerfiles

## ⚒ Instalando <a name = "installing"></a>

```bash
# Clone o projeto
$ git clone git@github.com:wesleymktd/project-trybets.git
# Acesse
$ cd ./project-trybets/src
# Instale as dependencias
$ dotnet restore
# Acesse o diretório TrybeHotel
$ cd TrybeHotel
# Inicie o projeto
$ dotnet run

```

## Principais tecnologias utilizadas:
- C#;
- ASP.NET
- EntityFramework
- JWT
- azure sql edge
