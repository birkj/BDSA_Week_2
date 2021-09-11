using Xunit;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]

        public void regexOutput_matches_inputResolution() {

            //Arrange
            IEnumerable<string> resolutions = new string[]{"1920x1080"};

    
            string expected = @"(1920, 1080)
                    (1024, 768)
                    (800, 600)
                    (640, 480)
                    (320, 200)
                    (320, 240)
                    (800, 600)
                    (1280, 960)";

            //Act
            var actualOutput = RegExpr.Resolution(resolutions);

            //Assert
            Assert.Equal(expected, actualOutput);
        }
    }
}
