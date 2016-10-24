using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoldSaver.Models;
using Microsoft.AspNet.Identity;

namespace GoldSaver.Controllers.API
{
    public class WalletsController : ApiController
    {
        private ApplicationDbContext _context;

        public WalletsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public List<Wallet> Get()
        {
            var userId = User.Identity.GetUserId();
            var walletIds = _context.Wallets.Where(w => w.UserId == userId).Select(w => w.Id).ToList();
            var walletNames = _context.Wallets.Where(w => w.UserId == userId).Select(w => w.Name).ToList();
            var listWallets = new List<Wallet>();

            for (int i = 0; i < walletIds.Count; i++)
            {
                listWallets.Add(new Wallet()
                {
                    Id = walletIds[i],
                    Name = walletNames[i]
                });
            }
            return listWallets;
        }

    }
}
