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
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            GastoContext categoriaDb = new GastoContext();
            var categorias = categoriaDb.Categorias.ToList();
            int x = 0;
            foreach (var alt in categorias)
            {
                if (categoriaDb.Gastos.Where(y => y.CategoriaId == alt.IdCategory).Count() > 0)
                {
                    var valorGastos = categoriaDb.Gastos.Where(y => y.CategoriaId == alt.IdCategory).Sum(y => y.Valor);
                    categorias.ElementAt(x).ValorCategoria = valorGastos;
                }
                x++;
            }
            return View(categorias);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria obj)
        {
            GastoContext categoriaDb = new GastoContext();
            if (ModelState.IsValid)
            {
                categoriaDb.Categorias.Add(obj);
                categoriaDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
