using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.App_DAL;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.Controllers
{
    public class VerhuurRepository
    {
        private IVerhuurContext context;

        public VerhuurRepository(IVerhuurContext context)
        {
            this.context = context;
        }

        public List<Verhuurd> GetAllVerhuurdByAccountId(int accountId)
        {
            return context.GetAllVerhuurdByAccountId(accountId);
        }


        public void Insert(Verhuurd verhuurd)
        {
            context.Insert(verhuurd);
        }

        public void Update(Verhuurd verhuurd)
        {
            context.Update(verhuurd);
        }

        public void Delete(Verhuurd verhuurd)
        {
            context.Delete(verhuurd);
        }
    }
}