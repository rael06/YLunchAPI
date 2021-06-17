using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace YnovEat.DomainShared.RestaurantAggregate.Enums
{
    // !!! IMPORTANT: Update Count of ProductFamiliesUtils when add value !!!
    public enum ProductFamilies
    {
        Starter,
        Main,
        Dessert,
        Drink,
        Menu,
        Sandwich,
        Daily,
        Other
    }

    public static class ProductFamiliesUtils
    {
        public const int Count = 8;
    }
}
