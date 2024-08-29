using CleanDesign.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace CleanDesign.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = [];
        public virtual ICollection<ProductImage> ProductImages { get; set; } = [];

    }
}
