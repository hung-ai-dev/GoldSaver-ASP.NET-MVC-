using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        [HttpGet]
        public IEnumerable<Object> GetLog()
        {
            List<Object> trans = new List<Object>();
            var userId = User.Identity.GetUserId();
            var obj = _context.Transactions.Where(t => t.UserId == userId).Select(t => new
            {
                CategoryId = t.CategoryId,
                Note = t.Note,
                DateTime = t.DateTime,
                Cost = t.Cost
            }).GroupBy(t => t.DateTime).ToList();

            var history = new List<Object>();

            foreach (var item in Enumerable.Reverse(obj))
            {
                double sum = 0;
                var listlog = new List<Object>();

                foreach (var _item in item)
                {
                    listlog.Add(new
                    {
                        CategoryLink = _context.Categories.Where(c => c.Id == _item.CategoryId).Select(c => c.Link).ToList().First(),
                        CategoryName = _context.Categories.Where(c => c.Id == _item.CategoryId).Select(c => c.CategoryName).ToList().First(),
                        Note = _item.Note,
                        Cost = _item.Cost,
                    });
                    sum += _item.Cost;
                }

                var newObj = new
                {
                    logweekday = item.First().DateTime.DayOfWeek.ToString(),
                    logday = item.First().DateTime.Day,
                    logmonth = item.First().DateTime.Month,
                    logyear = item.First().DateTime.Year,
                    listlog = listlog,
                    cost = sum
                };
                history.Add(newObj);
            }
            

            return history;
        }
    }
}
