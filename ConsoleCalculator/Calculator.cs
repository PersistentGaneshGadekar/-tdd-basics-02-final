using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
       public string inputnumber;
       public List<string> numbers=new List<string>();
       public List<char> operations=new List<char>();
       readonly  Operations operationsObj = new Operations();
       public string SendKeyPress(char key)
        {
           string displayinput=string.Empty;

           if (IsValidInput(key))
            {
                if(key =='c' || key=='C')
                {
                    return operationsObj.ClearConsole(this);
                }
                if (key == 's' || key == 'S')
                {
                    if(numbers.Count == 1)
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(numbers[0])).ToString();
                        numbers[0] = inputnumber ;
                    }
                    else if (numbers.Count == 2)
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(numbers[1])).ToString();
                        numbers[1] = inputnumber ;
                    } 
                    return Convert.ToString(Convert.ToDouble(inputnumber));
                }
                if (numbers.Count <= 1 && !IsSignPress(  key) && operations.Count != 1)
                {
                    if (numbers.Count > 0 && !numbers[0].Contains(".") && key == '.')
                    {
                        numbers[0] += key;
                        displayinput = numbers[0];
                        return displayinput;
                    } else if (numbers.Count > 0 && numbers[0].Split('.').Length - 1 == 1 && key  != '.')
                    {
                        numbers[0] += key;
                        displayinput = numbers[0];
                        return displayinput;
                    }else if (numbers.Count > 0 && numbers[0].Split('.').Length - 1 == 1 && key == '.')
                    {
                        displayinput = numbers[0];
                        return displayinput;
                    }

                        if (numbers.Count > 0)
                    {
                        numbers[0] =  numbers[0] != "0" ? numbers[0].ToString() + key.ToString() :"0" ;
                    }
                    else
                    {
                        numbers.Add(  key.ToString() );
                    }

                    displayinput = Convert.ToString(numbers[0]);
                }
                else if (IsSignPress(key) && key.ToString() != "=") {
                    
                    if (numbers.Count == 2)
                    {
                        operations.Clear();
                        operations.Add(key);
                        displayinput = operationsObj.Calculate(this); 
                        operations.Add(key);
                    }
                    else
                    {
                        operations.Clear();
                        operations.Add(key);
                        displayinput = Convert.ToString(numbers[0]);
                    }
                    
                } else if (!IsSignPress(key) && numbers.Count >- 1  && key.ToString() != "=")
                {
                    if (numbers.Count > 1 && !numbers[1].Contains(".") && key == '.')
                    {
                        numbers[1] += key;
                        displayinput = numbers[1];
                        return displayinput;
                    }
                    else if (numbers.Count > 1 && numbers[1].Split('.').Length - 1 == 1 && key != '.')
                    {
                        numbers[1] += key;
                        displayinput = numbers[1];
                        return displayinput;
                    }
                    else if (numbers.Count > 0 && numbers[0].Split('.').Length - 1 == 1 && key == '.')
                    {
                        displayinput = numbers[0];
                        return displayinput;
                    }
                    if (numbers.Count == 2)
                    {
                        numbers[1] =  numbers[1].ToString() + key.ToString() ;
                    }
                    else
                    {
                        numbers.Add( key.ToString() );
                    }

                    displayinput = Convert.ToString(numbers[1]);  
                }

                if (key == '=' )
                {
                   return operationsObj.Calculate(this);
                }
            }
            return Convert.ToString(Convert.ToDouble(displayinput));
        }

        private double ToggleSign(double num)
        {         

            if (Math.Sign(num) == 1)
                num *= (-1);
            else
                num *= (-1);

            return num;
        }

       
        private bool IsValidInput(char key)
        {
            return Regex.IsMatch(key.ToString(), @"[=\-*+/]") || Regex.IsMatch(key.ToString(), @"[cCxXsS.0-9]");

        }

        private bool IsSignPress(Char key)
        {
            return Regex.IsMatch(key.ToString(), @"[xX=\-+*\/]");
        }

    }
}
