using System;
using System.Collections.Generic;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Application.DTO.UserModels
{
    public class UserWithRoles
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
        public DateTime CreationDateTime { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public DateTime PhoneNumberConfirmationDateTime { get; set; }
        public DateTime EmailConfirmationDateTime { get; set; }
        public IList<string> Roles { get; set; }

        public UserWithRoles(User user, IList<string> roles)
        {
            FromEntity(user);
            Roles = roles;
        }

        public void FromEntity(User entity)
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
            ConfirmationDateTime = entity.CreationDateTime;
            LastUpdateDateTime = entity.CreationDateTime;
            PhoneNumberConfirmationDateTime = entity.CreationDateTime;
            EmailConfirmationDateTime = entity.CreationDateTime;
        }
    }
}
