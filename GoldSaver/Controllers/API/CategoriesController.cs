using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoldSaver.Models;

namespace GoldSaver.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public List<Category> Get()
        {
            var cateId = _context.Categories.Select(c => c.Id).ToList();
            List<Category> categories = new List<Category>();
            foreach (var id in cateId)
            {
                var nameCate = _context.Categories.Where(c => c.Id == id).Select(c => c.CategoryName).ToString();
                var linkCate = _context.Categories.Where(c => c.Id == id).Select(c => c.Link).ToString();
                categories.Add(new Category()
                {
                    Id = id,
                    CategoryName = nameCate,
                    Link = linkCate
                });
            }

            return categories;
        }
    }
}
