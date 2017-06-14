using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_PROFTAAK.Models;

namespace ASP_PROFTAAK.App_DAL
{
    public interface IVerhuurContext
    {
        List<Verhuurd> GetAllVerhuurdByAccountId(int accountId);
        void Insert(Verhuurd verhuurd);
        void Update(Verhuurd verhuurd);
        void Delete(Verhuurd verhuurd);
        void Delete(int id);
    }
}