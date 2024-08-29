﻿
using CleanDesign.Domain.Common;
using System.Net;

namespace CleanDesign.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = [];
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
