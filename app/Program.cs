// using static AdventOfCodeRunner.Day1;

// See https://aka.ms/new-console-template for more information
namespace AdventOfCodeRunner
{
    public class AdventOfCodeRunner
    {
        static void Main(string[] args)
        {
            Dictionary<(int, string), Func<int>> functionDictionary = new Dictionary<(int, string), Func<int>>
            {
                {(1, "a"), Day1.PartA},
                {(1, "b"), Day1.PartB}
            };
            int dayNum = Convert.ToInt32(args[0]);
            string part = args[1].ToLower();

            Func<int> funcToRun = functionDictionary[(dayNum, part)];

            Console.WriteLine(funcToRun());
        }
    }
}