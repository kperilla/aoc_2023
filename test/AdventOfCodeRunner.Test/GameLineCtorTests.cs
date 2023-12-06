using System.Collections.Generic;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class GameLineCtorTests
    {
        [Fact]
        public void Ctor_ColorDictsShouldMatchInputString_WhenValid()
        {
            string input = "Game 1: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
            List<Dictionary<string, int>> expectedColors = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                { 
                    {"green", 8 }, 
                    {"blue", 6},
                    {"red", 20}
                },
                new Dictionary<string, int>()
                { 
                    {"green", 13 }, 
                    {"blue", 5},
                    {"red", 4}
                },
                new Dictionary<string, int>()
                { 
                    {"green", 5 }, 
                    {"red", 1}
                },
            };

            GameLine sut = new GameLine(input);

            Assert.Equal(sut.rounds, expectedColors);
        }
        [Fact]
        public void Ctor_ColorDictListShouldBeEmpty_WhenEmpty()
        {
            string input = "Game 1:";
            List<Dictionary<string, int>> expectedColors = new List<Dictionary<string, int>>();

            GameLine sut = new GameLine(input);

            Assert.Equal(sut.rounds, expectedColors);
        }
        [Fact]
        public void Ctor_GetsIdFromInputString_WhenValid()
        {
            string input = "Game 2: 8 green";
            int expected_id = 2;

            GameLine sut = new GameLine(input);

            Assert.Equal(sut.id, expected_id);
        }
        [Fact]
        public void Ctor_ThrowsError_WhenInvalid()
        {
            string input = "Not Valid";

            Assert.Throws<ArgumentException>(() => new GameLine(input));

        }
    }
}