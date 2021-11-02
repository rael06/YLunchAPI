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

        public bool Equals(UserAsCustomerDetailsReadDto other)
        {
            return Id == other.Id && Firstname == other.Firstname && Lastname == other.Lastname &&
                   Email == other.Email && PhoneNumber == other.PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserAsCustomerDetailsReadDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Firstname, Lastname, Email, PhoneNumber);
        }
    }
}
