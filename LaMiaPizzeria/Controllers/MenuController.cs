using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using LaMiaPizzeria.Models.ModelForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizze.ToList();
                return View(pizze);
            }
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult ModifyMenu()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizze.ToList();
                return View(pizze);
            }
        }
        //AGGIUNGERE UNA PIZZA
        [Authorize(Roles = "ADMIN")]
        public IActionResult AddNewPizza()
        {

            using (PizzaContext db = new())
            {
                List<PizzaCategory> pizzaCategories = db.pizzaCategories.ToList();

                PizzaModel_ListPizzaCategory modelForView = new();
                modelForView.Pizza = new PizzaModel();
                modelForView.PizzaCategories = pizzaCategories;

                return View("AddNewPizza", modelForView);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel_ListPizzaCategory data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new())
                {
                    List<PizzaCategory> pizzaCategories = db.pizzaCategories.ToList();
                    data.PizzaCategories = pizzaCategories;
                    return View("AddNewPizza", data);
                }
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizze.Add(data.Pizza);
                db.SaveChanges();

                return RedirectToAction("ModifyMenu");
            }

        }
        //MODIFICARE UNA PIZZA
        [Authorize(Roles = "ADMIN")]
        public IActionResult UpdatePizza(int id)
        {
            using (PizzaContext db = new())
            {
                List<PizzaCategory> pizzaCategories = db.pizzaCategories.ToList();

                PizzaModel_ListPizzaCategory modelForView = new();
                modelForView.Pizza = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                modelForView.PizzaCategories = pizzaCategories;

                return View("UpdatePizza", modelForView);
            }

        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PizzaModel_ListPizzaCategory data, int id)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new())
                {
                    List<PizzaCategory> pizzaCategories = db.pizzaCategories.ToList();
                    data.PizzaCategories = pizzaCategories;
                    return View("UpdatePizza", data);
                }
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToModify = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaToModify == null) { return NotFound("Nessuna pizza trovata"); }
                else
                {

                    pizzaToModify.Description = data.Pizza.Description;
                    pizzaToModify.Price = data.Pizza.Price;
                    pizzaToModify.ImgSource = data.Pizza.ImgSource;
                    pizzaToModify.Name = data.Pizza.Name;
                    pizzaToModify.pizzaCategoryId = data.Pizza.pizzaCategoryId;

                    db.SaveChanges();


                    return RedirectToAction("ModifyMenu");
                }
            }


        }
        //CANCELLARE UNA PIZZA
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToDelete = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();
                    return RedirectToAction("ModifyMenu");
                }
                else
                { return NotFound("Non esiste una pizza da eliminare con questo id"); }
            }
        }
    }
}


