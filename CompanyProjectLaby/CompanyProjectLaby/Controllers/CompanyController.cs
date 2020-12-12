using CompanyProjectLaby.Database;
using CompanyProjectLaby.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProjectLaby.Entities;
using Microsoft.EntityFrameworkCore;


namespace CompanyProjectLaby.Controllers
{
    public class CompanyController : Controller

    {
        private readonly ExchangesDbContext _dbContext;
        public CompanyController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };
            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            return RedirectToAction("AddConfirmation", new { itemId = entity.Id });
        }

        [HttpGet]
        public IActionResult AddConfirmation(int itemId)
        {
            return View(itemId);
        }
    }
}
