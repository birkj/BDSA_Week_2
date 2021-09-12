using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void Lines_With_One_Word() {

            // Arrange
            var wordWithLowerCaseLetters = new List<string>(){"abjdnec"};
            var wordWithUpperCaseLetters = new List<string>(){"AJCHJAD"};
            var wordWithNumbers = new List<string>(){"048736"};

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
        public void Lines_With_Multiple_Words() {

            // Arrange
            var lineWithSeveralWords = new List<string>(){"hello WORLD 1"};
            var lineWithSeveralWordsMixedCases = new List<string>{"hE11O w0Rld 62 s7Hs"};

            // Act
            var lineWithSeveralWordsResult = RegExpr.SplitLine(lineWithSeveralWords);
            var lineWithSeveralWordsMixedCasesResult = RegExpr.SplitLine(lineWithSeveralWordsMixedCases);

            // Assert
            Assert.Equal(new List<string>(){"hello", "WORLD", "1"}, lineWithSeveralWordsResult);
            Assert.Equal(new List<string>(){"hE11O", "w0Rld", "62", "s7Hs"}, lineWithSeveralWordsMixedCasesResult);
        }
    }
}
