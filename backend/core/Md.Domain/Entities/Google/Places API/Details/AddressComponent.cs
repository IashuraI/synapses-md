namespace Md.Domain.Entities.Google.Places_API.Details
{
    public class AddressComponent
    {
        public string long_name { get; set; } = null!;
        public string short_name { get; set; } = null!;
        public List<string> types { get; set; } = new List<string>();
    }
}
