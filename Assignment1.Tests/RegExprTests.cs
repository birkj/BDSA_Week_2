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
            IEnumerable<string> resolutions = new List<string> { "1920x1080", "1024x768", "800x600", "640x480", "320x200", "320x240", "800x600", "1280x960" };

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



        [Fact]
        public void regexOutputsInnerText()
        {
            //Arrange
            string input = @"<div>
                <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
            </div>";
            var expected = new List<string> { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };
            //Act 

            var output = RegExpr.InnerText(input, "a");
            var outputInList = new List<string>();


            foreach (var item in output)
            {
                outputInList.Add(item);
            }


            //Assert
            Assert.Equal(expected, outputInList);

        }

        [Fact]
        public void regexOutputsNestedInnerText()
        {
            string input = @"<div>
        <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
        </div>";


            var expected = new List<string> { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };
            //Act 

            var output = RegExpr.InnerText(input, "p");
            var outputInList = new List<string>();


            foreach (var item in output)
            {
                outputInList.Add(item);
            }


            //Assert
            Assert.Equal(expected, outputInList);


        }

    }


}
