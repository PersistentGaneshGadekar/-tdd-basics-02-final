using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void AdditionAllPositiveNumberTest()
        {
            string expected = "4";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('+');
            calculator.numbers.Add(2);
            calculator.numbers.Add(2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AdditionAllNegativeNumberTest()
        {
            string expected = "-4";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('+');
            calculator.numbers.Add(-2);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AdditionOddNumberTest()
        {
            string expected = "0";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('+');
            calculator.numbers.Add(2);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivisionPositiveNumberTest()
        {
            string expected = "2";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('/');
            calculator.numbers.Add(4);
            calculator.numbers.Add(2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivisionByZerErrorTest()
        {
            string expected = "-E-";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('/');
            calculator.numbers.Add(4);
            calculator.numbers.Add(0);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivisionByNegativeNumberTest()
        {
            string expected = "-2";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('/');
            calculator.numbers.Add(4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivisionAllNegativeNumberTest()
        {
            string expected = "2";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('/');
            calculator.numbers.Add(-4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplyAllPositiveNumberTest()
        {
            string expected = "8";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('*');
            calculator.numbers.Add(4);
            calculator.numbers.Add(2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplyByNigativeNumberTest()
        {
            string expected = "-8";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('*');
            calculator.numbers.Add(4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplyAllNigativeNumberTest()
        {
            string expected = "8";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('*');
            calculator.numbers.Add(-4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractAllPositiveNumberTest()
        {
            string expected = "2";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('-');
            calculator.numbers.Add(4);
            calculator.numbers.Add(2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractByPositiveNumberTest()
        {
            string expected = "6";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('-');
            calculator.numbers.Add(4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SubtractAllNigativeNumberTest()
        {
            string expected = "-2";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('-');
            calculator.numbers.Add(-4);
            calculator.numbers.Add(-2);
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }
    }
}
