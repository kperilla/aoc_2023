using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class IsInGridTests
    {
        [Fact]
        public void IsInGrid_ReturnFalse_WhenOutOnTop()
        {
            string[] grid =
            [
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            ];
            Point pt = new Point(1, -1);
            bool actualIsInGrid = Day3.IsInGrid(pt, grid);

            Assert.False(actualIsInGrid);
        }
        [Fact]
        public void IsInGrid_ReturnFalse_WhenOutOnBottom()
        {
            string[] grid =
            [
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            ];
            Point pt = new Point(1, 5);
            bool actualIsInGrid = Day3.IsInGrid(pt, grid);

            Assert.False(actualIsInGrid);
        }
        [Fact]
        public void IsInGrid_ReturnFalse_WhenOutOnLeft()
        {
            string[] grid = new string[4]
            {
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            };
            Point pt = new Point(-1, 1);
            bool actualIsInGrid = Day3.IsInGrid(pt, grid);

            Assert.False(actualIsInGrid);
        }
        [Fact]
        public void IsInGrid_ReturnFalse_WhenOutOnRight()
        {
            string[] grid =
            [
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            ];
            Point pt = new Point(7, 1);
            bool actualIsInGrid = Day3.IsInGrid(pt, grid);

            Assert.False(actualIsInGrid);
        }
        [Fact]
        public void IsInGrid_ReturnTrue_WhenInside()
        {
            string[] grid =
            [
                "12...34",
                ".......",
                ".....*.",
                "56..78."
            ];
            Point pt = new Point(1, 1);
            bool actualIsInGrid = Day3.IsInGrid(pt, grid);

            Assert.True(actualIsInGrid);
        }
        
    }
}
