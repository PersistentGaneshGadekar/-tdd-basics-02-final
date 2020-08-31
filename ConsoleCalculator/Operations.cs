using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Operations
    {
        public string clearConsole(Calculator calculator)
        {
            calculator.numbers.Clear();
            calculator.operations.Clear();
            calculator.inputnumber = string.Empty;
            return "0";
        }

        public string Calculate(Calculator calculator)
        {
            double result = 0;
            bool isFirstOperation = true;
            int i = 0;
            foreach (var key in calculator.operations)
            {

                switch (key)
                {
                    case '+':
                        if (isFirstOperation)
                            result = calculator.numbers[i] + calculator.numbers[i + 1];
                        else
                            result = result + calculator.numbers[i + 1];
                        break;
                    case '-':
                        if (isFirstOperation)
                            result = calculator.numbers[i] - calculator.numbers[i + 1];
                        else
                            result = result - calculator.numbers[i + 1];
                        break;
                    case 'X':
                    case '*':
                        if (isFirstOperation)
                            result = calculator.numbers[i] * calculator.numbers[i + 1];
                        else
                            result = result * calculator.numbers[i + 1];
                        break;
                    case '/':
                        if (isFirstOperation)
                            result = calculator.numbers[i] / calculator.numbers[i + 1];
                        else
                            result = result / calculator.numbers[i + 1];
                        if (Double.IsInfinity(result))
                        {
                            calculator.numbers.Clear();
                            calculator.operations.Clear();
                            return @"-E-";
                        }
                        break;
                    case '=':
                        if (Double.IsInfinity(result))
                        {
                            calculator.numbers.Clear();
                            calculator.operations.Clear();
                            return @"-E-";
                        }
                        calculator.numbers.Clear();
                        calculator.operations.Clear();
                        calculator.numbers.Add(result);
                        return result.ToString();
                    default:
                        break;
                }
                isFirstOperation = false;
                i++;
            }

            calculator.numbers.Clear();
            calculator.operations.Clear();
            calculator.numbers.Add(result);

            return result.ToString(); ;


        }
    }
}
