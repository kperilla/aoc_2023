using System.Text.RegularExpressions;

namespace AdventOfCodeRunner
{
    public class GameLine
    {
        public List<Dictionary<string, int>> rounds;
        public int id;
        public GameLine(string inputString)
        {
            rounds = new List<Dictionary<string, int>>();
            string idPattern = @"^Game (?<id>\d+)";
            string roundPattern = @"(?<number>\d+)\s+(?<color>\w+)";
            Regex idRegex = new Regex(idPattern);
            Regex roundRegex = new Regex(roundPattern);
            Match idMatch = idRegex.Match(inputString);
            if (idMatch.Success)
            {
                id = Convert.ToInt32(idMatch.Groups["id"].Value);
            } 
            else
            {
                throw new ArgumentException("Invalid input");
            }
            string secondPart = inputString.Split(':')[1];
            string[] roundsStrings = secondPart.Split(';');

            foreach(string roundString in roundsStrings)
            {
                if (roundString.Length > 0)
                {
                    MatchCollection matches = roundRegex.Matches(roundString);
                    Dictionary<string, int> round = new Dictionary<string, int>();
                    foreach (Match match in matches)
                    {
                        round.Add(match.Groups["color"].Value, Convert.ToInt32(match.Groups["number"].Value));
                    }
                    rounds.Add(round);
                }
                
            }
        }
    }
}