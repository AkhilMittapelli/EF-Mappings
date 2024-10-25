using EF_Mappings.Data;
using EF_Mappings.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Mappings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("One to Many")]

        public ActionResult<List<Product>> GetProducts(int categoryId)
        {

            var product = _context.products.Where(a => a.CategoryId == categoryId).ToList();

            return product;
        }

        [HttpGet]
        [Route("Many to One")]

        public Size GetSize(int productId) { 
        
        var size= _context.sizes.FirstOrDefault(a => a.ProductId == productId);

            return size;

        }

        [HttpGet]
        [Route("Many to Many")]

        public async Task<ActionResult<List<Product>>> GetColor(int categoryId)
        {
            var products = await _context.products
                .Where(a => a.CategoryId == categoryId)
                .Include(a => a.size)
                .Include(a => a.colors)
                .ToListAsync();

            return Ok(products);
        }



    }


}
