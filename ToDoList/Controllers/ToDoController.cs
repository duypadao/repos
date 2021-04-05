using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Infrastructure;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;
        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }
        //GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items = from i in context.ToDoList orderby i.Id select i;

            List<TodoList> todoLists = await items.ToListAsync();

            return View(todoLists);
        }

        //GET todos/Create /
        public IActionResult Create() => View();
        //POST todos/Create /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET todos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST todos/Edit /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET todos/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
