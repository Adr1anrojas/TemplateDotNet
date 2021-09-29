using CleanArchitecture.ApplicationCore.Enumerations;
using System;

namespace CleanArchitecture.ApplicationCore.Entities
{
    public partial class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte Role { get; set; }
    }
}
