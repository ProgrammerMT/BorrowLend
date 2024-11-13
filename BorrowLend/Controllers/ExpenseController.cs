using Microsoft.AspNetCore.Mvc;
using BorrowLend.Data;
using BorrowLend.Models;
using System.Linq;
using BorrowLend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BorrowLend.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var expenses = _db.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.ExpenseTypeName,
                    Value = i.ID.ToString()
                })
            };
            return View(expenseVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM itemVM)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(itemVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Repopulate the dropdown list in case of validation errors
            itemVM.TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.ExpenseTypeName,
                Value = i.ID.ToString()
            });

            return View(itemVM);
        }

        public IActionResult Update(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null) return NotFound();
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Delete(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense == null) return NotFound();
            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var expense = _db.Expenses.Find(id);
            if (expense != null)
            {
                _db.Expenses.Remove(expense);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
