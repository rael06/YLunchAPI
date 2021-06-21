using System.Threading;

namespace YnovEat.DomainShared.RestaurantAggregate.Enums
{
    // !!! IMPORTANT: Update Count of OrderStateUtils when add value !!!
    public enum OrderState
    {
        Idling,
        Acknowledged,
        InPreparation,
        Ready,
        Canceled,
        Rejected,
        Delivered,
        Other
    }

    public static class OrderStateUtils
    {
        public const int Count = 8;
    }
}
