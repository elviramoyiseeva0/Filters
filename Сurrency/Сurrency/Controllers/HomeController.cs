using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Сurrency.Filters;
using Сurrency.Models;

namespace Сurrency.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(CurrencyResourceFilter))]
        public IActionResult SelectCurrency(string currency)
        {
            return Content($"Currency selected: {currency}");
        }
    }
}
