namespace WindowsCalculator.Actions
{
    public class GetPercentAction : IAction
    {
        public double? Execute(double? number1, double? number2)
        {
            return number1 != null && number2 != null ? number2 * (number1 / 100) : number1;
        }

        public override string ToString() => "%";
    }
}
