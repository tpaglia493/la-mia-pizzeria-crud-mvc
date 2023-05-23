﻿using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
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

        [Authorize(Roles = "ADMIN")]
        public IActionResult AddNewPizza()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewPizza", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizze.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("ModifyMenu");
            }

        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult UpdatePizza(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {


                PizzaModel? pizzaToModify = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                return View("UpdatePizza", pizzaToModify);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PizzaModel modifiedPizza, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdatePizza", modifiedPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToModify = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                pizzaToModify.Description = modifiedPizza.Description;
                pizzaToModify.Price = modifiedPizza.Price;
                pizzaToModify.ImgSource = modifiedPizza.ImgSource;
                pizzaToModify.Name = modifiedPizza.Name;

                db.SaveChanges();


                return RedirectToAction("ModifyMenu");
            }

        }
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


