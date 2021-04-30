namespace WindowsCalculator.Actions
{
    public class NotAction : IAction
    {
        public double? Execute(double? number1, double? number2)
        {
            if (number1 != null)
            {
                if (number2 == null)
                {
                    return number1 - (number1 * 2);
                }
                else
                {
                    // in future process that situation, but now : 
                    return number1 - (number1 * 2);
                }
            }
            
            return null;
            
        }
        public override string ToString() => "!";
    }
}
