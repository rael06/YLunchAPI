using System;
using System.Collections.Generic;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime? CreationDatetime { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CustomerProduct> Products { get; set; } = new List<CustomerProduct>();
    }
}
