using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class ProductExemplaarController : Controller
    {
        ProductExemplaarRepository per = new ProductExemplaarRepository(new ProductExemplaarSQLContext());
        ProductRepository productrepo = new ProductRepository(new ProductSQLContext());
       
        // GET: ProductExemplaar
        public ActionResult Index()
        {
            List<ProductExemplaar> productexemplaren = per.GetAllProductExemplaar();
            return View(productexemplaren);
        }

        // GET: ProductExemplaar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductExemplaar/Create
        public ActionResult Create()
        {

            ViewData["category"] = new SelectList(productrepo.GetAllProducts(), "ProductId", "serie");// nog een keer lijst aanroepen anders vind de view de viewdata niet


            List<Product> categories = productrepo.GetAllProducts();
            List<SelectListItem> categoryItems = new List<SelectListItem>();

            foreach (Product category in categories)
            {
                categoryItems.Add(new SelectListItem { Text = Convert.ToString(category.ProductId), Value = Convert.ToString(category.Serie) });
            }

            ViewBag.category = categoryItems;
            ViewData["category"] = new SelectList(productrepo.GetAllProducts(), "ProductId", "serie");

            return View();
        }

        // POST: ProductExemplaar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Product product = new Product(Convert.ToDecimal(Request.Form["category"]));
                ProductExemplaar productExemplaar = new ProductExemplaar(Convert.ToDecimal(Request.Form["category"]), Convert.ToDecimal(collection[""]), collection["barcode"], "0");
                per.Insert(productExemplaar, product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductExemplaar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductExemplaar/Edit/5
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

        // GET: ProductExemplaar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductExemplaar/Delete/5
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
