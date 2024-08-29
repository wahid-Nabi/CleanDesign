
using CleanDesign.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanDesign.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public  string Status { get; set; } = string.Empty;
        public virtual ICollection<OrderItem> OrderItems { get; set; }  = [];
    }
}
