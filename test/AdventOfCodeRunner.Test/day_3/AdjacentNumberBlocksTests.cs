using System.Collections.Generic;
using System.Drawing;
using AdventOfCodeRunner;
using static AdventOfCodeRunner.Day3;

namespace AdventOfCodeRunner.Test
{
    public class AdjacentNumberBlocksTests
    {
        [Fact]
        public void AdjacentNumberBlocks_ReturnEmpty_WhenNoAdjacent()
        {
            NumberBlock blockA = new NumberBlock() { coords = new Point(x: 0, y: 0), size = 2, value = 12 };
            NumberBlock blockB = new NumberBlock() { coords = new Point(x: 4, y: 3), size = 2, value = 78 };
            NumberBlock blockC = new NumberBlock() { coords = new Point(x: 4, y: 2), size = 2, value = 87 };
            Dictionary<Point, NumberBlock> blockMap = new Dictionary<Point, NumberBlock>()
            {
                {new Point(0, 0),  blockA },
                {new Point(1, 0),  blockA },
                {new Point(4, 2),  blockC },
                {new Point(5, 2),  blockC },
                {new Point(4, 3),  blockB },
                {new Point(5, 3),  blockB },
            };
            Point pt = new Point(1, 2);

            HashSet<NumberBlock> actualAdjacents = AdjacentNumberBlocks(pt, blockMap);

            Assert.Empty(actualAdjacents);
        }
        [Fact]
        public void AdjacentNumberBlocks_ReturnCorrectBlocks_WhenAdjacentExist()
        {
            NumberBlock blockA = new NumberBlock() { coords = new Point(x: 0, y: 0), size = 2, value = 12 };
            NumberBlock blockB = new NumberBlock() { coords = new Point(x: 4, y: 3), size = 2, value = 78 };
            NumberBlock blockC = new NumberBlock() { coords = new Point(x: 4, y: 2), size = 2, value = 87 };
            Dictionary<Point, NumberBlock> blockMap = new Dictionary<Point, NumberBlock>()
            {
                {new Point(0, 0),  blockA },
                {new Point(1, 0),  blockA },
                {new Point(4, 2),  blockC },
                {new Point(5, 2),  blockC },
                {new Point(4, 3),  blockB },
                {new Point(5, 3),  blockB },
            };
            Point pt = new Point(3, 2);
            HashSet<NumberBlock> expectedAdjacents = new HashSet<NumberBlock>() { blockC, blockB };

            HashSet<NumberBlock> actualAdjacents = AdjacentNumberBlocks(pt, blockMap);

            Assert.Equal(expectedAdjacents, actualAdjacents);
        }        
        
    }
}
