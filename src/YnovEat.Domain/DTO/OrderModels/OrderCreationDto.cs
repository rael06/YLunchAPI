using System.Collections.Generic;

namespace YnovEat.Domain.DTO.OrderModels
{
    public class OrderCreationDto
    {
        public ICollection<string> ProductsId { get; set; }
    }
}
