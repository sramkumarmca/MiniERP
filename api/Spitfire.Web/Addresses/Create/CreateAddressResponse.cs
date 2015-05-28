namespace Spitfire.Web.Addresses.Create
{
    using Domain;

    public class CreateAddressResponse
    {
        public CreateAddressResponse(Address address)
        {
            FullAddress = string.Format("{4}: {0} {1}, {2}, {3}", address.Route, address.StreetNumber, address.Locality, address.Country, address.Id);
        }

        public string FullAddress { get; set; }
    }
}