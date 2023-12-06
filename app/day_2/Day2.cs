using System.Text;
using Util;

namespace AdventOfCodeRunner
{
    public class Day2
    {
        public static void PartA(string inputString)
        {
            Console.WriteLine("Part A");
            
            string[] lines = StringUtil.SplitStringByLines(inputString);
            Dictionary<string, int> maxColors = new Dictionary<string, int>()
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 },
            };
            int validCount = 0;

            foreach (string line in lines)
            {
                GameLine gameLine = new GameLine(line);
                if (gameIsValid(gameLine, maxColors))
                {
                    validCount += gameLine.id;
                }
            }
            Console.WriteLine("Valid Count:");
            Console.WriteLine(validCount.ToString());

        }
        public static void PartB(string inputString)
        {
            Console.WriteLine("Part B");

            string[] lines = StringUtil.SplitStringByLines(inputString);
            int powerSum = 0;

            foreach (string line in lines)
            {
                GameLine gameLine = new GameLine(line);
                powerSum += setPower(findMinColors(gameLine));
            }
            Console.WriteLine("Sum:");
            Console.WriteLine(powerSum.ToString());
        }

        public static bool gameIsValid(GameLine gameLine, Dictionary<string, int> maxColors)
        {
            foreach (Dictionary<string, int> round in gameLine.rounds)
            {
                Dictionary<string, int> runningTab = new Dictionary<string, int>();
                foreach (string color in round.Keys) 
                {
                    if (!runningTab.ContainsKey(color))
                    {
                        runningTab[color] = 0;
                    }
                    runningTab[color] += round[color];
                    if (runningTab[color] > maxColors[color])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static int setPower(Dictionary<string, int> colors)
        {
            if (colors.Count == 0) return 0;
            int power = colors.Select(color => color.Value).Aggregate((acc, num) => acc * num);
            return power;
        }
        public static Dictionary<string, int> findMinColors(GameLine gameLine)
        {
            Dictionary<string, int> minColors = new Dictionary<string, int>();
            foreach (Dictionary<string, int> round in gameLine.rounds)
            {
                foreach (string color in round.Keys)
                {
                    if (!minColors.ContainsKey(color))
                    {
                        minColors[color] = 0;
                    }
                    if (round[color] > minColors[color])
                    {
                        minColors[color] = round[color];
                    }
                }
            }
            return minColors;
        }
    }

}