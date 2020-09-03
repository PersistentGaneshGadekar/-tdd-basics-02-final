using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Operations
    {
        public string ClearConsole(Calculator calculator)
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
                if (calculator.numbers.Count == 1)
                {
                    calculator.numbers.Add(calculator.numbers[0]);
                }

                switch (key)
                {
                    case '+':
                        if (isFirstOperation)
                            result = Convert.ToDouble( calculator.numbers[i]) + Convert.ToDouble( calculator.numbers[i + 1]);
                        else
                            result +=  Convert.ToDouble(calculator.numbers[i + 1]);
                        break;
                    case '-':
                        if (isFirstOperation)
                            result = Convert.ToDouble(calculator.numbers[i]) - Convert.ToDouble(calculator.numbers[i + 1]);
                        else
                            result -=  Convert.ToDouble(calculator.numbers[i + 1]);
                        break;
                    case 'X':
                    case '*':
                        if (isFirstOperation)
                            result = Convert.ToDouble(calculator.numbers[i]) * Convert.ToDouble(calculator.numbers[i + 1]);
                        else
                            result *=   Convert.ToDouble(calculator.numbers[i + 1]);
                        break;
                    case '/':
                        if (isFirstOperation)
                            result = Convert.ToDouble(calculator.numbers[i]) / Convert.ToDouble(calculator.numbers[i + 1]);
                        else
                            result /=  Convert.ToDouble(calculator.numbers[i + 1]);
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
                        calculator.numbers.Add(result.ToString());
                        return result.ToString();
                    default:
                        break;
                }
                isFirstOperation = false;
                i++;
            }

            calculator.numbers.Clear();
            calculator.operations.Clear();
            calculator.numbers.Add(result.ToString());

            return result.ToString(); ;


        }
    }
}
