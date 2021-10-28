using System;
using YLunch.Domain.ModelsAggregate.UserAggregate;

namespace YLunch.Domain.DTO.UserModels
{
    public class UserAsCustomerDetailsReadDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserAsCustomerDetailsReadDto(User entity)
        {
            Id = entity.Id;
            Firstname = entity.Firstname;
            Lastname = entity.Lastname;
            Email = entity.NormalizedEmail;
            PhoneNumber = entity.PhoneNumber;
        }
    }
}
