using System;
using Xunit;

namespace StringCal
{
    public class StringCalculator_Add
    {

        private StringCalculator _calculator = new StringCalculator();
        [Fact]
        public void Returns0GivenEmptyString()
        {
           var resultat= _calculator.Add("");
            Assert.Equal(0, resultat);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("2", 2)]
        public void Returns1GivenStringWithOneNumber(string numbers, int expectedResult)
        {
            var resultat = _calculator.Add(numbers);
            Assert.Equal(expectedResult, resultat);
        }

        [InlineData("1,2", 3)]
        [InlineData("2,5", 5)]
        public void Returns1GivenStringWithTwoComaSeparatedNumbers(string numbers, int expectedResult)
        {
            var resultat = _calculator.Add(numbers);
            Assert.Equal(expectedResult, resultat);
        }

        [InlineData("1,2", 3)]
        [InlineData("2,5", 5)]
        public void Returns1GivenStringWithTwoComaSeparatedNumbersComer(string numbers, int expectedResult)
        {
            var resultat = _calculator.Add(numbers);
            Assert.Equal(expectedResult, resultat);
        }

        [Fact]
        public void TestMyListTabs()
        {
            var tabs = new int[] { 1, 3, 5, 7, 9 };
            var resultat = _calculator.GetMinAndMax(tabs);
            Assert.Equal(1, resultat.min);
            Assert.Equal(9, resultat.max);
        }
    }
}
