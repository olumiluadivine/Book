using BookWeb.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookDbContext bookDbContext;
        public CategoryController(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }

        //GET action method // returns the index of cateogory page
        public async Task<IActionResult> Index()
        {
            return View(await bookDbContext.Categories.OrderByDescending(x => x.CreatedDatetime).ToListAsync());
        }

        //GET// View for creating new category
        public IActionResult Create() => View();

        //POST// adding new categroty to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                
                bookDbContext.Add(category);
                await bookDbContext.SaveChangesAsync();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //GET// View for editing category
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var page = bookDbContext.Categories.Find(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        //POST// editing categroty to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {

                bookDbContext.Update(category);
                await bookDbContext.SaveChangesAsync();
                TempData["Success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //GET// View for deleting category
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var page = bookDbContext.Categories.Find(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        //POST// editing categroty to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var page = bookDbContext.Categories.Find(id);
            if(page == null)
            {
                return NotFound();
            }
            bookDbContext.Categories.Remove(page);
            await bookDbContext.SaveChangesAsync();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
