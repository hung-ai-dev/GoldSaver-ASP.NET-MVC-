using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldSaver.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}