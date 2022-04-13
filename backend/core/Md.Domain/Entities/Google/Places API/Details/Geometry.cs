using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Details
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Geometry
    {
        public LatLngLiteral location { get; set; } = null!;

        public Bounds viewport { get; set; } = null!;
    }
}
