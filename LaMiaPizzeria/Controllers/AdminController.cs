using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModifyMenu()
        {
            using(PizzaContext db = new PizzaContext()) 
            { 
                List<PizzaModel> pizze = new List<PizzaModel>();
                return View("ModifyMenu",pizze);

            }
        }
    }
}
