namespace Util
{
    public class StringUtil
    {
        public static string[] SplitStringByLines(string toSplit)
        {
            return toSplit.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}