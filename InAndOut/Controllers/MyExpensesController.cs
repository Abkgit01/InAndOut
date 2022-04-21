using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class MyExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MyExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<MyExpenses> objList = _db.Expenses.OrderByDescending(x => x.Amount);

            foreach (var obj in objList)
            {
                
                _db.ExpensesType = _db.ExpensesTypes.FirstOrDefault
                    (u => u.Id == obj.ExpensesTypeId);
            }

            return View(objList);
        }

        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpensesType.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.TypeDropDown = TypeDropDown;

            ExpensesVM expensesVM = new ExpensesVM()
            {
                MyExpenses = new MyExpenses(),

                TypeDropDown = _db.ExpensesTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expensesVM);
        }

        //Create post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpensesVM obj)
        {
            if (ModelState.IsValid) 
            {
                _db.Add(obj.MyExpenses);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // Get Delete 
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) 
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            
        }

        // Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Expenses.Find(Id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get Update 
        public IActionResult Update(int? Id)
        {
            ExpensesVM expensesVM = new ExpensesVM()
            {
                MyExpenses = new MyExpenses(),

                TypeDropDown = _db.ExpensesTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            expensesVM.MyExpenses = _db.Expenses.Find(Id);
            if (expensesVM.MyExpenses == null)
            {
                return NotFound();
            }

            IEnumerable<MyExpenses> objList = _db.Expenses;
            foreach (var objt in objList)
            {
                _db.ExpensesType = _db.ExpensesTypes.FirstOrDefault(u => u.Id == objt.ExpensesTypeId);
            }

            return View(expensesVM);
        }

        // Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpensesVM obj)
        {

            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.MyExpenses);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
