using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class GetAllPossibleGearsFromGridTest
    {
        [Fact]
        public void GetAllPossibleGearsFromGrid_ReturnEmpty_WhenNoSymbols()
        {
            string[] grid =
            [
                "12...34",
                ".......",
                ".......",
                "56..78."
            ];
            List<Point> actualPoints = Day3.GetAllPossibleGearsFromGrid(grid);

            Assert.Empty(actualPoints);
        }
        [Fact]
        public void GetAllPossibleGearsFromGrid_ReturnListWithAllStarLocations_WhenSymbolsExist()
        {
            string[] grid =
            [
                "/2..34+",
                "..*....",
                ".#...*.",
                "56..78*"
            ];
            Point pt = new Point(1, 5);
            List<Point> expectedPoints = new List<Point>()
            {
                new Point(2, 1),
                new Point(5, 2),
                new Point(6, 3)
            };
            List<Point> actualPoints = Day3.GetAllPossibleGearsFromGrid(grid);

            Assert.Equal(expectedPoints, actualPoints);
        }
        
    }
}
