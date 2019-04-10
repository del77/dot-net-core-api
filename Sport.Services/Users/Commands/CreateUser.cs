using System;
using System.Collections.Generic;
using System.Text;
using Sport.Services.Interfaces;

namespace Sport.Services.Users.Commands
{
    public class CreateUser : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Address UserAddress { get; set; }

        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
        }
    }
}
