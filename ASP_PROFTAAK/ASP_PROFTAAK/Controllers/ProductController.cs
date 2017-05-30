using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository PR = new ProductRepository(new ProductSQLContext());
        ProductCategorieRepository pcr = new ProductCategorieRepository(new ProductCategorieSQLContext());
        // GET: Product

        public ActionResult Index()
        {
            List<Product> producten = PR.GetAllProducts();
            return View(producten);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        //[HttpPost]
        public ActionResult NieuwProduct()
        {
            ViewModelCreateProduct v = new ViewModelCreateProduct() { categorien = pcr.GetAllCategories() };

            return View(v);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            string[] ids = collection["productId"].Split(',');



            // met een foreach alle geselecteerde producten verwijderen
            return RedirectToAction("Index");
        }
    }
}
