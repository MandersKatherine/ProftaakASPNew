﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class GroepslidRepository
    {
        private readonly IGroepslidContext context;

        public GroepslidRepository(IGroepslidContext context)
        {
            this.context = context;
        }

        public void GeefGroepslidBandjeEnKoppelAanLaatstGeinserteReservering(int accountId)
        {
            context.GeefGroepslidBandjeEnKoppelAanLaatstGeinserteReservering(accountId);
        }

        public List<Groepslid> getGroepsledenByReserveringId(int id)
        {
            return context.getGroepsledenByReserveringId(id);
        }

        public List<Groepslid> getAllResPolsByAccountId(int accountId)
        {
            return context.getAllResPolsByAccountId(accountId);
        }

        public Groepslid GetGroepslidByAccountIDandResID(int accountId, int reserveringId)
        {
            return context.GetGroepslidByAccountIDandResID(accountId, reserveringId);
        }

        public void GeefPolsbandjeAf(int accountId, int reserveringId)
        {
            context.GeefPolsbandjeAf(accountId, reserveringId);
        }
    }
}