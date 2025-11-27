using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindApi_LA03.Data;
using NorthwindApi_LA03.Domain;
using NorthwindApi_LA03.DTO;

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

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequest request) {
            //Mapping
            var category = new Category { 
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
                Description = request.Description
            };
            
            _context.Categories.Add(category); //memoria mentés
            _context.SaveChanges(); //adatbázis oldali mentés

            return Created(string.Empty, null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(short id, [FromBody] UpdateCategoryRequest request) 
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category is null)
            {
                return NotFound();
            }
            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            _context.Update(category);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(short id) { 
            var category =
                _context.Categories.SingleOrDefault(c=> c.CategoryId == id);

            if(category is null)
               return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        
        
        }

    }
}
