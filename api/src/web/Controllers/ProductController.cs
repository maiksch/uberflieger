using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.GetOne;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ProductService.GetOne("outcome-based-leadership");
            var list = new List<GetOneProductResponse> { result };
            return Ok(list);
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> Get(string identifier)
        {
            var result = await ProductService.GetOne(identifier);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
