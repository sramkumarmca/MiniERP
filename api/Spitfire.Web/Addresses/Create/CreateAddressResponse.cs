namespace Spitfire.Web.Addresses.Create
{
    using Domain;

    public class CreateAddressResponse
    {
        public CreateAddressResponse(Address address)
        {
            FullAddress = string.Format(address.Route, address.StreetNumber, address.Locality, address.Country, address.Id, "{4}: {0} {1}, {2}, {3}");
        }

        public string FullAddress { get; set; }
    }
}