using CleanDesign.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanDesign.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; } = null!;
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } =null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } = decimal.Zero;

    }
}
