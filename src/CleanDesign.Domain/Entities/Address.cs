
using CleanDesign.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanDesign.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
