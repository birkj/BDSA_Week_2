using Xunit;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void regexOutput_matches_inputResolution()
        {

            // Arrange
            IEnumerable<string> resolutions = new List<string> { "1920x1080", "1024x768", "800x600", "640x480","320x200", "320x240", "800x600","1280x960" };

            IEnumerable<(int, int)> expected = new List<(int, int)> { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) };

            // Act
            var actualOutput = RegExpr.Resolution(resolutions);

            // Assert
            Assert.Equal(expected, actualOutput);
        }

        [Fact]
        public void Lines_With_One_Word()
        {
            // Arrange
            var wordWithLowerCaseLetters = new List<string>() { "abjdnec" };
            var wordWithUpperCaseLetters = new List<string>() { "AJCHJAD" };
            var wordWithNumbers = new List<string>() { "048736" };

            // Act 
            var lowerCaseResult = RegExpr.SplitLine(wordWithLowerCaseLetters);
            var upperCaseResult = RegExpr.SplitLine(wordWithUpperCaseLetters);
            var numberResult = RegExpr.SplitLine(wordWithNumbers);

            // Assert
            Assert.Equal(wordWithLowerCaseLetters, lowerCaseResult);
            Assert.Equal(upperCaseResult, upperCaseResult);
            Assert.Equal(numberResult, numberResult);
        }

        [Fact]
        public void Lines_With_Multiple_Words()
        {
            // Arrange
            var lineWithSeveralWords = new List<string>() { "hello WORLD 1" };
            var lineWithSeveralWordsMixedCases = new List<string> { "hE11O w0Rld 62 s7Hs" };

            // Act
            var lineWithSeveralWordsResult = RegExpr.SplitLine(lineWithSeveralWords);
            var lineWithSeveralWordsMixedCasesResult = RegExpr.SplitLine(lineWithSeveralWordsMixedCases);

            // Assert
            Assert.Equal(new List<string>() { "hello", "WORLD", "1" }, lineWithSeveralWordsResult);
            Assert.Equal(new List<string>() { "hE11O", "w0Rld", "62", "s7Hs" }, lineWithSeveralWordsMixedCasesResult);
        }

        [Fact]
        public void Lines_With_Extra_Spaces()
        {
            // Arrange
            var lineWithTrailingSpaces = new List<string>() { "  hello WORLD 1 " };
            var lineWithExtraMiddleSpaces = new List<string> { "hE11O   w0Rld    62 s7Hs" };

            // Act
            var lineWithTrailingSpacesResult = RegExpr.SplitLine(lineWithTrailingSpaces);
            var lineWithExtraMiddleSpacesResult = RegExpr.SplitLine(lineWithExtraMiddleSpaces);

            // Assert
            Assert.Equal(new List<string>() { "hello", "WORLD", "1" }, lineWithTrailingSpacesResult);
            Assert.Equal(new List<string>() { "hE11O", "w0Rld", "62", "s7Hs" }, lineWithExtraMiddleSpacesResult);
        }
    }
}
