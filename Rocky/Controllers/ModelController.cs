using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ModelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Model> objList = _db.Model;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Model obj)
        {
            if (ModelState.IsValid)
            {
                _db.Model.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Model.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Model obj)
        {
            if (ModelState.IsValid)
            {
                _db.Model.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Model.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Model.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Model.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

