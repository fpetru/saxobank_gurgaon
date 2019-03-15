using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_webApp.Models;
using Core_webApp.Services;

namespace Core_webApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
         IRepositoryService<Product, int> repository;
        public ProductAPIController(IRepositoryService<Product, int> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var prds = repository.Get();
            return Ok(prds);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prd = repository.Get(id);
            return Ok(prd);
        }
        [HttpPost]
        public IActionResult Post(Product prd)
        {
            if (ModelState.IsValid)
            {
                prd = repository.Create(prd);
                return Ok(prd);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put(int id, Product prd)
        {
            if (ModelState.IsValid)
            {
                var res = repository.Update(id, prd);
                if (res)
                {
                    return Ok("Product Updated Successfullt");
                }
                return NotFound("Record might be moved or deleted");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var res = repository.Delete(id);
            if (res)
            {
                return Ok("Product Deleted Successfullt");
            }
            return NotFound("Record might be moved or already deleted");
        }
    }
}