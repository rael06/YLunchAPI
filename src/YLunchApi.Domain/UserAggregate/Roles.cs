namespace YLunchApi.Domain.UserAggregate;

public static class Roles
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Customer = "Customer";
    public const string RestaurantAdmin = "RestaurantAdmin";
    public static IEnumerable<string> GetList() => typeof(Roles).GetFields().Select(x => x.Name).ToList();
}
