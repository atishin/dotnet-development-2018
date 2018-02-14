using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFStudents.Models;
using EFStudents.Models.Database;

namespace EFStudents.Controllers
{
    public class PeopleController : Controller
    {

        private ApplicationDbContext context;

        public PeopleController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var people = context.People.ToList();
            return View(people);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                context.People.Add(person);
                context.SaveChanges();
            }
            return Redirect("~/People");
        }


        [HttpPost]
        public IActionResult Remove(int id)
        {
            var person = context.People.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                context.People.Remove(person);
                context.SaveChanges();
            }
            return Redirect("~/People");
        }

    }
}
