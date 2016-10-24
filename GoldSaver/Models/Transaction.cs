using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldSaver.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public float Cost { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }

    }
}