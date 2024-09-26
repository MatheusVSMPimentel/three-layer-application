using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessLayer.Entities
{
    public record Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
