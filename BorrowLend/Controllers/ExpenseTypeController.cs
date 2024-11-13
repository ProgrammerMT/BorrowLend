using Microsoft.AspNetCore.Mvc;
using BorrowLend.Data;
using BorrowLend.Models;
using System.Linq;

namespace BorrowLend.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var expenseTypes = _db.ExpenseTypes.ToList();
            return View(expenseTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

        public IActionResult Update(int id)
        {
            var expenseType = _db.ExpenseTypes.Find(id);
            if (expenseType == null) return NotFound();
            return View(expenseType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

        public IActionResult Delete(int id)
        {
            var expenseType = _db.ExpenseTypes.Find(id);
            if (expenseType == null) return NotFound();
            return View(expenseType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var expenseType = _db.ExpenseTypes.Find(id);
            if (expenseType != null)
            {
                _db.ExpenseTypes.Remove(expenseType);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
