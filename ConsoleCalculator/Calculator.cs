using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
       public string inputnumber;
       public List<double> numbers=new List<double>();
       public List<char> operations=new List<char>();
        Operations operationsObj = new Operations();
       public string SendKeyPress(char key)
        {
           string displayinput=string.Empty;

           if (IsValidInput(key))
            {
                if(key =='c' || key=='C')
                {
                    //numbers.Clear();
                    //operations.Clear();
                    //inputnumber = string.Empty;
                    //return "0";
                    return operationsObj.clearConsole(this);
                }
                if (key == 's' || key == 'S')
                {
                    if(numbers.Count == 1)
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(numbers[0])).ToString();
                        numbers[0] = Convert.ToDouble(inputnumber);
                    }
                    else if (numbers.Count == 2)
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(numbers[1])).ToString();
                        numbers[1] = Convert.ToDouble(inputnumber);
                    } 
                    return Convert.ToString(Convert.ToDouble(inputnumber));
                }
                if (numbers.Count <= 1 && !IsSignPress(  key) && operations.Count != 1)
                {
                    if (!string.IsNullOrEmpty(inputnumber) && inputnumber.Contains(".") && key == '.')
                        return inputnumber;

                    if (key == 's' || key == 'S')
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(inputnumber)).ToString();
                        if (numbers.Count > 0)
                        {
                            numbers[0] = ToggleSign(Convert.ToDouble(numbers[0]));
                        }
                    }
                    else
                    {
                        if (numbers.Count > 0)
                        {
                            numbers[0] = Convert.ToDouble(numbers[0].ToString() + key.ToString());
                        }
                        else
                        {
                            numbers.Add(Convert.ToDouble(key.ToString()));
                        }

                    }
                    displayinput = Convert.ToString(numbers[0]);
                }
                else if (IsSignPress(key) && key.ToString() != "=") {
                    operations.Clear();
                    operations.Add(key); 
                    displayinput = Convert.ToString(numbers[0]);
                } else if (!IsSignPress(key) && numbers.Count >- 1)
                {

                    if (key == 's' || key == 'S')
                    {
                        inputnumber = ToggleSign(Convert.ToDouble(inputnumber)).ToString();
                        if (numbers.Count == 1)
                        {
                            numbers[1] = ToggleSign(Convert.ToDouble(numbers[1]));
                        }
                    }
                    else
                    {
                        if (numbers.Count == 2)
                        {
                            numbers[1] = Convert.ToDouble(numbers[1].ToString() + key.ToString());
                        }
                        else
                        {
                            numbers.Add(Convert.ToDouble(key.ToString()));
                        }

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
                num = num * (-1);
            else
                num = num * (1);

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
