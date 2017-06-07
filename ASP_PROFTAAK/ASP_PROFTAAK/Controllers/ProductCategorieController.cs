using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductCategorieController : Controller
    {
        ProductCategorieRepository pcr = new ProductCategorieRepository(new ProductCategorieSQLContext());
        // GET: ProductCategorie
        public ActionResult Index()
        {
            List<ProductCategorie> productcategorie = new List<ProductCategorie>();
            productcategorie = pcr.GetAllCategories();
            return View(productcategorie);
        }

        // GET: ProductCategorie/Details/5
        public ActionResult Details(int id)
        {
            ProductCategorie productcategorie = pcr.GetProductCategorieById(id);
            return View(productcategorie);
        }

        // GET: ProductCategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategorie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategorie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCategorie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategorie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCategorie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
