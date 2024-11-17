using _932121.safonov.dmitriy.lab11.Models;
using _932121.safonov.dmitriy.lab11.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace _932121.safonov.dmitriy.lab11.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalculationService _calculationService;

        public CalcController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public IActionResult PassUsingModel()
        {
            var model = new CalcModel
            {
                FirstValue = new Random().Next(0, 11),
                SecondValue = new Random().Next(0, 11)
            };

            model.Sum = model.FirstValue + model.SecondValue;
            model.Difference = model.FirstValue - model.SecondValue;
            model.Product = model.FirstValue * model.SecondValue;

            if (model.SecondValue != 0)
            {
                model.Quotient = (double)model.FirstValue / model.SecondValue;
            }
            else
            {
                model.ErrorMessage = "Деление на ноль невозможно.";
                model.Quotient = 0; // или можно оставить пустым
            }

            return View(model);
        }
        public IActionResult PassUsingViewData()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewData["FirstValue"] = firstValue;
            ViewData["SecondValue"] = secondValue;
            ViewData["Sum"] = firstValue + secondValue;
            ViewData["Difference"] = firstValue - secondValue;
            ViewData["Product"] = firstValue * secondValue;
            ViewData["Quotient"] = secondValue != 0 ? (double)firstValue / secondValue : "Деление на ноль невозможно.";

            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var firstValue = new Random().Next(0, 11);
            var secondValue = new Random().Next(0, 11);

            ViewBag.FirstValue = firstValue;
            ViewBag.SecondValue = secondValue;
            ViewBag.Sum = firstValue + secondValue;
            ViewBag.Difference = firstValue - secondValue;
            ViewBag.Product = firstValue * secondValue;
            if (ViewBag.SecondValue != 0)
            {
                ViewBag.Quotient = (double)ViewBag.FirstValue / ViewBag.SecondValue;
            }
            else
            {
                ViewBag.ErrorMessage = "Деление на ноль невозможно.";
                ViewBag.Quotient = 0; // или можно оставить пустым
            }
            return View();
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
