using Util;
using System.Text.RegularExpressions;

namespace AdventOfCodeRunner
{
    public class Day1
    {
        readonly static string[] numberStringsJustDigits = {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        };
        readonly static string[] numberStringsWithSpelled = {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        public static void PartA(string inputString)
        {
            Console.WriteLine("Part A");
            string[] lines = StringUtil.SplitStringByLines(inputString);
            int digitSum = 0;
            foreach (string line in lines)
            {
                int firstDigitValue = Convert.ToInt32(
                    FindFirstOccurrence(line, numberStringsJustDigits)
                );
                int lastDigitValue = Convert.ToInt32(
                    FindLastOccurrence(line, numberStringsJustDigits)
                );
                int digitValue = firstDigitValue * 10 + lastDigitValue;

                digitSum += digitValue;
            }
            Console.WriteLine(digitSum);
        }
        public static void PartB(string inputString)
        {
            Console.WriteLine("Part B");
            string[] lines = StringUtil.SplitStringByLines(inputString);
            int digitSum = 0;
            foreach (string line in lines)
            {
                int firstDigitValue = Convert.ToInt32(
                    ReplaceSpelledOutDigitsToDigits(
                        FindFirstOccurrence(line, numberStringsWithSpelled)
                    )
                );
                int lastDigitValue = Convert.ToInt32(
                    ReplaceSpelledOutDigitsToDigits(
                        FindLastOccurrence(line, numberStringsWithSpelled)
                    )
                );
                int digitValue = firstDigitValue * 10 + lastDigitValue;

                digitSum += digitValue;
            }
            Console.WriteLine(digitSum);
        }
        static string OnlyDigitsFromString(string inputString)
        {
            return Regex.Replace(inputString, "[a-zA-Z]", "");
        }

        static string ReplaceSpelledOutDigitsToDigits(string inputString)
        {
            string replacementString = inputString;
            replacementString = replacementString.Replace("one", "1");
            replacementString = replacementString.Replace("two", "2");
            replacementString = replacementString.Replace("three", "3");
            replacementString = replacementString.Replace("four", "4");
            replacementString = replacementString.Replace("five", "5");
            replacementString = replacementString.Replace("six", "6");
            replacementString = replacementString.Replace("seven", "7");
            replacementString = replacementString.Replace("eight", "8");
            replacementString = replacementString.Replace("nine", "9");
            return replacementString;
        }

        static string FindFirstOccurrence(string input, string[] searchStrings)
        {
            string firstOccurrence = searchStrings.Select(searchString => (searchString, input.IndexOf(searchString)))
                .Where(occurrence => occurrence.Item2 != -1)
                .MinBy(occurrence => occurrence.Item2).Item1;

            return firstOccurrence;
        }
        static string FindLastOccurrence(string input, string[] searchStrings)
        {
            string lastOccurrence = searchStrings.Select(searchString => (searchString, input.LastIndexOf(searchString)))
                .MaxBy(occurrence => occurrence.Item2).Item1;

            return lastOccurrence;
        }
    }
}
