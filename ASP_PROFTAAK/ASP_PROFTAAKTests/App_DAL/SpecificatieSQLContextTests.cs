using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP_PROFTAAK.App_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_PROFTAAK.Controllers;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL.Tests
{
    [TestClass()]
    public class SpecificatieSQLContextTests
    {

        SpecificatieRepository context = new SpecificatieRepository(new SpecificatieTestContext());
        
        [TestMethod()]
        public void GetAllTest()
        {
            List<Specificatie> list = context.GetAll();
            Assert.AreEqual("gehandicapt", list[0].Naam);
            Assert.AreEqual("bereikbaar", list[1].Naam);
            Assert.AreEqual("kraan", list[2].Naam);

        }

        [TestMethod()]
        public void InsertSpecificatieTest()
        {
            Specificatie s = new Specificatie(4, "zwembad");
            context.InsertSpecificatie(s);
            Assert.AreSame(s, context.GetAll()[3]);
        }

        [TestMethod()]
        public void DeleteSpecificatieTest()
        {
            context.DeletePlek(1);
            Assert.IsFalse(context.GetAll().Any(x => x.ID == 1));
        }

        [TestMethod()]
        public void UpdateSpecificatieTest()
        {
            Specificatie s = context.GetAll()[1];
            s.Naam = "zon";
            context.UpdatePlek(s);
            Assert.AreEqual("zon", context.GetAll()[1].Naam);
        }
    }

    public class SpecificatieTestContext : ISpecificatieContext
    {
        private List<Specificatie> specificaties;

        public SpecificatieTestContext()
        {
            specificaties = new List<Specificatie>()
            {
                new Specificatie(1, "gehandicapt"),
                new Specificatie(2, "bereikbaar"),
                new Specificatie(3, "kraan")
            };
        }

        public List<Specificatie> GetAll()
        {
            return specificaties;
        }

        public void InsertSpecificatie(Specificatie specificatie)
        {
            specificaties.Add(specificatie);
        }

        public bool DeleteSpecificatie(int id)
        {
           specificaties.RemoveAll(x => x.ID == id);
           return true;
        }

        public bool UpdateSpecificatie(Specificatie specificatie)
        {
            specificaties[1] = specificatie;
            return true;
        }

        public List<Specificatie> GetAllSpecificatieByPlekId(int id)
        {
            throw new NotImplementedException();
        }
    }
}