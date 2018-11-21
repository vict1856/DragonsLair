using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;

namespace DragonsLair
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void GetMatches()
        {
            Tournament ourtournament;
            ourtournament = new Tournament("Our Tournament");
            ourtournament.SetupTestRounds();

            Console.WriteLine("Choose round:");
            string read = Console.ReadLine();
            int number = int.Parse(read);
            Round round = ourtournament.GetRound(number - 1);
            List<Match> roundmatches = round.matches;
            Console.WriteLine("Find Match by Name:");
            string name = Console.ReadLine();
            Team team = new Team(name);

            foreach (Match match in roundmatches)
            {
                if(match.FirstOpponent.Name == team.Name || match.SecondOpponent.Name == team.Name)
                {
                    Console.WriteLine(match.FirstOpponent + " VS " + match.SecondOpponent);
                }
                //Console.WriteLine(match.FirstOpponent + " vs " + match.SecondOpponent);
            }
        }
        public void ShowScore(string tournamentName)
        {
            Tournament ourtournament;
            ourtournament = new Tournament("Our Tournament");
            ourtournament.SetupTestRounds();

            int NOR = ourtournament.GetNumberOfRounds();
            List<string> winConverter = new List<string>();
            List<string> teams = new List<string>();
            List<string> allWinners = new List<string>();
            List<string> allLosers = new List<string>();
            List<string> teamsInOrder = new List<string>();
            for (int i = 0; i < NOR; i++)
            {
                Round currentRound = ourtournament.GetRound(i);
                winConverter = currentRound.GetWinningTeams().ConvertAll(idx => idx.ToString());
                for (int i2 = 0; i2 < winConverter.Count; i2++)
                {
                    allWinners.Add(winConverter[i2]);
                }
            }
            for (int i = 0; i < NOR; i++)
            {
                Round currentRound = ourtournament.GetRound(i);
                winConverter = currentRound.GetLosingTeams().ConvertAll(idx => idx.ToString());
                for (int i2 = 0; i2 < winConverter.Count; i2++)
                {
                    allLosers.Add(winConverter[i2]);
                }
            }
            //for (int i = 0; i < allWinners.Count; i++)
            //{
            //    Console.WriteLine(allWinners[i] + " WON AGAINST " + allLosers[i]);
            //}
            Console.WriteLine("Number of Wins: ");
            teams = ourtournament.GetTeams().ConvertAll(idx => idx.ToString());
            int wins;
            int wins2;
            for (int i = 0; i <= ourtournament.GetNumberOfRounds(); i++)
            {
                for (int i2 = 0; i2 < teams.Count; i2++)
                {
                    wins = 0;
                    for (int i3 = 0; i3 < allWinners.Count; i3++)
                    {
                        if (teams[i2] == allWinners[i3])
                        {
                            wins += 1;
                        }
                    }
                    if (wins == i)
                    {
                        teamsInOrder.Add(teams[i2]);
                    }
                }
            }

            for (int i = teamsInOrder.Count - 1; i >= 0; i--)
            {
                wins2 = 0;
                for (int i2 = 0; i2 < allWinners.Count; i2++)
                {
                    if (allWinners[i2] == teamsInOrder[i])
                    {
                        wins2 += 1;
                    }
                }
                Console.WriteLine(teamsInOrder[i] + ": " + wins2);
            }

        }

        public TournamentRepo GetTournamentRepository()
        {
            return tournamentRepository;
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
