using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathExepression.MathExepressionEvaluator
{
    public static class App
    {

        public static void Run(string[] args)
        {
            while (true)
            {
                Console.Write("Enter Math Expression: ");
                var input = Console.ReadLine();
                var expr = ExpressionParser.Parse(input);
               // Console.WriteLine($"Left Side = {expr.LeftSideOperand}, Operation = {expr.operation}, Right Side = {expr.RightSideOperand}");
                Console.WriteLine($"{input} = {EvaluateExpression(expr)}");
            }
        }

        private static object EvaluateExpression(MathExpression expr)
        {
            if (expr.operation == MathOperation.Addition)
            {
                return expr.LeftSideOperand + expr.RightSideOperand;
            }
            else if (expr.operation == MathOperation.Subtraction)
            {
                return expr.LeftSideOperand - expr.RightSideOperand;
            }
            else if(expr.operation == MathOperation.Division)
            {
                return expr.LeftSideOperand / expr.RightSideOperand;
            }
            else if(expr.operation == MathOperation.Modulus)
            {
                return expr.LeftSideOperand % expr.RightSideOperand;
            }
            else if(expr.operation == MathOperation.Multiplication)
            {
                return expr.LeftSideOperand * expr.RightSideOperand;
            }         
            else if(expr.operation == MathOperation.Power)
            {
                return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
            }
            else if (expr.operation == MathOperation.Sin)
            {
                return Math.Sin(expr.RightSideOperand);
            }
            else if (expr.operation == MathOperation.Cos)
            {
                return Math.Cos(expr.RightSideOperand);
            }
            else if (expr.operation == MathOperation.Tan)
            {
                return Math.Tan(expr.RightSideOperand);
            }
            return 0;

        }
    }
}
