using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        
        var betValueDecimal = decimal.Parse(BetValue.Replace(",", "."), CultureInfo.InvariantCulture);
        
        // if (!decimal.TryParse(BetValue, out decimal betValueDecimal))
        // {
        //     throw new ArgumentException("BetValue não é um número decimal válido.");
        // }

        Match findedMatch = _context.Matches.FirstOrDefault(m => m.MatchId == MatchId)!;
        if (findedMatch == null) throw new Exception("Match not founded");

        Team findedTeam = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId)!;
        if (findedTeam == null) throw new Exception("Team not founded");


        if (findedMatch.MatchTeamAId != TeamId && findedMatch.MatchTeamBId != TeamId ) throw new Exception("Team is not in this match");

        
            if (TeamId == findedMatch.MatchTeamAId)
            {
                findedMatch.MatchTeamAValue += betValueDecimal;
            }
            else if (TeamId == findedMatch.MatchTeamBId)
            {
                findedMatch.MatchTeamBValue += betValueDecimal;
            }
            _context.Matches.Update(findedMatch);
            _context.SaveChanges();

            return findedMatch;

    }
}