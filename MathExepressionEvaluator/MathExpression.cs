using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExepression.MathExepressionEvaluator
{
    public class MathExpression
    {
        public double LeftSideOperand { get; set; }

        public double RightSideOperand { get; set; }
        //object from the enum operators
        public MathOperation operation { get; set; }
    }
}
