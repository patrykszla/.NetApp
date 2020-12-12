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
        public IActionResult Index()
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
        }

        [HttpPost]
        public IActionResult Index(CompanyModel companyModel)
        {
            var viewModel = new CompanyAddedViewModel {
                NumberOfCharsInName = companyModel.Name.Length,
                NumberOfCharsInDescription = companyModel.Description.Length,
                IsHidden = !companyModel.IsVisible
            };
            return View("CompanyAdded", viewModel);
        }
    }
}
