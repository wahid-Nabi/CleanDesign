using CleanDesign.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanDesign.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public required string ImageUrl { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
