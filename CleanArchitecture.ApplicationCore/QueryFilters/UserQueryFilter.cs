using CleanArchitecture.ApplicationCore.Enumerations;
using System;

namespace CleanArchitecture.ApplicationCore.QueryFilters
{
    public class UserQueryFilter
    {
        public byte? Role { get; set; }

        public DateTime? BirthDay { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
