using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using Util;

namespace AdventOfCodeRunner
{
    public class Day3
    {
        public static void PartA(string inputString)
        {
            Console.WriteLine("Part A");
            string[] lines = StringUtil.SplitStringByLines(inputString);
            int sum = 0;
            // Storing coordinates of numbers with size
            List<NumberBlock> numbers = GetAllNumbersFromGrid(lines);
            List<char> nonSymbolChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
            };
            // For each number
            foreach (NumberBlock numberBlock in numbers)
            {
                // Search adjacent spots for a symbol
                if (HasAnAdjacentSymbol(lines, numberBlock, nonSymbolChars))
                {
                    // If one exists add to sum
                    sum += numberBlock.value;
                }
            }

            Console.WriteLine("Sum:");
            Console.WriteLine(sum);
        }
        public static void PartB(string inputString)
        {
            Console.WriteLine("Part B");

            string[] lines = StringUtil.SplitStringByLines(inputString);
            int productSum = 0;
            // Populate numberBlockMap
            Dictionary<Point, NumberBlock> numberBlockMap = PopulateNumberBlockMap(lines);
            // Get possible gear
            List<Point> gearCandidates = GetAllPossibleGearsFromGrid(lines);
            // Search for adjacent numberBlocks
            foreach (Point gearCand in gearCandidates)
            {
                HashSet < NumberBlock > adjacentNumbers = AdjacentNumberBlocks(gearCand, numberBlockMap);
                // if size is 2, add the product
                if (adjacentNumbers.Count == 2) 
                {
                    productSum += adjacentNumbers.First().value * adjacentNumbers.Last().value;
                }
            }

            Console.WriteLine("Sum:");
            Console.WriteLine(productSum);

        }
        public static List<NumberBlock> GetAllNumbersFromGrid(string[] lines) {
            List<NumberBlock> numberList = new List<NumberBlock>();
            string numberPattern = @"(?<number>\d+)";
            Regex numberRegex = new Regex(numberPattern);
            for (int y = 0; y < lines.Length; y++)
            {
                MatchCollection numberMatch = numberRegex.Matches(lines[y]);
                foreach (Match match in numberMatch)
                {
                    numberList.Add(new NumberBlock() { 
                        coords = new Point(match.Index, y), 
                        size = match.Length, 
                        value = Convert.ToInt32(match.Value) 
                    });
                }
            }

            return numberList;
        }

        public static HashSet<NumberBlock> AdjacentNumberBlocks(Point gearCand, Dictionary<Point,  NumberBlock> numberBlockMap)
        {
            HashSet<NumberBlock > numberSet = new HashSet<NumberBlock>();
            for (int yInc = -1; yInc <= 1; yInc++)
            {
                for (int xInc = -1; xInc <= 1; xInc++)
                {
                    Point adjPoint = new Point (gearCand.X + xInc, gearCand.Y + yInc);
                    if (adjPoint != gearCand && numberBlockMap.ContainsKey(adjPoint))
                    {
                        numberSet.Add(numberBlockMap[adjPoint]);
                    }
                }
            }
            return numberSet;
        }
        public static Dictionary<Point, NumberBlock> PopulateNumberBlockMap(string[] lines)
        {
            Dictionary<Point, NumberBlock> blockMap = new Dictionary<Point, NumberBlock>();
            List<NumberBlock> numberBlocks = GetAllNumbersFromGrid(lines);
            foreach (NumberBlock numberBlock in numberBlocks)
            {
                for (int digit = 0; digit < numberBlock.size; digit++) 
                {
                    int x = numberBlock.coords.X + digit;
                    int y = numberBlock.coords.Y;
                    blockMap.Add(new Point(x, y), numberBlock);
                }
            }
            return blockMap;
        }

        public static List<Point> GetAllPossibleGearsFromGrid(string[] lines)
        {
            List<Point> possibleGears = new List<Point>();
            char gearSymbol = '*';
            int gridWidth = lines[0].Length;
            int gridHeight = lines.Length;
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                { 
                    if (lines[y][x] == gearSymbol)
                    {
                        possibleGears.Add(new Point(x, y));
                    }
                }
            }
            return possibleGears;
        }

        public static bool HasAnAdjacentSymbol(string[] lines, NumberBlock number, List<char> nonSymbolChars)
        {
            Point start = number.coords;
            int gridWidth = lines[0].Length;
            int gridHeight = lines.Length;
            List<Point> pointsToCheck = new List<Point>();
            for (int x = start.X - 1; x <= start.X + number.size; x++)
            {
                pointsToCheck.Add(new Point(x, start.Y - 1));
                pointsToCheck.Add(new Point(x, start.Y + 1));
               
            }
            pointsToCheck.Add(new Point(start.X - 1, start.Y));
            pointsToCheck.Add(new Point(start.X + number.size, start.Y));

            foreach(Point point in pointsToCheck)
            {
                // rather than contains I may have to do that it's neither a digit or a .
                if (IsInGrid(point, lines) && !nonSymbolChars.Contains(lines[point.Y][point.X]))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsInGrid(Point point, string[] lines)
        {
            if (point.X < 0 || point.X >= lines[0].Length || point.Y < 0 || point.Y >= lines.Length)
            {
                return false;
            }
            return true;
        }

        public struct NumberBlock
        {
            public Point coords;
            public int value;
            public int size;
        }

    }

}