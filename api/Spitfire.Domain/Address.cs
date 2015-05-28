namespace Spitfire.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string Route { get; set; }
        public string Locality { get; set; }
        public string AdministrativeArea { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
