using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataWithSqlDemo.Data;
using ODataWithSqlDemo.Models;
using System;

namespace ODataWithSqlDemo.Controllers
{

    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // OData-enabled endpoint
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        //https://localhost:7211/odata/Products?$filter=Price gt 100&$select=Name,Price&$orderby=Price desc&$top=5&$count=true

    }
}
