using System;
using System.Collections.Generic;
using YLunch.Domain.ModelsAggregate.UserAggregate;

namespace YLunch.Domain.ModelsAggregate.CustomerAggregate
{
    public class Cart
    {
        public string UserId { get; set; }
        public DateTime? FulfilmentDatetime { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CustomerProduct> Products { get; set; } = new List<CustomerProduct>();
        public bool IsEmpty => Products.Count == 0;
    }
}
