using _932121.safonov.dmitriy.lab11.Models;
using _932121.safonov.dmitriy.lab11.Services;

public class CalculationService : ICalculationService
{
    public CalcModel Calculate(int firstValue, int secondValue)
    {
        return new CalcModel
        {
            FirstValue = firstValue,
            SecondValue = secondValue,
            Sum = firstValue + secondValue,
            Difference = firstValue - secondValue,
            Product = firstValue * secondValue,
            Quotient = secondValue != 0 ? (double)firstValue / secondValue : double.NaN
        };
    }
}