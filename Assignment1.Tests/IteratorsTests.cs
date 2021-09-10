using Xunit;
using System.Collections.Generic;
using System;
namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]

        public void FFFFFfffff_flattensTo_FfFfFfFfFf(){
            
            // Arrange
            var outerList = new List<List<char>>();
            outerList.Add(new List<char>{'F', 'f'});
            outerList.Add(new List<char>{'F', 'f'});
            outerList.Add(new List<char>{'F', 'f'});
            outerList.Add(new List<char>{'F', 'f'});
            outerList.Add(new List<char>{'F', 'f'});
            
            var expected = new[]{'F', 'f', 'F', 'f', 'F', 'f', 'F', 'f', 'F', 'f' };


            // Act
            var rawOutput = Iterators.Flatten(outerList);
            var cleanOutput = new char[10];

            var count = 0;
            foreach (var item in rawOutput)
            {
                cleanOutput[count] = item;
                count++;
            }

            //Assert
            Assert.Equal(expected, cleanOutput);

        }
    }
}
