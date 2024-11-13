using BorrowLend.Data;
using BorrowLend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BorrowLend.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db; // Dependency injection
        }

        // GET: Item/Index
        public IActionResult Index()
        {
            IEnumerable<Item> obj = _db.Items;
            return View(obj);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            // Проверка дали моделът е валиден
            if (ModelState.IsValid)
            {
                // Записване в базата данни
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); // Пренасочване към Index
            }
            // Ако не е валидно, връщане на формата с въведените данни и грешки
            return View(item);
        }

        // GET: Item/Update/{id}
        public IActionResult Update(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item item)
        {
            // Проверка дали моделът е валиден
            if (ModelState.IsValid)
            {
                // Обновяване на записите в базата данни
                _db.Items.Update(item);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); // Пренасочване към Index
            }
            // Ако не е валидно, връщане на формата с въведените данни и грешки
            return View(item);
        }

        // GET: Item/Delete/{id}
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _db.Items.Find(id);
            if (item != null)
            {
                _db.Items.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
