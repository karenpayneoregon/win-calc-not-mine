using WindowsCalculator.Actions;

namespace WindowsCalculator.Classes
{
    public class Calc
    {
        public double? Number1 { get; set; }
        public double? Number2 { get; set; }
        public double? Memory { get; set; }
        public IAction Action { get; set; }
        public bool IsActionNull() => Action == null;

        public double? Calculate() => Action.Execute(Number1, Number2);

        public override string ToString()
        {
            var result = string.Empty;

            if (Number1 != null)
            {
                result += Number1 + " ";
                
                if (Action != null)
                {
                    result += Action + " ";
                }
                if (Number2 != null)
                {
                    result += Number2.ToString();
                }
            }
            else
            {
                result = "0";
            }
            
            return result;
        }
    }
}
