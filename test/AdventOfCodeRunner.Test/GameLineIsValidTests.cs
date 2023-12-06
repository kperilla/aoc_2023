using System.Collections.Generic;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class GameLineIsValidTests
    {
        [Fact]
        public void GameLineIsValid_ReturnsFalse_WhenOneColorLimitPassed()
        {
            string input = "Game 1: 1 green, 2 blue, 2 red; 1 red";

            GameLine gameLine = new GameLine(input);
            Dictionary<string, int> colorLimits = new Dictionary<string, int>()
            {
                { "green", 3 },
                { "blue", 2 },
                { "red", 1 }
            };

            bool isValid = Day2.gameIsValid(gameLine, colorLimits);

            Assert.False(isValid);
        }
        [Fact]
        public void GameLineIsValid_ReturnsTrue_WhenNoColorLimitPassed()
        {
            string input = "Game 1: 1 green, 2 blue, 2 red; 1 red";

            GameLine gameLine = new GameLine(input);
            Dictionary<string, int> colorLimits = new Dictionary<string, int>()
            {
                { "green", 3 },
                { "blue", 2 },
                { "red", 2 }
            };

            bool isValid = Day2.gameIsValid(gameLine, colorLimits);

            Assert.True(isValid);
        }
    }
}
