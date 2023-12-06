namespace AdventOfCodeRunner
{
    public class AdventOfCodeRunner
    {
        const string urlTemplate = "https://adventofcode.com/2023/day/{0}/input";
        const string sessionPath = "./session.key";
        static Dictionary<(int, string), Action<string>> functionDictionary = new Dictionary<(int, string), Action<string>>
            {
                {(1, "a"), Day1.PartA},
                {(1, "b"), Day1.PartB},
                {(2, "a"), Day2.PartA},
                {(2, "b"), Day2.PartB}
            };

        static async Task Main(string[] args)
        {
            int dayNum = Convert.ToInt32(args[0]);
            string part = args[1].ToLower();
            string url = String.Format(urlTemplate, dayNum);
            string sessionKey = SessionManager.ReadSessionFile(sessionPath);
            string inputString = await AocHttpClient.MakeGetRequest(url, sessionKey);
            Action<string> funcToRun = functionDictionary[(dayNum, part)];

            funcToRun(inputString);
        }
    }
}
