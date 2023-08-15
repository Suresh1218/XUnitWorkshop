namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {

        public CalculatorService()
        {

        }
        public int Add(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Positive numbers are allowed");
            }
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            return a / (double)b;
        }
    }

    public interface ICalculatorService
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        double Divide(int a, int b);
    }
}