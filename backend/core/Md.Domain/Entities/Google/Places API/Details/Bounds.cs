using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Details
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Bounds
    {
        public LatLngLiteral northeast { get; set; } = null!;

        public LatLngLiteral southwest { get; set; } = null!;
    }
}
