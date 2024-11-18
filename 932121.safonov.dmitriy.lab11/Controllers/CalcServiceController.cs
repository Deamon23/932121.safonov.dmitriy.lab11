using _932121.safonov.dmitriy.lab11.Models;
using _932121.safonov.dmitriy.lab11.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace _932121.safonov.dmitriy.lab11.Controllers
{
    public class CalcServiceController : Controller
    {
        public IActionResult PassUsingModel()
        {
            var model = new CalcServiceModel
            {
                FirstValue = new Random().Next(0, 11),
                SecondValue = new Random().Next(0, 11)
            };

            model.Add = model.FirstValue + model.SecondValue;
            model.Sub = model.FirstValue - model.SecondValue;
            model.Mult = model.FirstValue * model.SecondValue;

            if (model.SecondValue != 0)
            {
                model.Div = (double)model.FirstValue / model.SecondValue;
            }
            else
            {
                model.ErrorMessage = "Деление на ноль невозможно.";
                model.Div = 0; // или можно оставить пустым
            }

            return View(model);
        }
        public IActionResult PassUsingViewData()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewData["FirstValue"] = firstValue;
            ViewData["SecondValue"] = secondValue;
            ViewData["Add"] = firstValue + secondValue;
            ViewData["Sub"] = firstValue - secondValue;
            ViewData["Mult"] = firstValue * secondValue;
            if (secondValue != 0)
            {
                ViewData["Div"] = (double)firstValue / secondValue;
            }
            else
            {
                ViewData["ErrorMessage"] = "Деление на ноль невозможно.";
                ViewData["Div"] = 0; // или можно оставить пустым
            }
            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewBag.FirstValue = firstValue;
            ViewBag.SecondValue = secondValue;
            ViewBag.Add = firstValue + secondValue;
            ViewBag.Sub = firstValue - secondValue;
            ViewBag.Mult = firstValue * secondValue;
            if (secondValue != 0)
            {
                ViewBag.Div = (double)firstValue / secondValue;
            }
            else
            {
                ViewBag.ErrorMessage = "Деление на ноль невозможно.";
                ViewBag.Div = 0; // или можно оставить пустым
            }
            return View();
        }

        private readonly ICalculationService _calculationService;
        public CalcServiceController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public IActionResult PassUsingServiceInjection()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);
            var model = _calculationService.Calculate(firstValue, secondValue);

            return View(model);
        }
    }
}
