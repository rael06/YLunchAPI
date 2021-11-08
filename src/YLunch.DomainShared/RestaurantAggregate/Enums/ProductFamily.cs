using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace YLunch.DomainShared.RestaurantAggregate.Enums
{
    // IMPORTANT: Update Count of ProductFamiliesUtils when add value !!!
    public enum ProductFamily
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

    public static class ProductFamilyUtils
    {
        public const int Count = 8;
    }
}
