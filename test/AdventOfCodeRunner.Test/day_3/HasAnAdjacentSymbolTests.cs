using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class HasAnAdjacentSymbolTests
    {
        [Fact]
        public void HasAnAdjacentSymbol_ReturnsFalse_WithNoAdjacentInCorner()
        {
            string[] grid = new string[4]
            {
                "12...34",
                ".......",
                ".......",
                "56..78."
            };
            Day3.NumberBlock numberBlock = new Day3.NumberBlock() { coords = new Point(x: 0, y: 0), size = 2, value = 12 };
            List<char> nonSymbolChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
            };

            bool actualHasAdj = Day3.HasAnAdjacentSymbol(grid, numberBlock, nonSymbolChars);
            
            Assert.False(actualHasAdj);
        }
        [Fact]
        public void HasAnAdjacentSymbol_ReturnsTrue_WithCornerAdjacent()
        {
            string[] grid = new string[4]
            {
                "12...34",
                "..../..",
                ".......",
                "56..78."
            };
            Day3.NumberBlock numberBlock = new Day3.NumberBlock() { coords = new Point(x: 5, y: 0), size = 2, value = 34 };
            List<char> nonSymbolChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
            };

            bool actualHasAdj = Day3.HasAnAdjacentSymbol(grid, numberBlock, nonSymbolChars);

            Assert.True(actualHasAdj);
        }
        [Fact]
        public void HasAnAdjacentSymbol_ReturnsTrue_WithSideAdjacent()
        {
            string[] grid = new string[4]
            {
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            };
            Day3.NumberBlock numberBlock = new Day3.NumberBlock() { coords = new Point(x: 4, y: 3), size = 2, value = 78 };
            List<char> nonSymbolChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'
            };

            bool actualHasAdj = Day3.HasAnAdjacentSymbol(grid, numberBlock, nonSymbolChars);

            Assert.True(actualHasAdj);
        }
    }
}
