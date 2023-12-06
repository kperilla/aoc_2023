using System.Collections.Generic;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class FindMinColorsTests
    {
        [Fact]
        public void FindMinColors_ReturnsEmpty_WhenInputEmpty()
        {
            string input = "Game 1:";
            GameLine gameLine = new GameLine(input);
            Dictionary<string, int> expectedMinColors = new Dictionary<string, int>();

            Dictionary<string, int> actualMinColors = Day2.findMinColors(gameLine);

            Assert.Equal(expectedMinColors, actualMinColors);
        }
        [Fact]
        public void FindMinColors_ReturnsExpectedMaxValues_WithValidInput()
        {
            string input = "Game 1: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
            GameLine gameLine = new GameLine(input);
            Dictionary<string, int> expectedMinColors = new Dictionary<string, int>()
            {
                {"green", 13 },
                {"blue", 6},
                {"red", 20}
            };

            Dictionary<string, int> actualMinColors = Day2.findMinColors(gameLine);

            Assert.Equal(expectedMinColors, actualMinColors);
        }
    }
}
