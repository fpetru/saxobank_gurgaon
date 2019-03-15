using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_webApp.Models;
using Microsoft.AspNetCore.Mvc;
using Core_webApp.Services;
namespace Core_webApp.Controllers
{
    public class ProductController : Controller
    {
        IRepositoryService<Product, int> repository;

        public ProductController(IRepositoryService<Product, int> repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var prds = repository.Get();
            return View(prds);
        }
        //HttpGet
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product prd)
        {
            var res = repository.Create(prd);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var prd = repository.Get(id);
            return View(prd);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product prd)
        {
            repository.Update(id, prd);
            return RedirectToAction("Index");
        }
    }
}