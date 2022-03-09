using System;
using Xunit;
using stringCalculator;
using stringCalculatorTest;

namespace stringCalculatorTest
{
    public class stringCalculatorTest
    {
        [Fact]
        public void TEmptyStringReturnsZero()
        {
            int result = Calculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("15", 15)]
        [InlineData("25", 25)]
        [InlineData("1", 0)]
        public void SingleNumberReturnTheValue(string input, int expectedResult)
        {
            int result = Calculator.SumString(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("31,9", 40)]
        [InlineData("20,20", 40)]
        [InlineData("25,15", 40)]

        public void TwoNumberCommaDelimitedReturnTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
        [Theory]
        [InlineData("31\n9", 40)]
        [InlineData("20\n20", 40)]
        [InlineData("25\n15", 40)]

        public void TwoNumberNewlineDelimitedReturnTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
        
        [Theory]
        [InlineData("21\n9,10", 40)]
        [InlineData("20\n20\n20", 60)]
        [InlineData("25,15\n5", 45)]

        public void ThreeNumberDelimitedReturnTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
        
        [Theory]
        [InlineData("-21\n9,10")]
        [InlineData("20\n-20\n20")]
        [InlineData("-25,15\n5")]
        public void NegativeNumberThrowsException(string s)
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() =>
           {
               Calculator.SumString(s);
           });
        }

        [Theory]
        [InlineData("21\n9,10,10000", 40)]
        [InlineData("20\n10000\n20\n20", 60)]
        [InlineData("25,1200,15\n5", 45)]

        public void NumbersGreaterThen1000AreIgnored(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//^\n21\n9^10", 40)]
        [InlineData("//$\n20$10000\n20\n20", 60)]
        [InlineData("//%\n25,1200%15\n5", 45)]

        public void DelimeterDefinedWithSlash(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//^\n21\n9^10", 40)]
        [InlineData("//$\n20$10000\n20\n20", 60)]
        [InlineData("//%\n25,1200%15\n5", 45)]

        public void DelimeterDefinedWithSlashWithMultipleChars(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
    }
}
