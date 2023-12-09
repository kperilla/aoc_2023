using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class GetAllNumbersFromGridTests
    {
        [Fact]
        public void GetAllNumbersFromGrid_GetCorrectNumbers_WhenSomeAreInCorners()
        {
            string[] grid = new string[4]
            {
                "12...34",
                ".......",
                ".......",
                "56..78."
            };
            List<Day3.NumberBlock> expectedNumbers = new List<Day3.NumberBlock>()
            { 
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 0), size = 2, value = 12 },
                new Day3.NumberBlock() {coords = new Point(x: 5, y: 0), size = 2, value = 34 },
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 3), size = 2, value = 56 },
                new Day3.NumberBlock() {coords = new Point(x: 4, y: 3), size = 2, value = 78 }
            };

            List<Day3.NumberBlock> actualNumbers = Day3.GetAllNumbersFromGrid(grid);

            Assert.Equal(expectedNumbers, actualNumbers);
        }
        [Fact]
        public void GetAllNumbersFromGrid_GetCorrectNumbers_WhenOnlySymbolsAndNumbers()
        {
            string[] grid = new string[4]
            {
                "12***34",
                "*******",
                "***56**",
                "78*****"
            };
            List<Day3.NumberBlock> expectedNumbers = new List<Day3.NumberBlock>()
            {
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 0), size = 2, value = 12 },
                new Day3.NumberBlock() {coords = new Point(x: 5, y: 0), size = 2, value = 34 },
                new Day3.NumberBlock() {coords = new Point(x: 3, y: 2), size = 2, value = 56 },
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 3), size = 2, value = 78 }
            };

            List<Day3.NumberBlock> actualNumbers = Day3.GetAllNumbersFromGrid(grid);

            Assert.Equal(expectedNumbers, actualNumbers);
        }
        [Fact]
        public void GetAllNumbersFromGrid_ReturnEmpty_WhenNoNumbers()
        {
            string[] grid = new string[4]
            {
                "....",
                ".*..",
                "....",
                "../."
            };
            List<Day3.NumberBlock> expectedNumbers = new List<Day3.NumberBlock>();

            List<Day3.NumberBlock> actualNumbers = Day3.GetAllNumbersFromGrid(grid);

            Assert.Equal(expectedNumbers, actualNumbers);
        }
        [Fact]
        public void GetAllNumbersFromGrid_ReturnLineNumOfNumbers_WhenAllNumbers()
        {
            string[] grid = new string[4]
            {
                "1111",
                "2222",
                "3333",
                "4444"
            };
            List<Day3.NumberBlock> expectedNumbers = new List<Day3.NumberBlock>()
            {
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 0), size = 4, value = 1111 },
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 1), size = 4, value = 2222 },
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 2), size = 4, value = 3333 },
                new Day3.NumberBlock() {coords = new Point(x: 0, y: 3), size = 4, value = 4444 }
            };

            List<Day3.NumberBlock> actualNumbers = Day3.GetAllNumbersFromGrid(grid);

            Assert.Equal(expectedNumbers, actualNumbers);
        }
    }
}
