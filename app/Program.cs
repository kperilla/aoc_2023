// using static AdventOfCodeRunner.Day1;

// See https://aka.ms/new-console-template for more information
namespace AdventOfCodeRunner
{
    public class AdventOfCodeRunner
    {
        static async Task Main(string[] args)
        {
            const string urlTemplate = "https://adventofcode.com/2023/day/{0}/input";
            const string sessionPath = "./session.key";
            Dictionary<(int, string), Func<string, string>> functionDictionary = new Dictionary<(int, string), Func<string, string>>
            {
                {(1, "a"), Day1.PartA},
                {(1, "b"), Day1.PartB}
            };
            int dayNum = Convert.ToInt32(args[0]);
            string part = args[1].ToLower();
            string url = String.Format(urlTemplate, dayNum);
            string sessionKey = SessionManager.ReadSessionFile(sessionPath);
            Func<string, string> funcToRun = functionDictionary[(dayNum, part)];

            string inputString = await AocHttpClient.MakeGetRequest(url, sessionKey);

            Console.WriteLine(funcToRun(inputString));
        }
    }
}
