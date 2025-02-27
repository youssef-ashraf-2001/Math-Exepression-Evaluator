using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExepression.MathExepressionEvaluator
{
    public static class ExpressionParser
    {
        //const that contains the symbols operators to check the input
        private const string MathSymbols = "+*/%^";

        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var expr = new MathExpression();
            string token = "";
            bool LeftSideIntialized = false;

            for (var i = 0; i < input.Length; i++) 
            {
                var curChar = input[i];
                //if the input is digit  
                if (char.IsDigit(curChar))
                {
                    token += curChar;
                    //assign the right hand side
                    if(i == input.Length -1 && LeftSideIntialized == true)
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                }
                //if the input is symbol except (-)
                else if (MathSymbols.Contains(curChar))
                {
                    if (!LeftSideIntialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialized = true;
                    }
                    expr.operation = ParseMathOperation(curChar.ToString());
                    token = "";
                }
                //if the input is (-) and it's found at the beginning
                else if(curChar == '-' && i > 0)
                {
                    if(expr.operation == MathOperation.None)
                    {
                        expr.operation = MathOperation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialized = true;
                        token = "";
                    }
                    else
                    {
                        token += curChar;
                    }
                }
                //if the input is a letter
                else if (char.IsLetter(curChar))
                {
                    token += curChar;
                    LeftSideIntialized = true;
                }
                //if the input is white space
                else if(curChar == ' ')
                {
                    if (!LeftSideIntialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialized = true;
                        token = "";
                    }
                    else if(expr.operation == MathOperation.None)
                    {
                        expr.operation = ParseMathOperation(token);
                        token = "";
                    }

                }
                //else--------
                else
                {
                    token += curChar;
                }
            }
            return expr;
        }

        private static MathOperation ParseMathOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;

            }
        }
    }
}
