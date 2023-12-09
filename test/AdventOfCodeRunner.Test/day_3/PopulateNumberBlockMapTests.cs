using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;
using static AdventOfCodeRunner.Day3;

namespace AdventOfCodeRunner.Test
{
    public class PopulateNumberBlockMapTests
    {
        [Fact]
        public void PopulateNumberBlockMap_ReturnEmpty_WhenNoNumbers()
        {
            string[] grid =
            [
                ".......",
                ".......",
                ".....*.",
                "......."
            ];

            Dictionary<Point, NumberBlock> actualBlockMap = Day3.PopulateNumberBlockMap(grid);

            Assert.Empty(actualBlockMap);
        }
        [Fact]
        public void PopulateNumberBlockMap_ReturnPopulated_WhenNumbersExist()
        {
            string[] grid =
            [
                "12.....",
                ".......",
                ".....*.",
                "....78."
            ];
            NumberBlock blockA = new NumberBlock() { coords = new Point(x: 0, y: 0), size = 2, value = 12 };
            NumberBlock blockB = new NumberBlock() { coords = new Point(x: 4, y: 3), size = 2, value = 78 };
            Dictionary<Point, NumberBlock> expectedBlockMap = new Dictionary<Point, NumberBlock>()
            {
                {new Point(0, 0),  blockA },
                {new Point(1, 0),  blockA },
                {new Point(4, 3),  blockB },
                {new Point(5, 3),  blockB },
            };
                

            Dictionary<Point, NumberBlock> actualBlockMap = Day3.PopulateNumberBlockMap(grid);

            Assert.Equal(expectedBlockMap, actualBlockMap);
        }
        
    }
}
