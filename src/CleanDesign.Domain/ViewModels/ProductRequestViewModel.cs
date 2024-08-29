
using CleanDesign.Domain.Entities;

namespace CleanDesign.Application.ViewModels
{
    public class ProductRequestViewModel
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = [];
    }

    public class ProductResponseViewModel
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public List<CategoryResponseViewModel> Categories { get; set;} = [];
    }


  

}
