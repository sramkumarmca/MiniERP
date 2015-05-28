namespace Spitfire.Domain
{
    public class Address
    {
        public Address(string street,string streetnr, string locality, string administrativeArea, string country, string postalcode)
        {
            StreetNumber = streetnr;
            Route = street;
            Locality = locality;
            AdministrativeArea = administrativeArea;
            Country = country;
            PostalCode = postalcode;
        }
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string Route { get; set; }
        public string Locality { get; set; }
        public string AdministrativeArea { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
