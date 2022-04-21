using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ExpensesTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpensesTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<ExpensesType> objList = _db.ExpensesTypes;

            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Create post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpensesType obj)
        {
            if (ModelState.IsValid) 
            {
                _db.Add(obj);
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
            var obj = _db.ExpensesTypes.Find(Id);
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
            var obj = _db.ExpensesTypes.Find(Id);
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
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpensesTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpensesType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpensesTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
