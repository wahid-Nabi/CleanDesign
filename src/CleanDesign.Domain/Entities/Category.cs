
using CleanDesign.Domain.Common;

namespace CleanDesign.Domain.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; set; } = [];

    }
}
