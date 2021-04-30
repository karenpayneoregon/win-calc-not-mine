using System;

namespace WindowsCalculator.Actions
{
    public class SquareRootAction : IAction
    {
        public double? Execute(double? number1, double? number2)
        {
            if (number1 != null)
            {
                if (number2 == null)
                {
                    if (number1 >= 0)
                    {
                        return Math.Sqrt(number1.Value);
                    }
                    else
                    {
                        throw new Exception("For this operation, the initial value cannot be less than zero!");
                    }
                }
                else
                {
                    // in future process that situation, but now : 
                    if (number1 >= 0)
                    {
                        return Math.Sqrt(number1.Value);
                    }
                    else
                    {
                        throw new Exception("For this operation, the initial value cannot be less than zero!");
                    }
                }
            }
            return null;
        }
        public override string ToString() => "√";
    }
}
