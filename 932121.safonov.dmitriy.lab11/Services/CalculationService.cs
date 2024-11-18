using _932121.safonov.dmitriy.lab11.Models;
using _932121.safonov.dmitriy.lab11.Services;

public class CalculationService : ICalculationService
{
    public CalcServiceModel Calculate(int firstValue, int secondValue)
    {
        return new CalcServiceModel
        {
            FirstValue = firstValue,
            SecondValue = secondValue,
            Add = firstValue + secondValue,
            Sub = firstValue - secondValue,
            Mult = firstValue * secondValue,
            Div = secondValue != 0 ? (double)firstValue / secondValue : double.NaN
        };
    }
}