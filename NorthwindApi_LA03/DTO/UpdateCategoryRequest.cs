using System.ComponentModel.DataAnnotations;

namespace NorthwindApi_LA03.DTO
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
