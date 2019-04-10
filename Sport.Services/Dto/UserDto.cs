using System;
using System.Collections.Generic;
using System.Text;
using Sport.Core.Domain;

namespace Sport.Services.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public RoleDto Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public AddressDto Address { get; set; }

        public class AddressDto
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
        }
    }
}
