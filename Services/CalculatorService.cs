namespace IntroToAspNetCore_Cooked.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Calculate(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}