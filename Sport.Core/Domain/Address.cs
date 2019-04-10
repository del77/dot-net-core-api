namespace Sport.Core.Domain
{
    public class Address
    {
        public Address(string street, string city, string country, string postalCode)
        {
            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}