using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YnovEatApi.Data.Core;
using YnovEatApi.Data.Models;

namespace YnovEatApi.Core.UserModels
{
    public class UserDto : IDtoConverter<ApplicationUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool IsActivated { get; set; }
        public IList<string> Roles { get; set; }
        public UserDto(ApplicationUser user, IList<string> roles)
        {
            FromEntity(user);
            Roles = roles;
        }

        public void FromEntity(ApplicationUser entity)
        {
            Id = entity.Id;
            UserName = entity.NormalizedUserName;
            Firstname = entity.Firstname;
            Lastname = entity.Lastname;
            Email = entity.NormalizedEmail;
            PhoneNumber = entity.PhoneNumber;
            EmailConfirmed = entity.EmailConfirmed;
            PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
            IsActivated = entity.IsActivated;
        }
    }
}
