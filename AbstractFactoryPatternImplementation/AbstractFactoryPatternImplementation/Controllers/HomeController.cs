using Core.Contracts.Factories;
using Microsoft.AspNetCore.Mvc;

namespace AbstractFactoryPatternImplementation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IThemeFactory _themeFactory;

        public HomeController(IThemeFactory themeFactory)
        {
            _themeFactory = themeFactory;
        }

        public IActionResult Index()
        {
            ViewBag.ThemeName = _themeFactory.ThemeName;
            ViewBag.Button = _themeFactory.CreateButton();
            ViewBag.Checkbox = _themeFactory.CreateCheckbox();
            return View();
        }
    }
}
