using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Details
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class AddressComponent
    {
        public string long_name { get; set; } = null!;
        public string short_name { get; set; } = null!;
        public List<string> types { get; set; } = new List<string>();
    }
}
