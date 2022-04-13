using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Details
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Place
    {
        public List<AddressComponent> address_components { get; set; } = new List<AddressComponent>();

        public Geometry geometry { get; set; } = null!;

        public string place_id { get; set; } = string.Empty;
    }
}
