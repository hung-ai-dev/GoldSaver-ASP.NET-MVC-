using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using GoldSaver.Models;
using Microsoft.AspNet.Identity;

namespace GoldSaver.Controllers.API
{
    [Authorize]
    public class ActivityLogsController : ApiController
    {
        private ApplicationDbContext _context;

        public ActivityLogsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewTransaction(Transaction transaction)
        {
            Transaction newTrans = new Transaction()
            {
                CategoryId = transaction.CategoryId,
                Cost =  transaction.Cost,
                DateTime = transaction.DateTime,
                Note = transaction.Note,
                UserId =  User.Identity.GetUserId(),
                WalletId = transaction.WalletId
            };
            _context.Transactions.Add(newTrans);
            _context.SaveChanges();
            return Ok();
        }
    }
}
