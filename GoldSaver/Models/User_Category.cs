using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoldSaver.Models
{
    public class User_Category
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CategoryId { get; set; }

        public ApplicationUser User { get; set; }
        public Category Category { get; set; }

    }
}