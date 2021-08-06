using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Gastos.Controllers
{
    public class GastoController : Controller
    {
        public ActionResult Index()
        {
            GastoContext db = new GastoContext();
            var gastos = db.Gastos.Include("Categoria").ToList();

            var gastosTotais = gastos.Sum(x => x.Valor);
            ViewBag.Total = gastosTotais;

            return View(gastos);
        }

        public ActionResult Details(int id)
        {
            GastoContext db = new GastoContext();
            var gasto = db.Gastos.Find(id);
            return View(gasto);
            
        }

        public ActionResult Create()
        {
            FillCategory(1);
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            GastoContext db = new GastoContext();
            var gastos = db.Gastos.Find(id);
            FillCategory(gastos.CategoriaId);
            return View(gastos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Gasto obj)
        {
            GastoContext db = new GastoContext();
            if (ModelState.IsValid)
            {
                Gasto gasto = db.Gastos.First(g => g.Id == id);
                gasto = obj;
                db.Gastos.AddOrUpdate(gasto);
                db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        public ActionResult Delete(int id)
        {
            GastoContext db = new GastoContext();
            var gasto = db.Gastos.Find(id);
            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Gasto obj)
        {
            GastoContext db = new GastoContext();
            if (ModelState.IsValid)
            {
                Gasto gasto = db.Gastos.Find(obj.Id);
                db.Gastos.Remove(gasto);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public void FillCategory(int id)
        {
            GastoContext db = new GastoContext();

            ViewBag.CategoryId = new SelectList(db.Categorias.ToList(), "IdCategory", "Name", id);

        }
    }
}
