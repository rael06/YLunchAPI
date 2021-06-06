using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.ModelsAggregate.CustomerAggregate
{
    public class CustomerCategory
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();
    }
}
