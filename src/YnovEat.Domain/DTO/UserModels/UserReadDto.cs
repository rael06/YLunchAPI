using System;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.DTO.UserModels
{
    public class UserReadDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime CreationDateTime { get; set; }
        public bool IsActivated { get; set; }

        public UserReadDto(User entity)
        {
            Id = entity.Id;
            UserName = entity.NormalizedUserName;
            Firstname = entity.Firstname;
            Lastname = entity.Lastname;
            Email = entity.NormalizedEmail;
            PhoneNumber = entity.PhoneNumber;
            EmailConfirmed = entity.EmailConfirmed;
            PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
            IsActivated = entity.IsAccountActivated;
            CreationDateTime = entity.CreationDateTime;
        }
    }
}
