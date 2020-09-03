using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorTests
    {
        
        [Fact]
        public void AdditionScenario1Test()
        {
            //Scenario is 10 + 2 = 12.
            Calculator calculator = new Calculator();
            string result1= calculator.SendKeyPress('1');
            Assert.Equal("1", result1);
            string result2 = calculator.SendKeyPress('0');
            Assert.Equal("10", result2);
            string result3 = calculator.SendKeyPress('+');
            Assert.Equal("10", result3);
            string result4 = calculator.SendKeyPress('2');
            Assert.Equal("2", result4);
            string result5 = calculator.SendKeyPress('=');
            Assert.Equal("12", result5);
        }
        [Fact]
        public void DivisionByZeroScenario2Test()
        {
            //Scenario is 10 / 0 = -E-.
            Calculator calculator = new Calculator();
            string result1 = calculator.SendKeyPress('1');
            Assert.Equal("1", result1);
            string result2 = calculator.SendKeyPress('0');
            Assert.Equal("10", result2);
            string result3 = calculator.SendKeyPress('/');
            Assert.Equal("10", result3);
            string result4 = calculator.SendKeyPress('0');
            Assert.Equal("0", result4);
            string result5 = calculator.SendKeyPress('=');
            Assert.Equal("-E-", result5);
        }

        [Fact]
        public void Scenario3Test()
        {
            //Scenario is 0.001.
            Calculator calculator = new Calculator();
            string result1 = calculator.SendKeyPress('0');
            Assert.Equal("0", result1);
            string result2 = calculator.SendKeyPress('0');
            Assert.Equal("0", result2);
            string result3 = calculator.SendKeyPress('.');
            Assert.Equal("0.", result3);
            string result4 = calculator.SendKeyPress('.');
            Assert.Equal("0.", result4);
            string result5 = calculator.SendKeyPress('0');
            Assert.Equal("0.0", result5);
            string result6 = calculator.SendKeyPress('0');
            Assert.Equal("0.00", result6);
            string result7 = calculator.SendKeyPress('1');
            Assert.Equal("0.001", result7);
        }

        [Fact]
        public void AdditionRepeatScenario5Test()
        {
            //Scenario is 1 + 2 + 3 + = = 12.
            Calculator calculator = new Calculator();
            string result1 = calculator.SendKeyPress('1');
            Assert.Equal("1", result1);
            string result2 = calculator.SendKeyPress('+');
            Assert.Equal("1", result2);
            string result3 = calculator.SendKeyPress('2');
            Assert.Equal("2", result3);
            string result4 = calculator.SendKeyPress('+');
            Assert.Equal("3", result4);
            string result5 = calculator.SendKeyPress('3');
            Assert.Equal("3", result5);
            string result6 = calculator.SendKeyPress('+');
            Assert.Equal("6", result6);
            string result7 = calculator.SendKeyPress('=');
            Assert.Equal("12", result7);
        }

        [Fact]
        public void AdditionClearScenario6Test()
        {
            //Scenario is 1 + 2 + c = 0.
            Calculator calculator = new Calculator();
            string result1 = calculator.SendKeyPress('1');
            Assert.Equal("1", result1);
            string result2 = calculator.SendKeyPress('+');
            Assert.Equal("1", result2);
            string result3 = calculator.SendKeyPress('2');
            Assert.Equal("2", result3);
            string result4 = calculator.SendKeyPress('+');
            Assert.Equal("3", result4);
            string result5 = calculator.SendKeyPress('c');
            Assert.Equal("0", result5);
        }
        [Fact]
        public void AdditionSignScenario4Test()
        {
            //Scenario 5 is 12 + (-2) = 10
            Calculator calculator = new Calculator();
            string result1 = calculator.SendKeyPress('1');
            Assert.Equal("1", result1);
            string result2 = calculator.SendKeyPress('2');
            Assert.Equal("12", result2);
            string result3 = calculator.SendKeyPress('+');
            Assert.Equal("12", result3);
            string result4 = calculator.SendKeyPress('2');
            Assert.Equal("2", result4);
            string result5 = calculator.SendKeyPress('s');
            Assert.Equal("-2", result5);
            string result6 = calculator.SendKeyPress('s');
            Assert.Equal("2", result6);
            string result7 = calculator.SendKeyPress('s');
            Assert.Equal("-2", result7);
            string result8 = calculator.SendKeyPress('=');
            Assert.Equal("10", result8);
        }

        [Fact]
        public void AdditionAllPositiveNumberTest()
        {
            string expected = "4";
            Operations operations = new Operations();
            Calculator calculator = new Calculator();
            calculator.operations.Add('+');
            calculator.numbers.Add(Convert.ToString(2));
            calculator.numbers.Add(Convert.ToString(2));
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
            calculator.numbers.Add(Convert.ToString(-2));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(2));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(0));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(-4));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(-4));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(2));
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
            calculator.numbers.Add(Convert.ToString(4));
            calculator.numbers.Add(Convert.ToString(-2));
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
            calculator.numbers.Add(Convert.ToString(-4));
            calculator.numbers.Add(Convert.ToString(-2));
            string actual = operations.Calculate(calculator);
            Assert.Equal(expected, actual);
        }
    }
}
