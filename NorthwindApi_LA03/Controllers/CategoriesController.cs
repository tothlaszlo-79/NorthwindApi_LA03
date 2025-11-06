using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindApi_LA03.Data;
using NorthwindApi_LA03.Domain;

namespace NorthwindApi_LA03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories() 
        { 
            var categories = _context.Categories;

            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);

            
        }

        [HttpGet("{id}")]
        public IActionResult GetCategorybyId(int id) {
            var category =  _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);


        }

        [HttpGet("GetCategoryCount")]
        public int CategoryCount() => _context.Categories.Count();


        [HttpGet("{id}/products")]
        public IEnumerable<Product> GetProductsByCategoryId (int id)
        {
            return _context.Products.Where(p=> p.CategoryId == id);
        }
    }
}
