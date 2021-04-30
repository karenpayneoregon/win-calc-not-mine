namespace WindowsCalculator.Actions
{
    public interface IAction
    {
        double? Execute(double? number1, double? number2);
    }
}
