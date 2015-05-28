namespace Spitfire.Web.Countries.Create
{
    using Domain;

    public class CreateCountryResponse
    {
        public CreateCountryResponse(Country country)
        {
            Id = country.Id;
            Name = country.Name;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}
