using _932121.safonov.dmitriy.lab11.Models;

namespace _932121.safonov.dmitriy.lab11.Services
{
    public interface ICalculationService
    {
        CalcServiceModel Calculate(int firstValue, int secondValue);
    }
}