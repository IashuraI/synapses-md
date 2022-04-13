using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Details
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class LatLngLiteral
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
