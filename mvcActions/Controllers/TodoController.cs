using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcActions.Models;
using todoApp;
using todoApp.Models;

namespace mvcActions.Controllers
{
    public class TodoController : Controller
    {
        private TodoDb db = TodoDb.GetDatabase();
        public IActionResult Index(int? todoId = null)
        {
            if (todoId != null)
            {
                var todo = db.Todos.Find(t => t.Id == todoId.Value);
                return View("Detail", todo);
            }
            else
            {
                return View("List", db.Todos);
            }
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Todo model)
        {
            db.Todos.Add(model);
            return Redirect("~/Todo");
        }
    }
}
