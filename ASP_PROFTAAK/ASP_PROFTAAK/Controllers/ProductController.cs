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
        AccountRepository ar = new AccountRepository(new AccountSQLContext());
        ProductExemplaarRepository per = new ProductExemplaarRepository(new ProductExemplaarSQLContext());
        GroepslidRepository gr = new GroepslidRepository(new GroepslidSQLContext());
        ReserveringRepository rr = new ReserveringRepository(new ReserveringSQLContext());
        VerhuurRepository vr = new VerhuurRepository(new VerhuurSqlContext());
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

        //get persoonlijke productexemplaren
        [HttpGet]
        public ActionResult MijnProductExemplaren()
        {
            List<Verhuurd> gehuurdeProducten = vr.GetAllVerhuurdByAccountId(Convert.ToInt32(Session["UserID"]));

            return View(gehuurdeProducten);
        }




        //get productexemplaren
        [HttpGet]
        public ActionResult ProductExemplaren()
        {
            if(Request["failed"] != null)
            {

                if (Convert.ToBoolean(Request["failed"]))
                {

                    ViewBag.ErrorMessage = "Een reservering is noodzakelijk om producten te kunnen reserveren";
                    return View();

                }

            }
            Account account = ar.GetAccountById(Convert.ToInt32(Session["UserId"]));
            List<Groepslid> reserveringen = gr.getAllResPolsByAccountId(Convert.ToInt32(account.Id));

            if (reserveringen.Any())//checken of het persoon reserveringen heeft
            {
                List<SelectListItem> reserveringItems = new List<SelectListItem>();

                foreach (Groepslid reservering in reserveringen)
                {
                    reserveringItems.Add(new SelectListItem { Text = Convert.ToString(reservering.ReserveringId), Value = Convert.ToString(reservering.ReserveringId) });
                }

                ViewBag.reserveringen = reserveringItems;
                ViewData["reserveringen"] = new SelectList(gr.getAllResPolsByAccountId(Convert.ToInt32(account.Id)), "ReserveringId", "ReserveringId");
                List<ProductExemplaar> productexemplaren = per.GetAllBeschikbareProductExemplaren();
                return View(productexemplaren);
            }
            else
            {
                return RedirectToAction("ProductExemplaren", new { failed = true });

            }
           
        }


        [HttpPost]
        //post productexemplaren
        public ActionResult HuurProducten(FormCollection collection)
        {
            ViewData["reserveringen"] = new SelectList(gr.getAllResPolsByAccountId(Convert.ToInt32(Session["UserId"])), "ReserveringId", "ReserveringId");

            string reserveringID = Request.Form["reserveringen"].ToString();//vraag het id op waarop de producten worden verhuurd
            Reservering reservering = rr.GetReserveringById(Convert.ToInt32(reserveringID));
            Groepslid groepslid = gr.GetGroepslidByAccountIDandResID(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(reservering.Id));

            string[] ids = collection["productExemplaarId"].Split(',');
            foreach (var id in ids)
            {
                ProductExemplaar productexemplaar = per.GetByProductExemplaarID(Convert.ToInt32(id));
                Verhuurd verhuur = new Verhuurd(Convert.ToDecimal(id), Convert.ToDecimal(groepslid.Id), Convert.ToDateTime(reservering.DatumStart), Convert.ToDateTime(reservering.DatumEinde), Convert.ToDecimal(productexemplaar.Prijs), 0);
                vr.Insert(verhuur);
                per.Update(productexemplaar);//updaten naar verhuurd
            }
            
            return RedirectToAction("MijnProductExemplaren");//nog toevoegen
        }

      

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //ID nog instellen bij cat
                Product product = new Product(Convert.ToDecimal(collection["CategorieId"]), collection["Merk"], collection["Serie"], collection["Typenummer"], Convert.ToDecimal(collection["Prijs"]));
                ProductCategorie categorie = new ProductCategorie(Convert.ToDecimal(collection["CategorieId"]), "test");
                PR.Insert(product, categorie);

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                return View();
            }
        }


        public ActionResult NieuwProduct()
        {
            ViewModelCreateProduct v = new ViewModelCreateProduct() { categorien = pcr.GetAllCategories() };

            return View(v);
        }

        [HttpPost]
        public ActionResult NieuwProduct(Product product, ProductCategorie pc)
        {
            if (ModelState.IsValid)
            {
                PR.Insert(product, pc);
            }
          
            return RedirectToAction("Index");
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
