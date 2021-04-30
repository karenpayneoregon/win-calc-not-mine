namespace WindowsCalculator.Actions
{
    public class DenominatorAction : IAction
    {
        public double? Execute(double? number1, double? number2)
        {
            return number1 is not null ? 1 / number1 : null;
        }
    }
}
