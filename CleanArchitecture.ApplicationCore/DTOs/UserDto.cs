using System;

namespace CleanArchitecture.ApplicationCore.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte Role { get; set; }
    }
}
