using System.ComponentModel.DataAnnotations;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class RestaurantOwnerCreateDto
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Firstname { get; set; }
    [Required] public string Lastname { get; set; }
}
