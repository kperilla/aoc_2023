using System.Collections.Generic;
using AdventOfCodeRunner;

namespace AdventOfCodeRunner.Test
{
    public class SetPowerTests
    {
        [Fact]
        public void SetPower_ReturnZero_WhenEmpty()
        {
            Dictionary<string, int> colors = new Dictionary<string, int>();
            int expectedPower = 0;

            int actualPower = Day2.setPower(colors);

            Assert.Equal(expectedPower, actualPower);
        }
        [Fact]
        public void SetPower_ReturnProductOfAll_WhenValid()
        {
            Dictionary<string, int> colors = new Dictionary<string, int>()
            {
                { "green", 3 },
                { "blue", 2 },
                { "red", 1 }
            };
            int expectedPower = 6;

            int actualPower = Day2.setPower(colors);

            Assert.Equal(expectedPower, actualPower);
        }
    }
}
