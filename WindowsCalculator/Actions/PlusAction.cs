namespace WindowsCalculator.Actions
{
    public class PlusAction : IAction
    {
        public double? Execute(double? number1, double? number2)
        {
            if (number1 != null) if (number2 != null) return number1 + number2;
            return null;
        }
        public override string ToString() => "+";
    }
}
