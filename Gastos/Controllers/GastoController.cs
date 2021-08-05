using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Controllers
{
    public class GastoController : Controller
    {
        // GET: GastoController1
        public ActionResult Index()
        {
            GastoContext db = new GastoContext();
            var gastos = db.Gastos.ToList();
            return View(gastos);
        }

        // GET: GastoController1/Details/5
        public ActionResult Details(int id)
        {
            GastoContext db = new GastoContext();
            var gasto = db.Gastos.Find(id);
            return View(gasto);
            
        }

        // GET: GastoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GastoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gasto obj)
        {
            GastoContext db = new GastoContext();
            if (ModelState.IsValid)
            {
                db.Gastos.Add(obj);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        // GET: GastoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GastoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GastoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GastoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
