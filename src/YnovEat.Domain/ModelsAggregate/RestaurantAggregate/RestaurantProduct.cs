using System;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
