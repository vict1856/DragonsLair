using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        public List<Match> matches = new List<Match>();
        public List<Team> winners = new List<Team>();
        private List<Team> losers = new List<Team>();
        private List<Team> results = new List<Team>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            return null;
        }

        public bool IsMatchesFinished()
        {
            foreach (Match match in matches)
            {
                if (match.Winner == match.FirstOpponent)
                {
                    winners.Add(match.FirstOpponent);
                }
                else
                {
                    winners.Add(match.SecondOpponent);
                }
            }
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches.Count == winners.Count)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Team> GetWinningTeams()
        {
            foreach (Match match in matches)
            {
                if (match.Winner == match.FirstOpponent)
                {
                    winners.Add(match.FirstOpponent);
                }
                else
                {
                    winners.Add(match.SecondOpponent);
                }
            }
            return winners;
    }

        public List<Team> GetLosingTeams()
        {
            foreach (Match match in matches)
            {
                if (match.Winner == match.FirstOpponent)
                {
                    losers.Add(match.SecondOpponent);
                }
                else
                {
                    losers.Add(match.FirstOpponent);
                }
            }
            return losers;
        }
    }
}
